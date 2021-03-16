namespace DS.BusinessLogic.Services
{
	/// <summary>
	///     You can add multiple items and then call a totalling method which will return you a price for all items you have
	///     added.
	/// </summary>
	public interface ICartService
	{
		void Add(int productId);
		void Remove(int productId);
		decimal GetTotal();
	}
}