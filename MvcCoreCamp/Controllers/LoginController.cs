using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Author p)
        {
            Context c = new Context();
            var datavalue = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name,p.Mail)
            };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Author");
            }
            else
            {
                return View();
            }

        }

    }
}

//Context c = new Context();
//var datavalue = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", p.Mail);
//    return RedirectToAction("Index", "Author");
//}
//else
//{
//    return View();
//}
