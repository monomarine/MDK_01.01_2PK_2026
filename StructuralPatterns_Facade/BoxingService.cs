using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns_Facade
{
    internal class BoxingService
    {

        public void Pack(Order order)
        {
            if (order.isVIP)
                Console.WriteLine($"заказ максимально бережно упакован в три слоя");
            else
                Console.WriteLine("заказ упакован в пакет");

            order.isBoxing = true;
        }
    }
}
