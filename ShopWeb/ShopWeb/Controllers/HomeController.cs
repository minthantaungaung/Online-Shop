using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWeb.ApiRepo;
using ShopWeb.Models;

namespace ShopWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> _PopularItems()
        {
            var url = "api/shop/Products";
            List<Products> result = await ApiRequest<List<Products>>.Get(url);
            return PartialView(result);            
         }

        public async void TimerLog(string closedDate)
        {
            string email = getMemberEmail();
            string url = string.Format("api/TimerLog/UpdateLog?MemberEmail={0}&closedDate={1}", email, closedDate);
            TimerLog result = await ApiRequest<TimerLog>.Get(url);
        }

        public string getMemberEmail()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            return email;
        }
    }
}
