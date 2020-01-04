using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace IdentityServer4.ResponseHandling
{
    /// <summary>
    /// Interface for Swagger Gen OpenAPIDocument generation
    /// </summary>
    public interface ISwaggerGenResponseGenerator
    {
        /// <summary>
        /// Creates an OpenApiDocument for Swagger
        /// </summary>
        /// <param name="issuerUri">Base URI for IdentityServer</param>
        Task<OpenApiDocument> CreateSwaggerDocAsync(string issuerUri);
    }
}
