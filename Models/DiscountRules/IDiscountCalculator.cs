namespace Models.DiscountRules
{
	public interface IDiscountCalculator
	{
		public decimal CalculateDiscountedPrice();
	}
}