using NLog.Extensions.Logging;

namespace DoggyFactsBot.Configuration;

public class NlogConfig
{
    public static readonly IConfigurationRoot Config;
    
    static NlogConfig()
    {
        Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        NLog.LogManager.Configuration = new NLogLoggingConfiguration(Config.GetSection("NLog"));
    }
}
