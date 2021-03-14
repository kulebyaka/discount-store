using System;
using System.Collections;

namespace Models.Repositories
{
	public interface IRepository<T>
	{
		void Add(T item);
	}

	public interface IProductsRepository : IRepository<Product>
	{
		
	}
}