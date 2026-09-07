using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory.ElfArmy
{
    internal class ElfMage:IMage
    {       
            public void Cast()
            {
                Console.WriteLine("Эльф-маг кастует заклинание");
            }
        
    }
}
