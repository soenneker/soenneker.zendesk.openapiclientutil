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
    ValueTask<ZendeskOpenApiClient> Get(CancellationToken cancellationToken = default);
}
