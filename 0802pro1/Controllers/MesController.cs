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
                Console.WriteLine(result);
                result.ProductQuantity += 1;
                dbContext.SaveChanges();
            }
            else if (proName == "불량 종이컵")
            {
                var result = dbContext.Products.Where(p => p.ProductName == proName).FirstOrDefault();
                model.ProductQuantity += 1;
            }
            return RedirectToAction("Index");
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
