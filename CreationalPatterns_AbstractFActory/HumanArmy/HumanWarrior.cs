using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory.HumanArmy
{
    internal class HumanWarrior : IWarrior
    {
        public void Attack()
        {
            Console.WriteLine("человек-воин атакует");
        }
    }
}
