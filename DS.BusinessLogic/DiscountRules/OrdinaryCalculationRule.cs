using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.DiscountRules
{
	/// <summary>
	/// Default calculation rule.
	/// Multiplying the quantity of product by its cost
	/// </summary>
	public class OrdinaryCalculationRule : ICalculationRule<CartItem, decimal>
	{
		public decimal Calculate(CartItem cartItem)
		{
			return cartItem.Quantity * cartItem.Price;
		}

		public string GetName()
		{
			return "Quantity * Price calculation rule";
		}
	}
}