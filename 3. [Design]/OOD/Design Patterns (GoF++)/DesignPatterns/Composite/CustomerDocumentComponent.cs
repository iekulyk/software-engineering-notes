using System;

namespace Composite
{
    class CustomerDocumentComponent : IDocumentComponent
    {

        public CustomerDocumentComponent(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }


        public string GatherData()
        {
            return $"<CustomerId>{CustomerId}</CustomerId>";
        }

        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }
}