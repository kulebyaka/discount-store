using System;

namespace Models
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Item item);
        double GetTotal();
    }

    public class CartService : ICartService
    {
        private double _counter = 0; 
        public void Add(Item item)
        {
            _counter += item.Price;
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public double GetTotal()
        {
            return _counter;
        }
    }

    public class Item
    {
        public readonly double Price;
        public Item(double price)
        {
            Price = price;
        }

    }
}
