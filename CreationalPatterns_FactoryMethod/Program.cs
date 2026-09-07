using ConsoleApp4;

namespace CreationalPatterns_FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order ivanov = new Order(10);
            Order petrov = new Order(4);

            Processs.GetToDelivery(ivanov);
            Processs.GetToDelivery(petrov);
        }
    }
}
