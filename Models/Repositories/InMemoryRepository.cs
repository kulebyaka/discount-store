using System.Collections.Generic;
using System.Linq;

namespace Models.Repositories
{
	public class InMemoryRepository<T> : IRepository<T>
	{
		private readonly IList<object> _entities = new List<object>();
		public T Get(int id)
		{
			return _entities.OfType<T>().SingleOrDefault(e => e.Equals(id));
		}

		public IList<T> GetAll<T>()
		{
			return _entities.OfType<T>().ToList();
		}

		public IQueryable<T> Query<T>()
		{
			return GetAll<T>().AsQueryable();
		}
		
		public void Add(T item)
		{
			_entities.Add(item);
		}
	}
}