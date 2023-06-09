﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{

    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        Context c = new Context();
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
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = mm.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var authorID = c.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorID).FirstOrDefault();
            p.SenderID = authorID;
            p.ReceiverID = 4;
            p.Status = true;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TInsert(p);
            return RedirectToAction("Inbox", "Message");
        }
    }
}
