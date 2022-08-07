using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.ApiRepo;
using ShopWeb.Models;

namespace ShopWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(Members mem)
        {
            if (mem == null)
            {
                ViewBag.Alert = "No";
                return RedirectToAction("Index");
            }
            else
            {
                var url = "api/member/AddMember";
                Members result = await ApiRequest<Members>.Post(url, mem);
                if (result != null)
                {
                    return RedirectToAction("Login_Register");
                }
                else
                {
                    ViewBag.Alert = "NO";
                    return RedirectToAction("Index");
                }
            }
        }
        public async Task<IActionResult> Login(string Email, string Pwd)
        {
            string url = string.Format("api/Member/Login?Email={0}&Pwd={1}", Email, Pwd);
            Members result = await ApiRequest<Members>.Get(url);
            string mail = result.Email;
            string password = result.Password;
            if (Email == mail && password == Pwd) {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,result.Name),
                    new Claim(ClaimTypes.Email,mail),
                    new Claim(ClaimTypes.Role,"Norm"),
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(50),
                    IssuedUtc = DateTimeOffset.UtcNow
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
            }
            return Json("OK");
        }
        public IActionResult FBLogin()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }
        public async Task<string> ConfirmEmail(string Email = null)
        {
            string url = string.Format("api/Member/checkEmail?Email={0}", Email);
            string result = await ApiRequest<string>.Get(url);
            if (result == "true")
            {
                return "Yes";
            }
            else if(result == "false")
            {
                return "No";
            }
            else
            {
                return result;
            }
        }
    }
}