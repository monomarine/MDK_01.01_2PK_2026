using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace StructuralPatterns_Facade
{
    internal class NotifyService
    {
        public void Notify(Order order)
        {
            Console.WriteLine("заказ готов к отправке. подтвердите (Yes/No)");
            string answer = Console.ReadLine();
            if(answer == "Yes")
                order.isNotify = true;

        }
    }
}
