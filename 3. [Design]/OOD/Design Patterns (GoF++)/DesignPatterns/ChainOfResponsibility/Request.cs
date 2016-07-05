namespace ChainOfResponsibility
{
    public class Request
    {
        public Request(string type)
        {
            Type = type;
        }

        public string Type { get; set; }
    }
}