using Models.DiscountRules;
using Models.Repositories;

namespace Models
{
	public class CartService : ICartService
	{
		private ICartItemsRepository _cartRepo;
		private IDiscountCalculator discountCalculator;

		public CartService(IDiscountCalculator discountCalculator, ICartItemsRepository cartRepo)
		{
			this.discountCalculator = discountCalculator;
			this._cartRepo = cartRepo;
		}

		public void Add(int productId)
		{
			_cartRepo.Add(productId);
		}

		public void Remove(int productId)
		{
			_cartRepo.Remove(productId);
		}

		public decimal GetTotal()
		{
			return discountCalculator.CalculateDiscountedPrice();
		}
	}
}