namespace Models.Services
{
    public interface ICartService
    {
        void Add(int productId);
        void Remove(int productId);
        decimal GetTotal();
    }
}
