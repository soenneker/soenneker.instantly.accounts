using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Instantly.Client.Registrars;

namespace Soenneker.Instantly.Accounts.Registrars;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Accounts API
/// </summary>
public static class InstantlyAccountsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyAccountsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddInstantlyAccountsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyClientAsSingleton();
        services.TryAddSingleton<IInstantlyAccountsUtil, InstantlyAccountsUtil>();
    }

    /// <summary>
    /// Adds <see cref="IInstantlyAccountsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddInstantlyAccountsUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyClientAsScoped();
        services.TryAddScoped<IInstantlyAccountsUtil, InstantlyAccountsUtil>();
    }
}
