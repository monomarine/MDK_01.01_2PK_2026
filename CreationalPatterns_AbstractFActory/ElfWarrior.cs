using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory
{
    internal class ElfWarrior : IWarrior
    {
        void IWarrior.Attack()
        {
            Console.WriteLine("Ельф-воин атакует");
        }
    }
}
