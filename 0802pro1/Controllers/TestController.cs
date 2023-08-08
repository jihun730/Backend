using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _0802pro1.Controllers
{
    public class TestController : Controller
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;

        public TestController(
            UserManager<MyIdentityUser> userManager, 
            SignInManager<MyIdentityUser> signInManager)
        {
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string name, string pw, string email)
        {
            var user = new MyIdentityUser { UserName = name, Email = email };
            var result = await _userManager.CreateAsync(user, pw);

            return Redirect("/home/index");

        }

        [HttpGet]
        public IActionResult Login() {
            return View("login");
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
    }
}
