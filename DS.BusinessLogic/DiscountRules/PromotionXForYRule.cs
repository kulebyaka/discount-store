using System.Globalization;
using DS.BusinessLogic.Models;

namespace DS.BusinessLogic.DiscountRules
{
	/// <summary>
	///     Special offer when multiple items are bought.
	/// </summary>
	/// <example>
	///     To define the rule "2 mugs for 1.5€” use the following code:
	///     <code>
	///			new PromotionXForYRule(2, 1.5m);
	///		</code>
	/// </example>
	public class PromotionXForYRule : ICalculationRule<CartItem, decimal>
	{
		private readonly decimal _specialCost;
		private readonly int _specialCostQuantity;
		private readonly string currencySymbol = RegionInfo.CurrentRegion.ISOCurrencySymbol;

		public PromotionXForYRule(int specialCostQuantity, decimal specialCost)
		{
			_specialCostQuantity = specialCostQuantity;
			_specialCost = specialCost;
		}

		public decimal Calculate(CartItem cartItem)
		{
			int quantity = cartItem.Quantity;
			return quantity / _specialCostQuantity * _specialCost
			       + quantity % _specialCostQuantity * cartItem.Price;
		}

		public string GetName()
		{
			return $"Promotion {_specialCostQuantity} for {_specialCost}{currencySymbol}";
		}
	}
}