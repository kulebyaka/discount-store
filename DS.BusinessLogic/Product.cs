using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic
{
	public class Product : IDbEntity
	{
		public int Id { get; }
		public string Name { get; }
		public decimal Price { get; }

		public Product(int id, string name, decimal price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
	}
}