using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory.ElfArmy
{
    internal class ElfWarrior : IWarrior
    {
        void IWarrior.Attack()
        {
            Console.WriteLine("Ельф-воин атакует");
        }
    }
}
