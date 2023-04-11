using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var values = bm.GetBlogByCategory();
            return View(values);
        }
    }
}
