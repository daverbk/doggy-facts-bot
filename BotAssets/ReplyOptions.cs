using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DoggyFactsBot.BotAssets;

public static class ReplyOptions
{
    public static readonly ReceiverOptions ReceiverOptions = new()
    {
        AllowedUpdates = new[] { UpdateType.Message }
    };
    
    public static readonly ReplyKeyboardMarkup ReplyMarkupGimmeFact = new(new[]
    {
        new KeyboardButton[] {"ɢɪᴍᴍᴇ ᴀ ᴅᴏɢɢʏ ꜰᴀᴄᴛ!"}
    })
    {
        ResizeKeyboard = true
    };
    
    public static readonly ReplyKeyboardMarkup ReplyMarkupAnotherOne = new(new[]
    {
        new KeyboardButton[] {"ᴀɴᴅ ᴀɴᴏᴛʜᴇʀ ᴏɴᴇ!"}
    })
    {
        ResizeKeyboard = true
    };
}
