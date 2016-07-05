using System;

namespace ChainOfResponsibility
{
    public class GetRequestHandler : RequestHandler
    {
        private const string RequestTypeToHandle = "Get";

        public GetRequestHandler(RequestHandler handler) : base(handler)
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