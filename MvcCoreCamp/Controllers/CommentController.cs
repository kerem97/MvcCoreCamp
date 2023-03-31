using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialCommentListByBlog()
        {
            return PartialView();
        }
        public PartialViewResult PartialAddcomment()
        {
            return PartialView();
        }
    }
}
