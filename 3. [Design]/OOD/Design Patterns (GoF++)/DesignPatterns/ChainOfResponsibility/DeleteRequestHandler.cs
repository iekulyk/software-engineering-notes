using System;

namespace ChainOfResponsibility
{
    public class DeleteRequestHandler : RequestHandler
    {
        private const string RequestTypeToHandle = "Delete";

        public DeleteRequestHandler(RequestHandler handler) : base(handler)
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