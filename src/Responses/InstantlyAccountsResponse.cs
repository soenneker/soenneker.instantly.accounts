using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyAccountsResponse
{
    [JsonPropertyName("accounts")]
    public List<InstantlyAccountResponse>? Accounts { get; set; }
}