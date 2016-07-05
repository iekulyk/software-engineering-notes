using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

            var get = new Request("Get");
            var post = new Request("Post");
            var delete = new Request("Delete");

            var getHandler = new GetRequestHandler(null);
            var postHandler = new PostRequestHandler(getHandler);
            var deleteHandler = new DeleteRequestHandler(postHandler);


            deleteHandler.HandleRequest(get);
            deleteHandler.HandleRequest(post);
            deleteHandler.HandleRequest(delete);

            Console.ReadLine();
        }
    }
}
