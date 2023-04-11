
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<AppUser> _userManager;

        public AuthorController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        public async Task<IActionResult> UpdateAuthorProfile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAuthorProfile(UserUpdateViewModel upvm)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.NameSurname = upvm.namesurname;
            values.ImageUrl = upvm.imageurl;
            values.Email = upvm.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, upvm.password);

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "UpdateAuthorProfile");
            }


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

        public async Task<IActionResult> LogOut()
        {
            return View();
        }
    }
}
