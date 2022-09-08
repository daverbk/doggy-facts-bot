using DoggyFactsBot.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DoggyFactsBot.BotAssets;

public class StickerManager
{
    public static StickerSet MuffinSet { get; private set; } = null!;

    public static string MuffinHelloStickerId { get; private set; } = null!;

    public async Task SetUpStickers(ITelegramBotClient botClient)
    {
        const int helloStickerIndex = 4;
        
        MuffinSet =  await botClient.GetStickerSetAsync(Config.MuffinStickerSet);
        MuffinHelloStickerId = MuffinSet.Stickers[helloStickerIndex].FileId;
    }
}
