using Soenneker.Zendesk.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Zendesk.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created Zendesk OpenAPI client over the configured shared HTTP transport.
/// </summary>
public interface IZendeskOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Zendesk OpenAPI client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured Zendesk OpenAPI client.</returns>
    ValueTask<ZendeskOpenApiClient> Get(CancellationToken cancellationToken = default);
}
