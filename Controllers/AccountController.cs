using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyStat.Models;
using MyStat.ViewModels;
using System.Security.Claims;
using MyStat.Services;
using Microsoft.EntityFrameworkCore;

namespace MyStat.Controllers
{
    public class AccountController : Controller
    {
        private MyStatDbContext _context;

        public AccountController(MyStatDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            //var claim = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimsIdentity.DefaultNameClaimType);

            //if (claim != null)
            //{
            //    User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == claim.Value);


            //    if (user != null)
            //    {
            //        ViewBag.UserId = user.Id;
            //    }
            //}

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel? model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);
                
                if (user != null)
                {
                    await Authenticate(user); // аутентификация


                    //  var userId = _context.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Id).FirstOrDefault();

                    ViewBag.UserId = user.Id;

                    return RedirectToAction("Add", "Homework", routeValues: new
                    {
                        Id = user.Id
                    });   
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

                if (user == null)
                {
                    _context.Users.Add(new User { UserName = model.UserName, Password = model.Password });

                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Add", "Homework");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }

            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
            };

            ClaimsIdentity id = new (claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
