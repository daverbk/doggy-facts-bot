using DoggyFactsBot.BotAssets;
using DoggyFactsBot.Configuration;
using DoggyFactsBot.DogFacts;
using NLog;
using NLog.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DoggyFactsBot.BotControllers;

public class UpdateHandler
{
    private readonly Logger _logger = LogManager
        .Setup()
        .LoadConfigurationFromSection(NlogConfig.Config)
        .GetCurrentClassLogger();

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;

        var chatId = message!.Chat.Id;
        _logger.Info($"Received a '{message.Text}' message in chat {chatId}.");

        switch (message.Text!)
        {
            case "/start":
                await botClient.SendTextMessageAsync(message.Chat,
                    "ʀᴇᴀᴅʏ ꜰᴏʀ ꜱᴏᴍᴇ ᴅᴏɢɢʏ ꜰᴀᴄᴛꜱ? ᴜꜱᴇ ᴛʜᴇ ʙᴜᴛᴛᴏɴ ꜰᴏʀ ᴀ ᴛʀᴇᴀᴛ!",
                    replyMarkup: ReplyOptions.ReplyMarkupGimmeFact,
                    cancellationToken: cancellationToken);

                await botClient.SendStickerAsync(message.Chat, StickerManager.MuffinHelloStickerId,
                    cancellationToken: cancellationToken);
                break;

            case "ɢɪᴍᴍᴇ ᴀ ᴅᴏɢɢʏ ꜰᴀᴄᴛ!":
                var fact = await DogFactsProvider.GiveFactAsync();
                
                await botClient.SendTextMessageAsync(message.Chat, fact,
                    cancellationToken: cancellationToken,
                    replyMarkup: ReplyOptions.ReplyMarkupAnotherOne);
                break;
            
            case "ᴀɴᴅ ᴀɴᴏᴛʜᴇʀ ᴏɴᴇ!":
                fact = await DogFactsProvider.GiveFactAsync();
                
                await botClient.SendTextMessageAsync(message.Chat, fact,
                    cancellationToken: cancellationToken,
                    replyMarkup: ReplyOptions.ReplyMarkupGimmeFact);
                break;
            
            default:
                await botClient.SendTextMessageAsync(message.Chat, "ᴡᴇ ʜᴇʀᴇ ᴏɴʟʏ ɢᴇᴛ ʙᴜᴛᴛᴏɴ ᴀᴄᴛɪᴏɴꜱ, ꜱᴏ ᴛᴀᴋᴇ ʏᴏᴜʀ ᴘᴀᴡꜱ ᴛʜᴇʀᴇ!",
                    replyMarkup: ReplyOptions.ReplyMarkupGimmeFact,
                    cancellationToken: cancellationToken);
                break;
        }
    }
}
