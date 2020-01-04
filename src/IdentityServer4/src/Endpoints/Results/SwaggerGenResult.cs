using IdentityServer4.Extensions;
using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Endpoints.Results
{
    /// <summary>
    /// Result for a Swagger json file
    /// </summary>
    /// <seealso cref="IdentityServer4.Hosting.IEndpointResult" />
    public class SwaggerGenResult : IEndpointResult
    {        
        /// <summary>
        /// Gets the OpenApiDocument representing the swagger json file.
        /// </summary>
        /// <value>
        /// The swagger document.
        /// </value>
        public OpenApiDocument SwaggerDocument { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerGenResult" /> class.
        /// </summary>
        /// <param name="swaggerDoc">The OpenApiDocument.</param>
        /// <exception cref="System.ArgumentNullException">entries</exception>
        public SwaggerGenResult(OpenApiDocument swaggerDoc)
        {
            SwaggerDocument = swaggerDoc ?? throw new ArgumentNullException(nameof(swaggerDoc));
        }

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        public Task ExecuteAsync(HttpContext context)
        {
            return context.Response.WriteJsonAsync(SwaggerDocument.Serialize(OpenApiSpecVersion.OpenApi2_0, OpenApiFormat.Json));
        }
    }
}
