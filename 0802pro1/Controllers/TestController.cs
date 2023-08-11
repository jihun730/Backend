using _0802pro1.Data;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _0802pro1.Controllers
{
    public class TestController : Controller
    {
        private readonly MyDBContext dbContext;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;

        public TestController(
            MyDBContext dbContext,
            UserManager<MyIdentityUser> userManager, 
            SignInManager<MyIdentityUser> signInManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Signalr()
        {
            return View("Signalr");
        }

        [HttpGet]
        public IActionResult SignalrPicture()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> Signup(string name, string pw, string email)
        {
            var user = new MyIdentityUser { UserName = name, Email = email };
            var result = await _userManager.CreateAsync(user, pw);

            return Redirect("/home/index");

        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string pw)
        {
            
            var result = await _signInManager.PasswordSignInAsync(userName, pw, false, false);
            if (result.Succeeded)
            {
                Console.WriteLine("로그인 성공");
                return Redirect("/home/index");
            }

            return Redirect("/test/login");
        }

        [HttpGet]
        public IActionResult Colors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Borders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Animations()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Other()
        {
            return View();
        }
        [HttpGet]
        public IActionResult IndexTest()
        {
            return View();
        }
    }
}
