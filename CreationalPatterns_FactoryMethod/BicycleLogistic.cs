using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class BicycleLogistic : Logistic
    {
        public override ITransport GenerateTransport()
        {
            return new BicycleTransport();
        }
    }
}