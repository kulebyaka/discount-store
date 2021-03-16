using System.Collections.Generic;
using DS.BusinessLogic.DiscountRules;

namespace DS.BusinessLogic.Repositories
{
	public class RulesRepository : IRulesRepository
	{
		private readonly Dictionary<int, ICalculationRule<CartItem, decimal>> _inMemory;

		public RulesRepository(Dictionary<int, ICalculationRule<CartItem, decimal>> inMemory)
		{
			_inMemory = inMemory;
		}

		public ICalculationRule<CartItem, decimal> GetByProductId(int productId)
		{
			var exist = _inMemory.TryGetValue(productId, out var retVal);
			return exist ? retVal : null;
		}
	}
}