using Soenneker.Instantly.OpenApiClient.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Accounts.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Accounts API
/// </summary>
public interface IInstantlyAccountsUtil
{
    /// <summary>
    /// Gets list.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <param name="skip">The skip.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ListAccount200?> GetList(int? limit = null, DateTimeOffset? skip = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all accounts.
    /// </summary>
    /// <param name="startingAfter">The starting after.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ListAccount200> GetAllAccounts(DateTimeOffset? startingAfter = null, CancellationToken cancellationToken = default);
}
