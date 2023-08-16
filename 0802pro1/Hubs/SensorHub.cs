using _0802pro1.Data;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace _0802pro1.Hubs
{
    public class SensorHub : Hub
    {
        private readonly MyDBContext dbContext;
        private readonly UserManager<MyIdentityUser> userManager;

        public SensorHub(MyDBContext dbContext, UserManager<MyIdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task SendCamera1(string message)
        {
            await Clients.All.SendAsync("ReceiveCamera1", message);
        }

        public async Task SendCamera2(string message)
        {
            await Clients.All.SendAsync("ReceiveCamera2", message);
        }

        // 초음파 센서
        public async Task SendWave1(int distanceW1)
        {   
            if (distanceW1 < 20)
            {
                Console.WriteLine("정상 종이컵 1개 증가");
                var model = new ProductModel();
                model.ProductName = "정상 종이컵";
                model.ProductQuantity = 1;

                var result = dbContext.Products.Where(p => p.ProductName == model.ProductName).FirstOrDefault();
                if (result != null)
                {
                    result.ProductQuantity += 1;
                } else
                {
                    dbContext.Add(model);
                }
                dbContext.SaveChanges();

            }
            await Clients.All.SendAsync("ReceiveWave1", distanceW1);
        }

        public async Task SendWave2(int distanceW2)
        {
            if (distanceW2 < 20)
            {
                Console.WriteLine("불량 종이컵 1개 증가");
                var model = new ProductModel();
                model.ProductName = "불량 종이컵";
                model.ProductQuantity = 1;

                var result = dbContext.Products.Where(p => p.ProductName == model.ProductName).FirstOrDefault();
                if (result != null)
                {
                    result.ProductQuantity += 1;
                }
                else
                {
                    dbContext.Add(model);
                }
                dbContext.SaveChanges();

            }
            await Clients.All.SendAsync("ReceiveWave2", distanceW2);
        }

        // test
        public async Task SendStatus(string message)
        {
            await Clients.All.SendAsync("ReceiveStatus", message);
        }

    }
}
