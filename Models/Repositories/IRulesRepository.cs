using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public interface IRulesRepository
	{
		IDiscountRule GetByProductId(int productId);
	}
}