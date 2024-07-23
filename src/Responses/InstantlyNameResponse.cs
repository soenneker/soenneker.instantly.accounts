using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyNameResponse
{
    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("last")]
    public string? Last { get; set; }
}