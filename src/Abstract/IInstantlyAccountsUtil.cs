using Soenneker.Instantly.OpenApiClient.Api.V2.Accounts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Accounts.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Accounts API
/// </summary>
public interface IInstantlyAccountsUtil
{
    ValueTask<AccountsGetResponse?> GetList(int? limit = null, DateTimeOffset? skip = null, CancellationToken cancellationToken = default);

    ValueTask<AccountsGetResponse> GetAllAccounts(DateTimeOffset? startingAfter = null, CancellationToken cancellationToken = default);
}