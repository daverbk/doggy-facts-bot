using System.Reflection;

namespace DoggyFactsBot.Configuration;

public static class Config
{
    private static readonly Lazy<IConfiguration> Configurator; 
    private static IConfiguration Configuration => Configurator.Value;

    public static string BaseDogFactsApiUrl => Configuration["ExternalApis:BaseDogFactsApiUrl"];
    
    public static string MuffinStickerSet => Configuration["StickerSets:Corgi"];
    
    public static string BotToken => Configuration["BotConnection:BotToken"];

    static Config()
    {
        Configurator = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}
