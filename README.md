[![](https://img.shields.io/nuget/v/soenneker.zendesk.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zendesk.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zendesk.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zendesk.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zendesk.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zendesk.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zendesk.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zendesk.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Zendesk.OpenApiClientUtil

Provides a lazily created `ZendeskOpenApiClient` over the configured Zendesk HTTP transport.

## Install

```shell
dotnet add package Soenneker.Zendesk.OpenApiClientUtil
```

## Configuration

The transport configuration is shared with `Soenneker.Zendesk.HttpClients`. For API-token authentication:

```json
{
  "Zendesk": {
    "ClientBaseUrl": "https://acme.zendesk.com/",
    "Credentials": "base64-encoded-email/token:api-token"
  }
}
```

`Credentials` must be the Base64-encoded UTF-8 value `{email_address}/token:{api_token}`. For OAuth, provide the access token and set `AuthHeaderValueTemplate` to `Bearer {token}`.

## Registration

```csharp
using Soenneker.Zendesk.OpenApiClientUtil.Registrars;

services.AddZendeskOpenApiClientUtilAsSingleton();
```

Scoped registration is also available:

```csharp
services.AddZendeskOpenApiClientUtilAsScoped();
```

The scoped provider borrows the singleton HTTP transport. Disposing the provider releases its generated client but does not remove the shared transport.

## Usage

```csharp
public sealed class ZendeskTicketReader
{
    private readonly IZendeskOpenApiClientUtil _zendesk;

    public ZendeskTicketReader(IZendeskOpenApiClientUtil zendesk)
    {
        _zendesk = zendesk;
    }

    public async Task PrintTickets(CancellationToken cancellationToken)
    {
        ZendeskOpenApiClient client = await _zendesk.Get(cancellationToken);
        var response = await client.Api.V2.Tickets.GetAsync(cancellationToken: cancellationToken);

        foreach (var ticket in response?.Tickets ?? [])
            Console.WriteLine($"{ticket.Id}: {ticket.Subject}");
    }
}
```
