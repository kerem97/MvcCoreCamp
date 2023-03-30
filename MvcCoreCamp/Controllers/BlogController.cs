
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());

        public IActionResult Index()
        {
            var values = bm.GetBlogByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogDetails(int id)
        {
            var values = bm.TGetByID(id);
            return View(values);
        }

    }
}
