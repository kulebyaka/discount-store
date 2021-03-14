using System.Linq;
using Models.DiscountRules;
using Models.Repositories;

namespace Models.Services
{
	public class CartService : ICartService
	{
		private readonly IDiscountCalculator _discountCalculator;
		private readonly ICartItemsRepository _cartItemsRepository;

		public CartService(IDiscountCalculator discountCalculator, ICartItemsRepository cartItemsRepository)
		{
			this._discountCalculator = discountCalculator;
			this._cartItemsRepository = cartItemsRepository;
		}

		public void Add(int productId)
		{
			_cartItemsRepository.Add(productId);
		}

		public void Remove(int productId)
		{
			_cartItemsRepository.Remove(productId);
		}

		public decimal GetTotal()
		{
			return _discountCalculator.CalculateDiscountedPrice(_cartItemsRepository.GetAll().ToList());
		}
	}
}