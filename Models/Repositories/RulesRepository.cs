using System.Collections.Generic;
using Models.DiscountRules;

namespace Models.Repositories
{
	public class RulesRepository : IRulesRepository
	{
		private readonly Dictionary<int, IDiscountRule> _inMemory;

		public RulesRepository(Dictionary<int, IDiscountRule> inMemory)
		{
			_inMemory = inMemory;
		}

		public IDiscountRule GetByProductId(int productId)
		{
			var exist = _inMemory.TryGetValue(productId, out var retVal);
			return exist ? retVal : null;
		}
	}
}