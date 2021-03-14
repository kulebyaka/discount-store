namespace Models
{
	public class Product
	{
		public readonly int Id;
		public readonly string Name;
		public readonly decimal Price;

		protected Product(decimal price, string name, int id)
		{
			Price = price;
			Name = name;
			Id = id;
		}
	}
}