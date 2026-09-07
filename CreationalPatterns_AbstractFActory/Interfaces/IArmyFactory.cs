using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreationalPatterns_AbstractFActory.Interfaces
{
    public interface IArmyFactory
    {
        List<IWarrior> Warriors { get; set; }
        List<IArcher> Archers { get; set; }
        List<IMage> Mages { get; set; }
        void GenerateMages(int count);
        void GenerateArchers(int count);
        void GenerateWarriors(int count);

    }
}