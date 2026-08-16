using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Zendesk.HttpClients.Registrars;
using Soenneker.Zendesk.OpenApiClientUtil.Abstract;

namespace Soenneker.Zendesk.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ZendeskOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ZendeskOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddZendeskOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddZendeskOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IZendeskOpenApiClientUtil, ZendeskOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ZendeskOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddZendeskOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddZendeskOpenApiHttpClientAsSingleton()
                .TryAddScoped<IZendeskOpenApiClientUtil, ZendeskOpenApiClientUtil>();

        return services;
    }
}
