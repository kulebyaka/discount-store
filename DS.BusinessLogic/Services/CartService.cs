using System.Linq;
using DS.BusinessLogic.Repositories;
using Microsoft.Extensions.Logging;
using DS.BusinessLogic.DiscountRules;

namespace DS.BusinessLogic.Services
{
	public class CartService : ICartService
	{
		private readonly IPriceCalculator _priceCalculator;
		private readonly ICartItemsRepository _cartItemsRepository;
		private readonly ILogger<CartService> _logger;

		public CartService(IPriceCalculator priceCalculator, ICartItemsRepository cartItemsRepository, ILogger<CartService> logger)
		{
			_priceCalculator = priceCalculator;
			_cartItemsRepository = cartItemsRepository;
			_logger = logger;
		}

		public void Add(int productId)
		{
			_logger.LogDebug("{Type}.{Method}", GetType(), nameof(Add));
			_cartItemsRepository.Add(productId);
		}

		public void Remove(int productId)
		{
			_logger.LogDebug("{Type}.{Method}", GetType(), nameof(Remove));
			_cartItemsRepository.Remove(productId);
		}

		public decimal GetTotal()
		{
			_logger.LogDebug("{Type}.{Method}", GetType(), nameof(GetTotal));
			return _priceCalculator.Calculate(_cartItemsRepository.GetAll().ToList());
		}
	}
}