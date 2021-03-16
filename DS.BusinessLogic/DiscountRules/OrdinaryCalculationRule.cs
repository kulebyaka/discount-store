using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.DiscountRules
{
	public class OrdinaryCalculationRule : ICalculationRule<CartItem>
	{
		public decimal Apply(CartItem cartItem)
		{
			return cartItem.Quantity * cartItem.Price;
		}

		public string GetName()
		{
			return "Quantity * Price calculation rule";
		}
	}
}