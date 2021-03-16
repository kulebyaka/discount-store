namespace Models.DiscountRules
{
	public interface ICalculationRule<T>
	{
		decimal Apply(T cartItem);

		string GetName();
	}
}