using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class CarTransport : ITransport
    {
        public void Delivery()
        {
            Console.WriteLine("доставка осуществляется автомобилем. время 1 час");
        }
    }
}