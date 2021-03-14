using System.Collections.Generic;
using Models.Repositories;

namespace Models.Services
{
	public interface IDiscountCalculator
	{
		public decimal CalculateDiscountedPrice(List<CartItem> items);
	}
}