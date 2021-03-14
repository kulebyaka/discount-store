namespace Models.Repositories
{
	public interface IRepository<out T>
	{
		T Get(int id);
	}

	public interface IProductsRepository : IRepository<Product>
	{
		
	}
}