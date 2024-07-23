using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Requests;

public class InstantlyGetAccountsRequest
{
    [JsonPropertyName("api_key")]
    public string ApiKey { get; set; } = default!;

    /// <summary>
    /// Defaults to 10 from their API, maxes out at 100.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; } = 10;

    [JsonPropertyName("skip")]
    public int? Skip { get; set; }
}