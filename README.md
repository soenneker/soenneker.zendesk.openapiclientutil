[![](https://img.shields.io/nuget/v/soenneker.zendesk.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zendesk.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zendesk.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zendesk.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zendesk.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zendesk.openapiclientutil/)

# Soenneker.Zendesk.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Zendesk.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Zendesk.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddZendeskOpenApiClientUtilAsSingleton();
```

Adds `ZendeskOpenApiClientUtil` as a singleton service.

## What you get

- `IZendeskOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `ZendeskOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ZendeskOpenApiClientUtilRegistrar.AddZendeskOpenApiClientUtilAsSingleton(services)` | Adds `ZendeskOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `ZendeskOpenApiClientUtilRegistrar.AddZendeskOpenApiClientUtilAsScoped(services)` | Adds `ZendeskOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
