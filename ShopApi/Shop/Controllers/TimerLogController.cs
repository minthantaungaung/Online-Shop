using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class TimerLogController : Controller
    {
        ShopContext db = new ShopContext();
        public IActionResult Index()
        {
            return View();
        }
        [Route("api/TimerLog/UpdateLog")]
        [HttpGet]
        public void UpdateLog(string MemberEmail = null, string ClosedDate = null)
        {
            DateTime dt = Convert.ToDateTime(ClosedDate);
            TimerLog log = new TimerLog() 
            {
                Accesstime = DateTime.Now,
                MemberEmail = MemberEmail,
                ClosedDate = dt,
            };
            db.TimerLog.Add(log);
            db.SaveChanges();
        }
    }
}
