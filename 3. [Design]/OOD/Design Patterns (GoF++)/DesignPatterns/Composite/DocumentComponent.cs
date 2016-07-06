using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class DocumentComponent : IDocumentComponent
    {
        public string DocumentName { get; }
        public List<IDocumentComponent> DocumentComponents { get; set; }

        public DocumentComponent(string documentName)
        {
            DocumentName = documentName;
            DocumentComponents = new List<IDocumentComponent>();
        }

        public string GatherData()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<{DocumentName}>");

            foreach (var component in DocumentComponents)
            {
                stringBuilder.AppendLine(component.GatherData());
            }

            stringBuilder.AppendLine($"</{DocumentName}>");
            return stringBuilder.ToString();
        }

        public void AddComponent(IDocumentComponent documentComponent)
        {
            DocumentComponents.Add(documentComponent);
        }
    }
}