using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DryIoc;
using Microsoft.Extensions.Logging;
using DS.BusinessLogic.Repositories;
using Moq;

namespace DS.Tests
{
	public abstract class TestBase
	{
		protected readonly List<string> logMessages = new();
		public virtual void Setup()
		{
			Container = new Container();
			RegisterCommonServices();
		}

		protected Container Container { get; set; }

		private void RegisterCommonServices()
		{
		}

		protected static TRepository CreateRepository<TRepository, TItem>(Func<IList<TItem>> itemListProvider) where TItem : class
			where TRepository : class, IRepository<TItem>
		{
			Mock<TRepository> repositoryMock = new Mock<TRepository>();

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
					var state = invocation.Arguments[2];
					var exception = (Exception?) invocation.Arguments[3];
					var formatter = invocation.Arguments[4];
					var invokeMethod = formatter.GetType().GetMethod("Invoke");
					var logMessage = (string?) invokeMethod?.Invoke(formatter, new[] {state, exception});

					logProvider.Invoke(logMessage);
				}));

			return logger;
		}
	}
}