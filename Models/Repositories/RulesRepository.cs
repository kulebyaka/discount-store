using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public class RulesRepository : IRulesRepository
	{
		private static readonly Dictionary<int, IDiscountRule> InMemory = new()
		{
			{(int)ItemType.Mug, new PromoutionXForYRule(2, 1.5m)},
			{(int)ItemType.Napkins, new PromoutionXForYRule(3, 0.9m)}
		};

		public IDiscountRule GetByProductId(int productId)
		{
			var exist = InMemory.TryGetValue(productId, out var retVal);
			return exist ? retVal : null;
		}
	}
}