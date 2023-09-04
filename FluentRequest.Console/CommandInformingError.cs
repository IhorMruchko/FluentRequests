using FluentRequests.Lib.Validation.Error;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FluentRequest.Console
{
    internal class TelegramInforming : Informing
    {
        private readonly ITelegramBotClient _client;
        
        public Message? Message {get; set;}

        public TelegramInforming(ITelegramBotClient client)
        {
            _client = client;
        }

        public override async void OnError(string errorMessage)
        {
            if (Message is null)
            {
                return;
            }

            await _client.SendTextMessageAsync(Message.Chat.Id, errorMessage);
        }
    }
}
