using Models.Repositories;

namespace Models.DiscountRules
{
	public interface IDiscountRule
	{
		decimal Apply(CartItem cartItem);

		string GetName();
	}
}