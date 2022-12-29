using Microsoft.AspNetCore.SignalR;

namespace SignalRWebApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatHistory _chatHistory;

        public ChatHub(ChatHistory chatHistory)
        {
            _chatHistory = chatHistory;
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
            _chatHistory.AddToHistory(message);
        }

        public async Task GetHistory()
        {
            // Clients.Caller
            // Clients.Others
            await Clients.All.SendAsync("ReceiveHistory", _chatHistory.GetHistory());
        }
    }
}
