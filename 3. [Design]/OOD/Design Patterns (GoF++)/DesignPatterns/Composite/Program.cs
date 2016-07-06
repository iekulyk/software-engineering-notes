using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new DocumentComponent("BlackListDocument");
            var header = new HeaderComponent();
            var body = new DocumentComponent("Body");

            document.AddComponent(header);
            document.AddComponent(body);

            var customer = new CustomerDocumentComponent(10);
            var orders = new DocumentComponent("Orders");
            var order0 = new OrderComponent(0);
            var order1 = new OrderComponent(1);
            orders.AddComponent(order0);
            orders.AddComponent(order1);

            body.AddComponent(customer);
            body.AddComponent(orders);

            Console.WriteLine(document.GatherData());

            Console.ReadLine();
        }
    }
}
