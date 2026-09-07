namespace CreationalPatterns_AbstractFActory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameManager humanManager = new GameManager(new HumanArmyFactory());

 
            humanManager.PrintInfo();

           
        }
    }
}
