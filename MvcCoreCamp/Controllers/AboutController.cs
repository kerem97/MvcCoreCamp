using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var values = abm.TGetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {

            return PartialView();
        }
    }
}
