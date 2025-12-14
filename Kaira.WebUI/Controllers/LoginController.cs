using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kaira.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // Giriş Sayfasını Göster
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string kadi, string sifre)
        {
        
            if (kadi == "admin" && sifre == "12345")
            {
 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kadi),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true 
                };

                
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                
                return RedirectToAction("Index", "Category"); 
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        // Çıkış Yapma İşlemi
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}