using System.Collections.Generic;
using DS.BusinessLogic.DiscountRules;

namespace DS.BusinessLogic.Repositories
{
	public interface IRulesRepository
	{
		ICalculationRule<CartItem> GetByProductId(int productId);
	}
}