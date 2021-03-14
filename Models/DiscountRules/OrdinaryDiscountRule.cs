using Models.Repositories;

namespace Models.DiscountRules
{
	public class OrdinaryDiscountRule : IDiscountRule
	{
		public decimal Apply(CartItem cartItem)
		{
			return cartItem.Quantity * cartItem.Product.Price;
		}

		public string GetName()
		{
			return "Quantity * Price calculation rule";
		}
	}
}