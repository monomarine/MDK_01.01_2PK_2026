using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory
{
    internal class HumanArmyFactory : IArmyFactory
    {
        private List<IWarrior> warriors = new List<IWarrior>();
        private List<IArcher> archers = new List<IArcher>();
        private List<IMage> mages = new List<IMage>();

        List<IWarrior> IArmyFactory.Warriors { get => warriors; set => warriors = value; }
        List<IArcher> IArmyFactory.Archers { get => archers; set => archers = value; }
        List<IMage> IArmyFactory.Mages { get => mages; set => mages = value; }

        public void GenerateArchers(int count)
        {
            for (int i = 0; i < count; i++)
                archers.Add(new HumanArcher());
        }

        public void GenerateMages(int count)
        {
            for (int i = 0; i < count; i++)
                mages.Add(new HumanMage());
        }

        public void GenerateWarriors(int count)
        {
            for (int i = 0; i < count; i++)
                warriors.Add(new HumanWarrior());
        }
    }
}
