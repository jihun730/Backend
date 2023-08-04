using Microsoft.AspNetCore.SignalR;

namespace _0802pro1.Hubs
{
    public class RailHub : Hub
    {
        public async Task SendRail1(string message)
        {
            await Clients.All.SendAsync("ReceiveRail1", message);
        }
        public async Task SendRail2(string message)
        {
            await Clients.All.SendAsync("ReceiveRail2", message);
        }
    }
}
