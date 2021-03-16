using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repositories
{
	public class InMemoryCartItemsRepository : ICartItemsRepository
	{
		private readonly IProductsRepository _productRepository;

		private IDictionary<int, int> inMemory = new Dictionary<int, int>();

		public InMemoryCartItemsRepository(IProductsRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public void Add(int productId)
		{
			bool exist = inMemory.TryGetValue(productId, out int quantity);
			inMemory[productId] = exist ? quantity + 1 : 1;
		}

		public void Remove(int productId)
		{
			bool exist = inMemory.TryGetValue(productId, out int quantity);
			//TODO: 
			if (!exist || quantity == 0)
				throw new Exception("You have no items of this type in your shopping cart");
			inMemory[productId]--;
		}

		public IEnumerable<CartItem> GetAll()
		{
			var currentItems = inMemory.Where(a => a.Value > 0);
			Dictionary<int, decimal> products = _productRepository
				.GetByQuery(pr => currentItems.Select(kv => kv.Key)
					.Contains(pr.Id)).ToDictionary(a => a.Id, a => a.Price);
			List<CartItem> ret = currentItems
				.Select(a =>
					new CartItem
					{
						ProductId = a.Key,
						Quantity = a.Value,
						Price = products[a.Key]
					}).ToList();
			return ret;
		}
	}
}