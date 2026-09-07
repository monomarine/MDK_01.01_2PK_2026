using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory.OrkArmy
{
    internal class OrkMag : IMage
    {
        public void Cast()
        {
            Console.WriteLine("Орк-маг кастует заклинание");
        }
    }
}
