using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory.HumanArmy
{
    internal class HumanArcher : IArcher
    {
        public void Shoot()
        {
            Console.WriteLine("человек-лучник пускает стрелу");
        }
    }
}
