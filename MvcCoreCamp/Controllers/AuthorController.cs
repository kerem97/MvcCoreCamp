
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [AllowAnonymous]
    public class AuthorController : Controller
    {

        public IActionResult Index()
        {
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

    }
}
