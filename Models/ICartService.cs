using System;

namespace Models
{
    public interface ICartService
    {
        void Add(int productId);
        void Remove(int productId);
        decimal GetTotal();
    }

    public class CartService : ICartService
    {
        public void Add(int productId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int productId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}
