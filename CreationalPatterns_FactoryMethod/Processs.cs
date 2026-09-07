using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal static class Processs
    {
        
        public static void GetToDelivery(Order order)
        {
            if (order.Weight > 5)
            {
                var logistic = new CarLogistic();
                logistic.ProcessOrder(order);
            }
            else
            {
                var logistic = new BicycleLogistic();
                logistic.ProcessOrder(order);
            }
        }
    }
}
