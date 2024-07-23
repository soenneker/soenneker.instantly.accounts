using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyWarmupResponse
{
    [JsonPropertyName("limit")]
    public string? Limit { get; set; }
}