using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyRandomRangeResponse
{
    [JsonPropertyName("max")]
    public double? Max { get; set; }

    [JsonPropertyName("min")]
    public double? Min { get; set; }
}