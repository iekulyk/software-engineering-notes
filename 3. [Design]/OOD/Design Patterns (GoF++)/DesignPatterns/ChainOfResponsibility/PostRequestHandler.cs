using System;

namespace ChainOfResponsibility
{
    public class PostRequestHandler : RequestHandler
    {
        private const string RequestTypeToHandle = "Post";
        public PostRequestHandler(RequestHandler handler) : base(handler)
        {
        }

        public override void HandleRequest(Request request)
        {
            if (request.Type == RequestTypeToHandle)
            {
                Console.WriteLine("{0}RequestHandler doing his job", RequestTypeToHandle);
                return;
            }
            base.HandleRequest(request);
        }
    }
}