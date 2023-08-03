using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _0802pro1.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;

        public AuthController(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string pw)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, pw, false, false);
            if (result.Succeeded)
            {
                Console.WriteLine("로그인 성공");
                return Redirect("/mes/index");
            }

            return Redirect("/auth/login");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string userId, string password, string userEmail, string userNick)
        {
            var user = new MyIdentityUser { UserName = userId, UserNickname = userNick, Email = userEmail };
            var result = await _userManager.CreateAsync(user, password);

            return Redirect("/auth/login");

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/mes/index");
        }
    }
}
