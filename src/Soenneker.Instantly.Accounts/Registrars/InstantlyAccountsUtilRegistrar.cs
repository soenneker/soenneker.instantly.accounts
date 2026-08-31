using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Instantly.ClientUtil.Registrars;

namespace Soenneker.Instantly.Accounts.Registrars;

/// <summary>
/// Registers Instantly sending-account operations.
/// </summary>
public static class InstantlyAccountsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyAccountsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyAccountsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyOpenApiClientUtilAsSingleton()
                .TryAddSingleton<IInstantlyAccountsUtil, InstantlyAccountsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IInstantlyAccountsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyAccountsUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyOpenApiClientUtilAsSingleton()
                .TryAddScoped<IInstantlyAccountsUtil, InstantlyAccountsUtil>();

        return services;
    }
}
