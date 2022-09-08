using DoggyFactsBot.BotAssets;
using DoggyFactsBot.Configuration;
using NLog;
using NLog.Extensions.Logging;
using Telegram.Bot;

namespace DoggyFactsBot.BotControllers;

public class BotLauncher
{
    private readonly Logger _logger = LogManager
        .Setup()
        .LoadConfigurationFromSection(NlogConfig.Config)
        .GetCurrentClassLogger();
    
    private readonly ErrorHandler _errorHandler = new();
    private readonly UpdateHandler _updateHandler = new();
    
    public async Task Launch(CancellationToken cancellationToken)
    {
        var botClient = new TelegramBotClient(Config.BotToken);
        await new StickerManager().SetUpStickers(botClient);
        
        botClient.StartReceiving(_updateHandler.HandleUpdateAsync, _errorHandler.HandleErrorAsync, ReplyOptions.ReceiverOptions, cancellationToken);

        await LogLaunch(botClient, cancellationToken);
    }

    private async Task LogLaunch(ITelegramBotClient botClient, CancellationToken cancellationToken)
    {
        var me = await botClient.GetMeAsync(cancellationToken);
        _logger.Info("Start listening for {0}", me.Username);
    }
}
