using System.Net;

namespace Terminarz.REST
{
    internal interface IRequestHandler
    {
        bool IsHandler(HttpListenerRequest request);
        (HttpStatusCode statusCode, string body) Handle(HttpListenerRequest request, HttpListenerResponse response);
    }
}
