using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Zendesk.HttpClients.Registrars;
using Soenneker.Zendesk.OpenApiClientUtil.Abstract;

namespace Soenneker.Zendesk.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the configured Zendesk OpenAPI client provider.
/// </summary>
public static class ZendeskOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IZendeskOpenApiClientUtil"/> as a singleton service.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZendeskOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddZendeskOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IZendeskOpenApiClientUtil, ZendeskOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IZendeskOpenApiClientUtil"/> as a scoped service while retaining the singleton HTTP transport.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddZendeskOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddZendeskOpenApiHttpClientAsSingleton()
                .TryAddScoped<IZendeskOpenApiClientUtil, ZendeskOpenApiClientUtil>();

        return services;
    }
}
