using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Models.Repositories
{
	public class InMemoryRepository<T> : IRepository<T> where T : IDbEntity 
	{
		private readonly IList<T> _entities;

		public InMemoryRepository(IList<T> defaultCollection)
		{
			_entities = defaultCollection;
		}
		
		public IList<T> GetByQuery<TKey>(Expression<Func<T, bool>> prediction)
		{
			return _entities.Where(prediction.Compile()).ToList();
		}

		public T GetById<TKey>(TKey id)
		{
			return _entities.SingleOrDefault(e => e.Id.Equals(id));
		}

		public IList<T> GetAll()
		{
			return _entities;
		}

		public IQueryable<T> Query()
		{
			return GetAll().AsQueryable();
		}
		
		public void Add(T item)
		{
			_entities.Add(item);
		}
	}

	public interface IDbEntity
	{
		public int Id { get; }
	}
}