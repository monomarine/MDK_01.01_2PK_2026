namespace Refactoring
{
    internal interface IOrder
    {
        int Count { get; set; }
        int Id { get; set; }
        double Price { get; set; }
        DateTime Timestamp { get; }

        double GetTotalPrice();
    }
}