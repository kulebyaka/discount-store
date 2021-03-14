using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public class RulesRepository : IRulesRepository
	{
		private static Dictionary<int, IDiscountRule> inMemory = new Dictionary<int, IDiscountRule>()
		{
		};

		public IDiscountRule GetById(int productId)
		{
			return inMemory[productId];
		}
	}
}