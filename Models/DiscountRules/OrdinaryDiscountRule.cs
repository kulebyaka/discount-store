using Models.Repositories;

namespace Models.DiscountRules
{
	public class OrdinaryDiscountRule : IDiscountRule
	{
		public decimal Apply(ICartItem cartItem)
		{
			return cartItem.Quantity * cartItem.Product.Price;
		}
	}
}