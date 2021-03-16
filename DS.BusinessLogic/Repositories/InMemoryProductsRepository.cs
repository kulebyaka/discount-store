using System.Collections.Generic;

namespace DS.BusinessLogic.Repositories
{
	public class InMemoryProductsRepository : InMemoryRepository<Product>, IProductsRepository
	{
		public InMemoryProductsRepository(IList<Product> defaultCollection) : base(defaultCollection)
		{
		}
	}
}