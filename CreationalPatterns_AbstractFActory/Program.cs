using CreationalPatterns_AbstractFActory.ElfArmy;
using CreationalPatterns_AbstractFActory.HumanArmy;
using CreationalPatterns_AbstractFActory.OrkArmy;

namespace CreationalPatterns_AbstractFActory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameManager humanManager = new GameManager(new HumanArmyFactory());
            GameManager elfManager = new GameManager(new ElfArmyFactory());
            GameManager orkManager = new GameManager(new OrkArmyFactory());

            //humanManager.PrintInfo();
            //elfManager.PrintInfo();
            orkManager.PrintInfo();

           
        }
    }
}
