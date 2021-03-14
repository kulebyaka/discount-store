using Models.Repositories;

namespace Models.DiscountRules
{
	public interface IDiscountRule
	{
		decimal Apply(ICartItem cartItem);
	}
}