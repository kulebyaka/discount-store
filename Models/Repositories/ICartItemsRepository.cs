using System.Collections.Generic;

namespace Models.Repositories
{
	public interface ICartItemsRepository 
	{
		void Add(int productId);
		void Remove(int productId);
		IEnumerable<ICartItem> GetAll();
	}

	public interface ICartItem
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}