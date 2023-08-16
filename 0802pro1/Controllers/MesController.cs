using _0802pro1.Data;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _0802pro1.Controllers
{
    public class MesController : Controller
    {
        private readonly MyDBContext dbContext;
        private readonly UserManager<MyIdentityUser> userManager;

        public MesController(MyDBContext dbContext,
            UserManager<MyIdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Console.WriteLine("테스트 : " + user);
            return await Task.Run(() => View(dbContext.Products.ToList()));
        }

        [HttpGet]
        public IActionResult Add(ProductModel model)
        {
            model.MyIdentityUserId = userManager.GetUserId(HttpContext.User);
            model.ProductName = "불량 컵";
            model.ProductQuantity = 1;
            var result = dbContext.Add(model);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(ProductModel model)
        {
            var proName = "정상 종이컵";
            if (proName == "정상 종이컵")
            {
                var result = dbContext.Products.Where(p => p.ProductName == proName).FirstOrDefault();
                result.ProductQuantity += 1;
                dbContext.SaveChanges();
            }
            else if (proName == "불량 종이컵")
            {
                var result = dbContext.Products.Where(p => p.ProductName == proName).FirstOrDefault();
                result.ProductQuantity += 1;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Reset(ProductModel model)
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    var proName = "정상 종이컵";
                    var result = dbContext.Products.Where(p => p.ProductName == proName).FirstOrDefault();
                    result.ProductQuantity = 0;
                    dbContext.SaveChanges();
                }
                else if (i==1)
                {
                    var proName = "불량 종이컵";
                    var result = dbContext.Products.Where(p => p.ProductName == proName).FirstOrDefault();
                    result.ProductQuantity = 0;
                    dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public string Get()
        {

            string result = "{";
            foreach (var product in dbContext.Products)
            {
                Console.WriteLine(product.ProductName + "  " + product.ProductQuantity);
                result += "\"nomal" + product.Id + "\":" + product.ProductQuantity + ",";
                result += "\"error" + product.Id + "\":" + product.ProductQuantity + ",";
            }

            result = result.Substring(0, result.Length - 1) + "}";

            return result;
        }

        public IActionResult Privacy()
        {

            return View(dbContext.Products.ToList());
        }

        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Error404()
        {
            return View("Error404");
        }
        [HttpGet]
        public IActionResult Buttons()
        {
            return View();
        }
    }
}
