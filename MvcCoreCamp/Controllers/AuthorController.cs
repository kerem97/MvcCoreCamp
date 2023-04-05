﻿
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCamp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        Context c = new Context();

        AuthorManager atm = new AuthorManager(new EfAuthorDal());
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;

            var authorname = c.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorName).FirstOrDefault();
            ViewBag.v2 = authorname;
            return View();
        }

        public PartialViewResult AuthorNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AuthorFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult UpdateAuthorProfile()
        {
            var usermail = User.Identity.Name;
            var authorID = c.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorID).FirstOrDefault();
            var values = atm.TGetByID(authorID);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAuthorProfile(Author p)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                p.AuthorStatus = true;
                atm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]

        public IActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddAuthor(AddProfileImage p)
        {
            Author a = new Author();
            if (p.AuthorImage != null)
            {
                var extension = Path.GetExtension(p.AuthorImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AuthorImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.AuthorImage.CopyTo(stream);
                a.AuthorImage = newImageName;
            }
            a.Mail = p.Mail;
            a.AuthorName = p.AuthorName;
            a.Password = p.Password;
            a.AuthorStatus = true;
            a.AuthorAbout = p.AuthorAbout;
            atm.TInsert(a);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
