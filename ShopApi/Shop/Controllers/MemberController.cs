using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Manager;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Route("api/Member/AddMember")]
        [HttpPost]
        public ActionResult<string> AddMember(Member mem)
        {
            MemberManager memMgr = new MemberManager();
            Member result = memMgr.Add(mem);
            return Ok(result);
        }

        [Route("api/Member/Login")]
        [HttpGet]
        public ActionResult<Member> Login(string Email,string Pwd)
        {
            MemberManager memMgr = new MemberManager();
            Member result = memMgr.Login(Email,Pwd);
            return Ok(result);
        }

        [Route("api/Member/checkEmail")]
        [HttpGet]
        public ActionResult<string> checkEmail(string Email)
        {
            MemberManager memMgr = new MemberManager();
            string result = memMgr.CheckEmail(Email);
            return Ok(result);
        }
    }
}