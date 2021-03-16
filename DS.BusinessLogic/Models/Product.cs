using DS.BusinessLogic.Repositories;

namespace DS.BusinessLogic.Models
{
	public class Product : IDbEntity
	{
		public Product(int id, string name, decimal price)
		{
			Id = id;
			Name = name;
			Price = price;
		}

		public string Name { get; }
		public decimal Price { get; }
		public int Id { get; }
	}
}