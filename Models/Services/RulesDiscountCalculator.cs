using System.Collections.Generic;
using System.Linq;
using Models.DiscountRules;
using Models.Repositories;

namespace Models.Services
{
	public class RulesDiscountCalculator : IDiscountCalculator
	{
		private IRulesRepository _rulesRepository;
		private ICartItemsRepository _cartItemsRepository;

		public RulesDiscountCalculator(ICartItemsRepository cartItemsRepository, IRulesRepository rulesRepository)
		{
			_cartItemsRepository = cartItemsRepository;
			_rulesRepository = rulesRepository;
		}

		public decimal CalculateDiscountedPrice()
		{
			List<CartItem> items = _cartItemsRepository.GetAll().ToList();
			if (!items.Any())
				return 0;

			decimal sum = 0m;
			foreach (var item in items)
			{
				var rule = _rulesRepository.GetByProductId(item.ProductId) ?? new OrdinaryDiscountRule();
				sum += rule.Apply(item);
			}
			return sum;
		}
	}
}