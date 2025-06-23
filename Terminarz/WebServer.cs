using System.Net;
using System.Text;
using Terminarz.REST;

namespace Terminarz
{
    internal class WebServer
    {
        public static readonly string Endpoint = "http://localhost:8090/";

        private readonly HttpListener _listener;
        private readonly Thread _listenerThread;
        private readonly IRequestHandler[] _requestHandlers;

        public WebServer()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(Endpoint);
            _listener.Start();

            _requestHandlers = [
                new FriendsController(new PersistentInMemoryFriendsRepository(), "friends"),
                new MeetingsController(new PersistentInMemoryMeetingsRepository(), "meetings"),
                new NotesController(new PersistentInMemoryNoteRepository(), "notes")
            ];

            _listenerThread = new Thread(Listen);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        private void Listen()
        {
            HttpListenerContext ctx;
            HttpListenerRequest request;
            HttpListenerResponse response;

            HttpStatusCode statusCode;
            string body;

            while (true)
            {
                try
                {
                    ctx = _listener.GetContext();
                    request = ctx.Request;
                    response = ctx.Response;

                    Console.WriteLine($"[REST] Request {request.HttpMethod} {request.Url}");
                    (statusCode, body) = HandleRequest(request, response);

                    Console.WriteLine($"[REST] Response {statusCode} {body}");
                    WriteResponse(response, statusCode, body);
                }
                catch (Exception e)
                {
                    Console.WriteLine("exception caught in web server listener");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private (HttpStatusCode statusCode, string body) HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            foreach (IRequestHandler requestHandler in _requestHandlers)
                if (requestHandler.IsHandler(request))
                    return requestHandler.Handle(request, response);

            return (HttpStatusCode.NotImplemented, "no handler");
        }

        private void WriteResponse(HttpListenerResponse response, HttpStatusCode statusCode, string body)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(body);
            response.StatusCode = (int) statusCode;
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
