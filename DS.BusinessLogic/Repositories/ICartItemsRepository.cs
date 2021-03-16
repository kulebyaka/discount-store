using System.Collections.Generic;

namespace DS.BusinessLogic.Repositories
{
	public interface ICartItemsRepository
	{
		void Add(int productId);
		void Remove(int productId);
		IEnumerable<CartItem> GetAll();
	}
}