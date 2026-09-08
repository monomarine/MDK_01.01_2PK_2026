using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns_Facade
{
    internal class DeliveryService
    {
        public void Delivery(Order order)
        {
            if(order.isBoxing && order.isNotify)
            {
                if (order.isVIP)
                    Console.WriteLine("Заказ отправлен экспресс доставкой");
                else
                    Console.WriteLine("Зкакз отправлен");
            }
            else
            {
                Console.WriteLine("заказ в ожидании подтверждения");
            }
        }
    }
}
