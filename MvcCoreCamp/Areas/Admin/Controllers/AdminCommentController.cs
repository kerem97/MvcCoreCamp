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
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            var values = cm.TGetListWithBlog();
            return View(values);
        }
    }
}
