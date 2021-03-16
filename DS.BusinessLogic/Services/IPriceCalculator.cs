using System.Collections.Generic;
using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.Services
{
	/// <summary>
	/// Interface that defines methods for calculating the cost of products in the shopping cart
	/// </summary>
	public interface IPriceCalculator
	{
		public decimal Calculate(IList<CartItem> items);
	}
}