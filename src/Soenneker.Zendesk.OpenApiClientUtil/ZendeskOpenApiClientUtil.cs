using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Zendesk.HttpClients.Abstract;
using Soenneker.Zendesk.OpenApiClientUtil.Abstract;
using Soenneker.Zendesk.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Zendesk.OpenApiClientUtil;

/// <inheritdoc cref="IZendeskOpenApiClientUtil" />
public sealed class ZendeskOpenApiClientUtil : IZendeskOpenApiClientUtil
{
    private readonly AsyncSingleton<ZendeskOpenApiClient> _client;

    public ZendeskOpenApiClientUtil(IZendeskOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<ZendeskOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.AbsoluteUri.TrimEnd('/')
            };

            return new ZendeskOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ZendeskOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
