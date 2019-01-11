using System.Threading.Tasks;

namespace SignalR.Contracts
{
    public class ChatHub: Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string user, string message)
        {
            string[] args = new string[] { user, message };
            await Clients.All.SendCoreAsync("ReceiveMessage", args);
        }
    }
}
