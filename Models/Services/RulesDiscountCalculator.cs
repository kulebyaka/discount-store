using System.Collections.Generic;
using System.Linq;
using Models.DiscountRules;
using Models.Repositories;

namespace Models.Services
{
	public class RulesDiscountCalculator : IDiscountCalculator
	{
		private IRulesRepository _rulesRepository;

		public RulesDiscountCalculator(IRulesRepository rulesRepository)
		{
			_rulesRepository = rulesRepository;
		}

		public decimal CalculateDiscountedPrice(List<CartItem> items)
		{
			if (!items.Any())
				return 0;

			decimal sum = 0m;
			foreach (var item in items)
			{
				var rule = _rulesRepository.GetByProductId(item.ProductId) ?? new OrdinaryCalculationRule();
				sum += rule.Apply(item);
			}
			return sum;
		}
	}
}