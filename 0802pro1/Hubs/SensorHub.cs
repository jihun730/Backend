using Microsoft.AspNetCore.SignalR;

namespace _0802pro1.Hubs
{
    public class SensorHub : Hub
    {
        public async Task SendCamera1(string message)
        {
            await Clients.All.SendAsync("ReceiveCamera1", message);
        }

        public async Task SendCamera2(string message)
        {
            await Clients.All.SendAsync("ReceiveCamera2", message);
        }

        // 초음파 센서
        public async Task SendWave1(string message)
        {
            await Clients.All.SendAsync("ReceiveWave1", message);
        }

        public async Task SendWave2(string message)
        {
            await Clients.All.SendAsync("ReceiveWave2", message);
        }

    }
}
