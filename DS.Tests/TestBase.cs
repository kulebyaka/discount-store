using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DryIoc;
using DS.BusinessLogic.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace DS.Tests
{
	public abstract class TestBase
	{
		protected readonly List<string> logMessages = new();

		protected Container Container { get; set; }

		public virtual void Setup()
		{
			Container = new Container();
			RegisterCommonServices();
		}

		private void RegisterCommonServices()
		{
		}

		protected static TRepository CreateRepository<TRepository, TItem>(Func<IList<TItem>> itemListProvider) where TItem : class
			where TRepository : class, IRepository<TItem>
		{
			var repositoryMock = new Mock<TRepository>();

			repositoryMock.Setup(repo => repo.Add(It.IsAny<TItem>()))
				.Callback((TItem item) => { itemListProvider().Add(item); });

			repositoryMock.Setup(repo => repo.GetByQuery(It.IsAny<Expression<Func<TItem, bool>>>()))
				.Returns((Expression<Func<TItem, bool>> query) =>
				{
					IEnumerable<TItem> items = itemListProvider();
					items = items.Where(query.Compile());
					return items.ToList();
				});


			repositoryMock.Setup(repo => repo.GetAll())
				.Returns(() =>
				{
					IEnumerable<TItem> items = itemListProvider();
					return items.ToList();
				});

			return repositoryMock.Object;
		}

		protected static Mock<ILogger<T>> CreateLogger<T>(Action<string> logProvider)
		{
			var logger = new Mock<ILogger<T>>();
			logger.Setup(x => x.Log(
					It.IsAny<LogLevel>(),
					It.IsAny<EventId>(),
					It.IsAny<It.IsAnyType>(),
					It.IsAny<Exception>(),
					(Func<It.IsAnyType, Exception, string>) It.IsAny<object>()))
				.Callback(new InvocationAction(invocation =>
				{
					object state = invocation.Arguments[2];
					var exception = (Exception?) invocation.Arguments[3];
					object formatter = invocation.Arguments[4];
					MethodInfo invokeMethod = formatter.GetType().GetMethod("Invoke");
					string logMessage = (string?) invokeMethod?.Invoke(formatter, new[] {state, exception});

					logProvider.Invoke(logMessage);
				}));

			return logger;
		}
	}
}