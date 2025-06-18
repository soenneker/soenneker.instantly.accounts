using System.Threading.Tasks;
using System.Threading;
using Soenneker.Instantly.OpenApiClient.Api.V2.Accounts;

namespace Soenneker.Instantly.Accounts.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Accounts API
/// </summary>
public interface IInstantlyAccountsUtil
{
    ValueTask<AccountsGetResponse?> GetList(int? limit = null, int? skip = null, CancellationToken cancellationToken = default);

    ValueTask<AccountsGetResponse> GetAllAccounts(CancellationToken cancellationToken = default);
}