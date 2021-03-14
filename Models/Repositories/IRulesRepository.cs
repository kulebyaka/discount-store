using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public interface IRulesRepository
	{
		// IEnumerable<IDiscountRule> GetAll();
		IDiscountRule GetById(int productId);
	}
}