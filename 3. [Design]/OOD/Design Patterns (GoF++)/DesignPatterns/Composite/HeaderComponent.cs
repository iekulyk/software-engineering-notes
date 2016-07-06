using System;

namespace Composite
{
    class HeaderComponent : IDocumentComponent
    {
        public string GatherData()
        {
            return $"<Header>" +
                   $"<TimeStamp>{new DateTime()}</TimeStamp>" +
                   $"</Header>";
        }

        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }
}