﻿using System.Globalization;
using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.DiscountRules
{
	public class PromotionXForYRule : ICalculationRule<CartItem>
	{
		private readonly int _specialCostQuantity;
		private readonly decimal _specialCost;
		private readonly string currencySymbol = RegionInfo.CurrentRegion.ISOCurrencySymbol;

		public PromotionXForYRule(int specialCostQuantity, decimal specialCost)
		{
			_specialCostQuantity = specialCostQuantity;
			_specialCost = specialCost;
		}

		public decimal Apply(CartItem cartItem)
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