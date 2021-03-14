using System.Collections.Generic;

namespace Models.Repositories
{
	public interface ICartItemsRepository
	{
		void Add(int productId);
		void Remove(int productId);
		IEnumerable<CartItem> GetAll();
	}
}