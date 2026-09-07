using CreationalPatterns_AbstractFActory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory
{
    internal class GameManager
    {
        private IArmyFactory factory;

        public GameManager(IArmyFactory new_factory)
        {
            factory = new_factory;
            factory.GenerateArchers(5);
            factory.GenerateMages(2);
            factory.GenerateWarriors(10);

        }

        public void PrintInfo()
        {
            foreach (IWarrior w in factory.Warriors)
                w.Attack();

            foreach (IArcher a in factory.Archers)
                a.Shoot();

            foreach (IMage m in factory.Mages)
                m.Cast();
        }

    }
}
