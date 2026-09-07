using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    abstract public class Logistic
    {
        public abstract ITransport GenerateTransport();

        public void ProcessOrder(Order order)
        {
            ITransport transport = GenerateTransport();
            Console.WriteLine($"заказ создан. вес заказа - {order.Weight}");
            transport.Delivery();
        }
    }
}