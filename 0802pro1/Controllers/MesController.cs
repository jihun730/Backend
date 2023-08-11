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
            Console.WriteLine("테스트 : "+user);
            return await Task.Run(() => View(dbContext.Products.ToList()));
        }

        public IActionResult Privacy()
        {
            
            return View(dbContext.Products.ToList());
        }

        [HttpGet]
        public IActionResult Buttons()
        {
            return View();
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


    }
}
