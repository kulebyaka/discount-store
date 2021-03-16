using System.Collections.Generic;
using System.Linq;
using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Repositories;
using Microsoft.Extensions.Logging;

namespace DS.BusinessLogic.Services
{
	public class RulesDiscountCalculator : IDiscountCalculator
	{
		private readonly IRulesRepository _rulesRepository;
		private readonly ILogger<RulesDiscountCalculator> _logger;

		public RulesDiscountCalculator(IRulesRepository rulesRepository, ILogger<RulesDiscountCalculator> logger)
		{
			_rulesRepository = rulesRepository;
			_logger = logger;
		}

		public decimal CalculateDiscountedPrice(IEnumerable<CartItem> items)
		{
			_logger.LogDebug("{Type}.{Method}", GetType(), nameof(CalculateDiscountedPrice));

			if (!items.Any())
				return 0;

			decimal sum = 0m;
			foreach (CartItem item in items)
			{
				ICalculationRule<CartItem> rule = _rulesRepository.GetByProductId(item.ProductId) ?? new OrdinaryCalculationRule();
				sum += rule.Apply(item);
			}

			return sum;
		}
	}
}