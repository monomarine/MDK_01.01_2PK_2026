using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns_AbstractFActory
{
    internal class OrkArmyFactory : IArmyFactory
    {
        private List<IWarrior> warriors = new List<IWarrior>();
        private List<IArcher> archers = new List<IArcher>();
        private List<IMage> mages = new List<IMage>();
        public List<IWarrior> Warriors { get => warriors; set => warriors = value; }
        public List<IArcher> Archers { get => archers; set => archers = value; }
        public List<IMage> Mages { get => mages; set => mages = value; }

        public void GenerateArchers(int count)
        {
            for (int i = 0; i < count; i++)
                archers.Add(new OrkArcher());
        }

        public void GenerateMages(int count)
        {
            for (int i = 0; i < count; i++)
                mages.Add(new OrkMag());
        }

        public void GenerateWarriors(int count)
        {
            for (int i = 0; i < count; i++)
                warriors.Add(new OrkWarrior());
        }
    }
}
