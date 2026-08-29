using Soenneker.Zendesk.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Zendesk.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IZendeskOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured zendesk OpenAPI Client used by the Zendesk OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested zendesk OpenAPI Client.</returns>
    ValueTask<ZendeskOpenApiClient> Get(CancellationToken cancellationToken = default);
}
