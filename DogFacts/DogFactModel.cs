using System.Text.Json.Serialization;

namespace DoggyFactsBot.DogFacts;

public class DogFactModel
{
    [JsonPropertyName("facts")] 
    public List<string> Facts { get; set; } = null!;

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
