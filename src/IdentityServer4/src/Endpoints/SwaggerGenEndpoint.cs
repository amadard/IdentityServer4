using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using IdentityServer4.Endpoints.Results;
using IdentityServer4.Extensions;
using IdentityServer4.Hosting;
using IdentityServer4.ResponseHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IdentityServer4.Endpoints
{
    internal class SwaggerGenEndpoint : IEndpointHandler
    {
        private readonly ILogger _logger;

        private readonly IdentityServerOptions _options;

        private readonly ISwaggerGenResponseGenerator _responseGenerator;

        public SwaggerGenEndpoint(
            IdentityServerOptions options,
            ISwaggerGenResponseGenerator responseGenerator,
            ILogger<SwaggerGenEndpoint> logger)
        {
            _logger = logger;
            _options = options;
            _responseGenerator = responseGenerator;
        }

        public async Task<IEndpointResult> ProcessAsync(HttpContext context)
        {
            _logger.LogTrace("Processing swagger gen request.");

            // validate HTTP
            if (!HttpMethods.IsGet(context.Request.Method))
            {
                _logger.LogWarning("Swagger gen endpoint only supports GET requests");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            _logger.LogDebug("Start swagger gen request");

            if (!_options.Endpoints.EnableSwaggerGenEndpoint)
            {
                _logger.LogInformation("Swagger gen endpoint disabled. 404.");
                return new StatusCodeResult(HttpStatusCode.NotFound);
            }

            var issuerUri = context.GetIdentityServerIssuerUri();

            // generate response
            _logger.LogTrace("Calling into swagger gen response generator: {type}", _responseGenerator.GetType().FullName);
            var response = await _responseGenerator.CreateSwaggerDocAsync(issuerUri);

            return new SwaggerGenResult(response);
        }
    }
}
