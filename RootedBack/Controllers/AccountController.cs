using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RootedBack.Models;
using System.Security.Claims;

namespace RootedBack.Controllers
{
    public class AccountController : Controller
    {
        private readonly RootedDBContext _context;
        public AccountController(RootedDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Farmers.ToList());
        }
        public IActionResult FCreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FCreateAccount(Farmer model)
        {
            //check if model is valid to create account for farmer
            if (ModelState.IsValid) {
                Farmer farmer = new Farmer();
                farmer.Name = model.Name;
                farmer.Email = model.Email;
                farmer.Password = model.Password;
                farmer.PhoneNumber = model.PhoneNumber;
                farmer.Location = model.Location;
                farmer.Description = model.Description;
                farmer.Certificate = model.Certificate;
                //farmer.VerificationStatus = "Pending";
                farmer.ImageUrl = model.ImageUrl;
                farmer.UserName = model.UserName;
                //save to database
                try
                {
                    _context.Farmers.Add(farmer);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = "thank you for applying ,your application will be varified please wait for message";
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "please choose a unique email or username ");
                    return View();
                }

                return View();


            }
            return View(model);
        }
        public IActionResult login() {
            return View();
        }
        [HttpPost]
        public IActionResult login(Farmer model)
        {
            if (ModelState.IsValid) {
                var user = _context.Farmers.Where(x => (x.UserName == model.UserName || x.Email==model.Email)&& x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    //login success
                    var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(ClaimTypes.Role,"Farmer"),
                    };
                    var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Identity));
                    return RedirectToAction("Secure");
                }
                else {
                    ModelState.AddModelError("","Username or Email or Password is incorroct!"); }
            }
            return View(model);
        }
        public IActionResult logout() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Secure() {

            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
