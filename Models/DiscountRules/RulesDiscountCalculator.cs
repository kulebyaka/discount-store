using System.Collections.Generic;
using System.Linq;
using Models.Repositories;

namespace Models.DiscountRules
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
			List<ICartItem> items = _cartItemsRepository.GetAll().ToList();
			if (!items.Any())
				return 0;

			var sum = 0m;
			foreach (var item in items)
			{
				var rule = _rulesRepository.GetById(item.ProductId);
				sum += rule.Apply(item);
			}
			return sum;
		}
	}
}