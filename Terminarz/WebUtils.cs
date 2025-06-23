using System.Net;
using System.Text;
using System.Text.Json;

namespace Terminarz
{
    internal class WebUtils
    {
        private static HttpClient HttpClient = new HttpClient();

        public static string GetBody(HttpListenerRequest request)
        {
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task<(HttpStatusCode code, TResponse?)> Get<TResponse>(string endpointSuffix)
        {
            HttpStatusCode responseCode = default;
            TResponse? data = default;

            try
            {
                var response = await HttpClient.GetAsync($"{WebServer.Endpoint}{endpointSuffix}");

                responseCode = response.StatusCode;

                var content = await response.Content.ReadAsStringAsync();

                data = JsonSerializer.Deserialize<TResponse>(content);
            }
            catch{}

            return (responseCode, data);
        }

        public static async Task<HttpStatusCode> Post<TRequest>(string endpointSuffix, TRequest payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync($"{WebServer.Endpoint}{endpointSuffix}", content);
                return response.StatusCode;
            }
            catch
            {
                return default;
            }
        }

        public static async Task<HttpStatusCode> Delete(string endpointSuffix)
        {
            try
            {
                var response = await HttpClient.DeleteAsync($"{WebServer.Endpoint}{endpointSuffix}");
                return response.StatusCode;
            }
            catch
            {
                return default;
            }
        }
    }
}
