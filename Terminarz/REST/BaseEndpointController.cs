using System.Net;
using System.Text.Json;

namespace Terminarz.REST
{
    internal abstract class BaseEndpointController<TIdentifier, TEntity> : IRequestHandler
    {
        protected readonly IRepository<TIdentifier, TEntity> _repository;
        protected readonly string _endpoint;

        public BaseEndpointController(IRepository<TIdentifier, TEntity> repository, string endpoint)
        {
            _repository = repository;
            _endpoint = endpoint;
        }

        public (HttpStatusCode statusCode, string body) Handle(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (HttpMethod.Get.ToString().Equals(request.HttpMethod))
                return (HttpStatusCode.OK, JsonSerializer.Serialize(_repository.FindAll()));

            if (HttpMethod.Post.ToString().Equals(request.HttpMethod))
            {
                string body = WebUtils.GetBody(request);
                TEntity? entity = JsonSerializer.Deserialize<TEntity>(body);

                if(entity == null)
                    return (HttpStatusCode.InternalServerError, "could not deserialize entity");

                _repository.Save(entity);

                return (HttpStatusCode.OK, body);
            }

            if (HttpMethod.Delete.ToString().Equals(request.HttpMethod))
            {
                string? identifier = GetIdFromUrl(request);

                if (identifier == null)
                    return (HttpStatusCode.BadRequest, "no identifier");

                TIdentifier tIdentifier = Utils.Parse<TIdentifier>(identifier);

                _repository.Delete(tIdentifier);

                return (HttpStatusCode.OK, identifier);
            }

            return (HttpStatusCode.NotImplemented, "unknown method");
        }

        public bool IsHandler(HttpListenerRequest request)
        {
            return request.Url != null && 
                request.Url.AbsolutePath.StartsWith("/" + _endpoint, StringComparison.OrdinalIgnoreCase);
        }

        private string? GetIdFromUrl(HttpListenerRequest request)
        {
            if (request.Url == null)
                return null;

            var segments = request.Url.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length >= 3 &&
                string.Equals(segments[0], _endpoint, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(segments[1], "delete", StringComparison.OrdinalIgnoreCase))
                return segments[2];

            return null;
        }
    }
}
