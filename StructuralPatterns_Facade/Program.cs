namespace StructuralPatterns_Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Иванов ИИ", "Чкалова 11");
            Order order1 = new Order(client, "заказ на доставку воды");

            OrderFacade facade = new OrderFacade(order1);
            facade.ProcessOrder();
        }
    }
}
