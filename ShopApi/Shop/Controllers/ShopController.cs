using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        ShopContext db = new ShopContext();
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Shops>> Get()
        {
            var ET = db.Shops.Where(s => s.IsDeleted != true).ToList();
            return Ok(ET);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Shops>> Products()
        {
            var product = db.Products.Where(s => s.IsDeleted != true).ToList();
            return Ok(product);
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<string> PostTodoItem(Shops newshop)
        {
            db.Shops.Add(newshop);
            db.SaveChanges();
            return Ok(newshop);
        }
    }
}