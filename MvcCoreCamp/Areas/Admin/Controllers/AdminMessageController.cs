using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Areas.Admin.Controllers
{


    [Area("Admin")]
    [AllowAnonymous]
    public class AdminMessageController : Controller
    {
        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var authorID = c.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorID).FirstOrDefault();
            var values = mm.GetInboxListByAuthor(authorID);
            return View(values);
        }


        public IActionResult SendBox()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var authorID = c.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorID).FirstOrDefault();
            var values = mm.GetSendboxByAuthor(authorID);
            return View(values);
        }

        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
