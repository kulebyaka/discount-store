using System;
using System.Collections;

namespace Models.Repositories
{
	public interface IRepository<T>
	{
		T Get(int id);
	}

	public interface IProductsRepository : IRepository<Product>
	{
		
	}
}