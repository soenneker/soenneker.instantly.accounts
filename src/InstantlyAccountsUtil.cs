using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Instantly.Client;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.Object;
using Soenneker.Extensions.ValueTask;
using Soenneker.Instantly.Accounts.Responses;
using Soenneker.Instantly.Accounts.Requests;
using Soenneker.Extensions.Enumerable;
using System.Collections.Generic;

namespace Soenneker.Instantly.Accounts;

/// <inheritdoc cref="IInstantlyAccountsUtil"/>
public class InstantlyAccountsUtil : IInstantlyAccountsUtil
{
    private readonly IInstantlyClient _instantlyClient;
    private readonly ILogger<InstantlyAccountsUtil> _logger;

    private readonly string _apiKey;
    private readonly bool _log;

    public InstantlyAccountsUtil(IInstantlyClient instantlyClient, ILogger<InstantlyAccountsUtil> logger, IConfiguration config)
    {
        _instantlyClient = instantlyClient;
        _logger = logger;

        _apiKey = config.GetValueStrict<string>("Instantly:ApiKey");
        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<InstantlyAccountsResponse?> GetList(InstantlyGetAccountsRequest? request = null, CancellationToken cancellationToken = default)
    {
        if (_log)
            _logger.LogDebug("Getting accounts from Instantly...");

        if (request == null)
        {
            request = new InstantlyGetAccountsRequest {ApiKey = _apiKey};
        }
        else
        {
            if (request.ApiKey.IsNullOrEmpty())
                request.ApiKey = _apiKey;
        }

        HttpClient client = await _instantlyClient.Get(cancellationToken).NoSync();

        string uri = InstantlyClient.BaseUri + "account/list" + request.ToQueryString();

        InstantlyAccountsResponse? response = await client.SendWithRetryToType<InstantlyAccountsResponse>(HttpMethod.Get, uri, request, cancellationToken: cancellationToken).NoSync();

        return response;
    }

    public async ValueTask<InstantlyAccountsResponse> GetAllAccounts(string? apiKey = null, CancellationToken cancellationToken = default)
    {
        var result = new InstantlyAccountsResponse
        {
            Accounts = new List<InstantlyAccountResponse>()
        };

        var skip = 0;

       var request = new InstantlyGetAccountsRequest();

       const int batchSize = 100;

        if (apiKey.Populated())
            request.ApiKey = apiKey;
        else
            request.ApiKey = _apiKey;

        request.Limit = batchSize;

        while (true)
        {
            // Create or update the request with the current skip value
            request.Skip = skip;

            // Fetch the current batch of accounts
            var response = await GetList(request, cancellationToken);
            if (response == null || response.Accounts == null)
            {
                break; // Exit the loop if no more accounts are returned
            }

            // Add the current batch to the list of all accounts
            result.Accounts.AddRange(response.Accounts);

            // Check if the current batch size is less than the expected batch size
            if (response.Accounts.Count < batchSize)
            {
                break; // Exit the loop if the number of accounts returned is less than the batch size
            }

            // Increment the skip value for the next batch
            skip += batchSize;
        }

        return result;
    }
}