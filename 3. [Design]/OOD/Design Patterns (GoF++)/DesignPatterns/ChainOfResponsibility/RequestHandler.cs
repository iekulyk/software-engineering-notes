namespace ChainOfResponsibility
{
    public abstract class RequestHandler
    {
        public RequestHandler Handler { get; private set; }

        public RequestHandler(RequestHandler handler)
        {
            Handler = handler;
        }

        public virtual void HandleRequest(Request request)
        {
            Handler?.HandleRequest(request);
        }
    }
}


