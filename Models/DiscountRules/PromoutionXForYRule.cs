using Models.Repositories;

namespace Models.DiscountRules
{
	public class PromoutionXForYRule : IDiscountRule
	{
		private readonly int _specialCostQuantity;
		private readonly decimal _specialCost;

		public PromoutionXForYRule(int specialCostQuantity, decimal specialCost)
		{
			this._specialCostQuantity = specialCostQuantity;
			this._specialCost = specialCost;
		}

		public decimal Apply(CartItem cartItem)
		{
			int quantity = cartItem.Quantity;
			return (quantity / _specialCostQuantity)*_specialCost 
			       + (quantity%_specialCostQuantity)*cartItem.Product.Price;
		}
	}
}