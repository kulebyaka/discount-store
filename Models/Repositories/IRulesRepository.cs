using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public interface IRulesRepository
	{
		ICalculationRule<CartItem> GetByProductId(int productId);
	}
}