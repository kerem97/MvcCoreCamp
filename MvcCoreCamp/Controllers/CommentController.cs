using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{

    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialCommentListByBlog(int id)
        {
            var values = cm.TGetList(id);
            return PartialView(values);
        }
        public PartialViewResult PartialAddcomment()
        {
            return PartialView();
        }
    }
}
