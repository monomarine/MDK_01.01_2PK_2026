namespace BehaviourPatterns_TemplateMethod
{
    public record ApiResponse(int StatusCode, string body);
    internal class Program
    {
        static void Main(string[] args)
        {
            var createOrder = new CreateOrderHandler();
            var withdraw = new WithdrawHandler();

            var results = new[]
            {
                createOrder.Handler(new CreateOrderRequest("book121244", 2), "001"),
                createOrder.Handler(new CreateOrderRequest("magazine21", -1), "002"),
                withdraw.Handler(new WithdrawRequest(400), "001"),
                withdraw.Handler(new WithdrawRequest(1500), "002")
            };

            foreach (var result in results)
            {
                Console.WriteLine(result.StatusCode + " " + result.body);
            }

            Console.WriteLine( createOrder.GetLog);
            Console.WriteLine( withdraw.GetLog);
        }
    }
}
