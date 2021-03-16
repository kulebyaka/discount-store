using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Models;

namespace DS.BusinessLogic.Repositories
{
	public interface IRulesRepository
	{
		ICalculationRule<CartItem, decimal> GetByProductId(int productId);
	}
}