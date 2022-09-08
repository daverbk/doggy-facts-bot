using DoggyFactsBot.Configuration;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using Telegram.Bot;

namespace DoggyFactsBot.BotControllers;

public class ErrorHandler
{
    private readonly Logger _logger = LogManager
        .Setup()
        .LoadConfigurationFromSection(NlogConfig.Config)
        .GetCurrentClassLogger();

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.Info(JsonConvert.SerializeObject(exception));

        return Task.CompletedTask;
    }
}
