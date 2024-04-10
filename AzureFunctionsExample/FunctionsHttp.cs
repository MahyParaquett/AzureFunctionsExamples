using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureFunctionsExample
{
    public class FunctionsHttp
    {
        private readonly ILogger<FunctionsHttp> _logger;

        public FunctionsHttp(ILogger<FunctionsHttp> logger)
        {
            _logger = logger;
        }

        [Function("HttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(
            AuthorizationLevel.Anonymous,
            "get", "post", 
            Route = "walkthrought")] 
        HttpRequestData req)
        {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new
            {
                Name = "TEST",
                CurrentTime = DateTime.UtcNow
            });

            return response;
        }

        [Function("CurrentTime")]
        public async Task<HttpResponseData> CurrentTime([HttpTrigger(
            AuthorizationLevel.Anonymous,
            "get",
            Route = "current-time-utc")]
        HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new
            {
                CurrentTime = DateTime.UtcNow
            });

            return response;
        }

    }
}
