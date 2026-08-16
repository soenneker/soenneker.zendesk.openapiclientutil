using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Zendesk.HttpClients.Abstract;
using Soenneker.Zendesk.OpenApiClientUtil.Abstract;
using Soenneker.Zendesk.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Zendesk.OpenApiClientUtil;

///<inheritdoc cref="IZendeskOpenApiClientUtil"/>
public sealed class ZendeskOpenApiClientUtil : IZendeskOpenApiClientUtil
{
    private readonly AsyncSingleton<ZendeskOpenApiClient> _client;

    public ZendeskOpenApiClientUtil(IZendeskOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ZendeskOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Zendesk:Credentials");
            string authHeaderName = configuration["Zendesk:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Zendesk:AuthHeaderValueTemplate"] ?? "Basic {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

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
