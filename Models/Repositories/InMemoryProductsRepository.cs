using System.Collections.Generic;

namespace Models.Repositories
{
	public class InMemoryProductsRepository : InMemoryRepository<Product>, IProductsRepository
	{
		public InMemoryProductsRepository(IList<Product> defaultCollection) : base(defaultCollection)
		{
		}
	}
}