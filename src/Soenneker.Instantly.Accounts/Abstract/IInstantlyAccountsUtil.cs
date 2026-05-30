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
    ValueTask<ListAccount200?> GetList(int? limit = null, DateTimeOffset? skip = null, CancellationToken cancellationToken = default);

    ValueTask<ListAccount200> GetAllAccounts(DateTimeOffset? startingAfter = null, CancellationToken cancellationToken = default);
}
