namespace DS.BusinessLogic.DiscountRules
{
	public interface ICalculationRule<T>
	{
		decimal Apply(T cartItem);

		string GetName();
	}
}