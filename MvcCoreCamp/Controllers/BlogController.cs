
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());

        public IActionResult Index()
        {
            var values = bm.GetBlogByCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.TGetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByAuthor()
        {
            var values = bm.TGetListCategoryByAuthor(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryvalues = (from x in cm.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.AuthorID = 1;
                bm.TInsert(p);
                return RedirectToAction("BlogListByAuthor", "Blog");
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


        public IActionResult DeleteBlog(int id)
        {
            var values = bm.TGetByID(id);
            bm.TDelete(values);
            return RedirectToAction("BlogListByAuthor");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var values = bm.TGetByID(id);
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryvalues = (from x in cm.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();




            ViewBag.cv = categoryvalues;
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog p)
        {
            p.AuthorID = 1;
            p.Status = true;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TUpdate(p);
            return RedirectToAction("BlogListByAuthor");
        }
    }
}
