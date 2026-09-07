using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory
{
    internal class ElfArcher : IArcher
    {
        void IArcher.Shoot()
        {
            Console.WriteLine("Эльф-лучник стреляет из своего эльфового лука");
        }
    }
}
