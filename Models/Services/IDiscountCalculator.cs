using System.Collections.Generic;
using Models.Repositories;

namespace Models.Services
{
	public interface IDiscountCalculator
	{
		public decimal CalculateDiscountedPrice(IEnumerable<CartItem> items);
	}
}