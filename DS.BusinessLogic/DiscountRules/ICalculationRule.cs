namespace DS.BusinessLogic.DiscountRules
{
	public interface ICalculationRule<in T, out TOut>
	{
		TOut Calculate(T cartItem);

		string GetName();
	}
}