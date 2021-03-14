using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DryIoc;
using Models.Repositories;
using Moq;

namespace DS.Tests
{
	public abstract class TestBase
	{
		public virtual void Setup()
		{
			Container = new Container();
			RegisterCommonServices();
		}

		protected Container Container { get; set; }

		private void RegisterCommonServices()
		{
            
		}
        
		protected static TRepository CreateRepository<TRepository, TItem>(Func<IList<TItem>> itemListProvider, Expression<Func<TItem, object>> idProviderExpression = null) where TItem : class
			where TRepository : class, IRepository<TItem>
		{
			Mock<TRepository> repositoryMock = new Mock<TRepository>();

			repositoryMock.Setup(repo => repo.Add(It.IsAny<TItem>()));

			repositoryMock.Setup(repo => repo.GetByQuery<TItem>(It.IsAny<Expression<Func<TItem, bool>>>()))
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
	}
}