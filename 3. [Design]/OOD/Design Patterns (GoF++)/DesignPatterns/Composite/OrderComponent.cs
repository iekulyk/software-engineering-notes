using System;

namespace Composite
{
    class OrderComponent : IDocumentComponent
    {

        public OrderComponent(int orderId)
        {
            OrderId = orderId;
        }

        public string GatherData()
        {
            return OrderId.ToString();
        }

        public int OrderId { get; }

        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }
}