using Soenneker.Instantly.Accounts.Requests;
using Soenneker.Instantly.Accounts.Responses;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Instantly.Accounts.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Accounts API
/// </summary>
public interface IInstantlyAccountsUtil
{
    ValueTask<InstantlyAccountsResponse?> GetList(InstantlyGetAccountsRequest? request = null, CancellationToken cancellationToken = default);

    ValueTask<InstantlyAccountsResponse> GetAllAccounts(string? apiKey = null, CancellationToken cancellationToken = default);
}