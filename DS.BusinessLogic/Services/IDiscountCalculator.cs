using System.Collections.Generic;
using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.Services
{
	public interface IDiscountCalculator
	{
		public decimal CalculateDiscountedPrice(IEnumerable<CartItem> items);
	}
}