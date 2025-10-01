using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Villa.Dto.Dtos.IdentityDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerdto)
        {  
            var user = new AppUser
            {
                NameSurname = registerdto.NameSurname,
                Email = registerdto.Email,
                UserName = registerdto.UserName
            };
            var result = await _userManager.CreateAsync(user,registerdto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();

            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            return RedirectToAction("Index", "Banner");
        }
    }
}
