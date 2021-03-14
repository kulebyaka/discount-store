using System.Globalization;
using Models.Repositories;

namespace Models.DiscountRules
{
	public class PromotionXForYRule : ICalculationRule<CartItem>
	{
		private readonly int _specialCostQuantity;
		private readonly decimal _specialCost;
		private readonly string currencySymbol = RegionInfo.CurrentRegion.ISOCurrencySymbol;

		public PromotionXForYRule(int specialCostQuantity, decimal specialCost)
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

		public string GetName()
		{
			return $"Promotion {_specialCostQuantity} for {_specialCost}{currencySymbol}";
		}
	}
}