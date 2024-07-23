using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyPayloadResponse
{
    [JsonPropertyName("name")]
    public InstantlyNameResponse? Name { get; set; }

    [JsonPropertyName("warmup")]
    public InstantlyWarmupResponse? Warmup { get; set; }

    [JsonPropertyName("advanced")]
    public InstantlyAdvancedResponse? Advanced { get; set; }
}