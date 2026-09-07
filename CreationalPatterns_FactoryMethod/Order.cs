using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Order
    {
        public double Weight { get; private set; }
        public Order(double weight)
        {
            Weight = weight;
        }
    }
}
