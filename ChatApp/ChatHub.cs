using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SentAt = DateTimeOffset.Now,
            };

            // Broadcast to all clients
            await Clients.All.SendAsync("ReceivedMessage",
                                        message.SenderName,
                                        message.SentAt,
                                        message.Text);
        }
    }
}
