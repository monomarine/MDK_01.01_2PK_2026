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
