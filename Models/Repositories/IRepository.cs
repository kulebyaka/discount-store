using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Models.Repositories
{
	public interface IRepository<T>
	{
		IList<T> GetByQuery<TKey>(Expression<Func<T, bool>> prediction);
		T GetById<TKey>(TKey id);
		IList<T> GetAll();
		void Add(T item);
	}
}