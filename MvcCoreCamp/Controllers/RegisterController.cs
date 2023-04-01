using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Author p)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                p.AuthorStatus = true;
                p.AuthorAbout = "Deneme";
                authorManager.TInsert(p);
                return RedirectToAction("Index", "Blog");
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
    }
}
