using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public class RulesRepository : IRulesRepository
	{
		private static Dictionary<int, IDiscountRule> inMemory = new()
		{
			{(int)ItemType.Mug, new PromoutionXForYRule(2, 1.5m)},
			{(int)ItemType.Napkins, new PromoutionXForYRule(3, 0.9m)}
		};

		public IDiscountRule GetById(int productId)
		{
			return inMemory[productId];
		}
	}
}