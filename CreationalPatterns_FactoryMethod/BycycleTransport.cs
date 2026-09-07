using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class BicycleTransport : ITransport
    {
        public void Delivery()
        {
            Console.WriteLine("доставка осуществляется велосипедом. время 10 минут");
        }
    }
}