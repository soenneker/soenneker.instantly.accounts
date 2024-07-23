using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Accounts.Responses;

public record InstantlyAdvancedResponse
{
    [JsonPropertyName("warm_ctd")]
    public bool? WarmCtd { get; set; }

    [JsonPropertyName("open_rate")]
    public double? OpenRate { get; set; }

    [JsonPropertyName("random_range")]
    public InstantlyRandomRangeResponse? RandomRange { get; set; }

    [JsonPropertyName("weekday_only")]
    public bool? WeekdayOnly { get; set; }

    [JsonPropertyName("important_rate")]
    public double? ImportantRate { get; set; }

    [JsonPropertyName("read_emulation")]
    public bool? ReadEmulation { get; set; }

    [JsonPropertyName("spam_save_rate")]
    public double? SpamSaveRate { get; set; }

    [JsonPropertyName("increment")]
    public double? Increment { get; set; }

    [JsonPropertyName("reply_rate")]
    public double? ReplyRate { get; set; }

    [JsonPropertyName("imap_host")]
    public string? ImapHost { get; set; }

    [JsonPropertyName("imap_port")]
    public int? ImapPort { get; set; }

    [JsonPropertyName("smtp_host")]
    public string? SmtpHost { get; set; }

    [JsonPropertyName("smtp_port")]
    public int? SmtpPort { get; set; }

    [JsonPropertyName("daily_limit")]
    public double? DailyLimit { get; set; }

    [JsonPropertyName("sending_gap")]
    public string? SendingGap { get; set; }
}