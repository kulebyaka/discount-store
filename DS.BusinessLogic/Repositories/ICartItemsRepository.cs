using System.Collections.Generic;
using DS.BusinessLogic.Models;

namespace DS.BusinessLogic.Repositories
{
	public interface ICartItemsRepository
	{
		void Add(int productId);
		void Remove(int productId);
		IEnumerable<CartItem> GetAll();
	}
}