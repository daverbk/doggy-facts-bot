using System.Text.Json;
using DoggyFactsBot.Configuration;

namespace DoggyFactsBot.DogFacts;

public static class DogFactsProvider
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri(Config.BaseDogFactsApiUrl)
    };

    public static async Task<string> GiveFactAsync()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "api/facts");
        
        var responseMessage = await HttpClient.SendAsync(httpRequestMessage);
        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        var dogFact = JsonSerializer.Deserialize<DogFactModel>(responseContent);

        return dogFact?.Facts.First() ??
               "Oh, paws! Something is wrong with dog facts factory... We'll get back to you soon.";
    }
}
