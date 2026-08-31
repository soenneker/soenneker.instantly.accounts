using Soenneker.Instantly.OpenApiClient.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Accounts.Abstract;

/// <summary>
/// Lists Instantly sending accounts, either one page at a time or across all available pages.
/// </summary>
public interface IInstantlyAccountsUtil
{
    /// <summary>
    /// Gets one page of sending accounts.
    /// </summary>
    /// <param name="limit">The maximum number of accounts to return. Defaults to 10.</param>
    /// <param name="skip">The timestamp cursor after which to continue.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The account page, or <see langword="null"/> when the API returns no body.</returns>
    ValueTask<ListAccount200Response?> GetList(int? limit = null, DateTimeOffset? skip = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets every sending account by following Instantly's pagination cursor.
    /// </summary>
    /// <param name="startingAfter">An optional timestamp cursor from which to begin.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A combined response containing accounts from every retrieved page.</returns>
    ValueTask<ListAccount200Response> GetAllAccounts(DateTimeOffset? startingAfter = null, CancellationToken cancellationToken = default);
}
