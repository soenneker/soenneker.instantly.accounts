using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyAccountResponse
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("timestamp_created")]
    public string? TimestampCreated { get; set; }

    [JsonPropertyName("timestamp_updated")]
    public string? TimestampUpdated { get; set; }

    [JsonPropertyName("payload")]
    public InstantlyPayloadResponse? Payload { get; set; }
}