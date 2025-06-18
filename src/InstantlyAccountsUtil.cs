using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Instantly.ClientUtil.Abstract;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Extensions.ValueTask;
using Soenneker.Instantly.OpenApiClient;
using Soenneker.Instantly.OpenApiClient.Api.V2.Accounts;

namespace Soenneker.Instantly.Accounts;

/// <inheritdoc cref="IInstantlyAccountsUtil"/>
public sealed class InstantlyAccountsUtil : IInstantlyAccountsUtil
{
    private readonly IInstantlyOpenApiClientUtil _instantlyOpenApiClientUtil;
    private readonly ILogger<InstantlyAccountsUtil> _logger;
    private readonly bool _log;

    public InstantlyAccountsUtil(IInstantlyOpenApiClientUtil instantlyOpenApiClientUtil, ILogger<InstantlyAccountsUtil> logger, IConfiguration config)
    {
        _instantlyOpenApiClientUtil = instantlyOpenApiClientUtil;
        _logger = logger;
        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<AccountsGetResponse?> GetList(int? limit = null, int? skip = null, CancellationToken cancellationToken = default)
    {
        if (_log)
            _logger.LogDebug("Getting accounts from Instantly...");

        InstantlyOpenApiClient client = await _instantlyOpenApiClientUtil.Get(cancellationToken).NoSync();

        return await client.Api.V2.Accounts.GetAsAccountsGetResponseAsync(config => 
        {
            config.QueryParameters.Limit = limit ?? 10;
            if (skip.HasValue)
                config.QueryParameters.StartingAfter = skip.ToString();
        }, cancellationToken);
    }

    public async ValueTask<AccountsGetResponse> GetAllAccounts(CancellationToken cancellationToken = default)
    {
        var result = new AccountsGetResponse
        {
            Items = []
        };

        var startingAfter = "";
        const int batchSize = 100;

        while (true)
        {
            InstantlyOpenApiClient client = await _instantlyOpenApiClientUtil.Get(cancellationToken).NoSync();

            var response = await client.Api.V2.Accounts.GetAsAccountsGetResponseAsync(config => 
            {
                config.QueryParameters.Limit = batchSize;
                if (!string.IsNullOrEmpty(startingAfter))
                    config.QueryParameters.StartingAfter = startingAfter;
            }, cancellationToken);

            if (response?.Items == null)
            {
                break;
            }

            result.Items.AddRange(response.Items);

            if (response.Items.Count < batchSize)
            {
                break;
            }

            startingAfter = response.NextStartingAfter;
        }

        return result;
    }
}