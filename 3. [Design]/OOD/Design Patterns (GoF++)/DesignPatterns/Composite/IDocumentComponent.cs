namespace Composite
{
    public interface IDocumentComponent
    {
        string GatherData();
        void AddComponent(IDocumentComponent documentComponent);
    }
}