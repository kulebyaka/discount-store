using System.Collections.Generic;
using System.Linq;
using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Models;
using DS.BusinessLogic.Repositories;
using Microsoft.Extensions.Logging;

namespace DS.BusinessLogic.Services
{
	/// <summary>
	/// </summary>
	public class PriceCalculator : IPriceCalculator
	{
		private readonly ILogger<PriceCalculator> _logger;
		private readonly IRulesRepository _rulesRepository;

		public PriceCalculator(IRulesRepository rulesRepository, ILogger<PriceCalculator> logger)
		{
			_rulesRepository = rulesRepository;
			_logger = logger;
		}

		public decimal Calculate(IList<CartItem> items)
		{
			_logger.LogDebug("{Type}.{Method}", GetType(), nameof(Calculate));

			if (!items.Any())
				return 0;

			decimal sum = 0m;
			foreach (CartItem item in items)
			{
				ICalculationRule<CartItem, decimal> rule =
					_rulesRepository.GetByProductId(item.ProductId) ?? new OrdinaryCalculationRule();
				sum += rule.Calculate(item);
			}

			return sum;
		}
	}
}