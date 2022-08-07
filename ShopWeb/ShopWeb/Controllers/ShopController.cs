using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.ApiRepo;
using ShopWeb.Models;

namespace ShopWeb.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddNewShop(Shop shop)
        {
            if (shop.Email == null && shop.PhoneNo == null)
            {
                ViewBag.Alert = "No";
            }
            else
            {
                var url = "api/shop/PostTodoItem";
                Shop newshop = new Shop();
                newshop = shop;

                Shop result = await ApiRequest<Shop>.Post(url, shop);
                if (result != null)
                {
                    ViewBag.Alert = "OK";
                }
                else
                {
                    ViewBag.Alert = "NO";
                }
            }
            return RedirectToAction("Index");
        }

    }
}