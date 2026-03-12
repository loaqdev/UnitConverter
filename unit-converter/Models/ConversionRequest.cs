using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace unit_converter.Models;

public class ConversionRequest
{
    [Required]
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [Required]
    [JsonPropertyName("fromUnit")]
    public required string FromUnit { get; set; }

    [Required]
    [JsonPropertyName("toUnit")]
    public required string ToUnit { get; set; }

    [Required]
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
}