using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    internal class Order : IOrder
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; private set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public Order(int count, double price)
        {
            Id = new Random().Next();
            Timestamp = DateTime.UtcNow;
            Count = count;
            Price = price;
        }

        public double GetTotalPrice()
        {
            return Price * Count * 0.13;
        }
    }
}
