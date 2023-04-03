using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.ViewComponents.Author
{
    public class AuthorAboutOnDashboard : ViewComponent
    {
        AuthorManager atm = new AuthorManager(new EfAuthorDal());
        public IViewComponentResult Invoke()
        {
            var values = atm.GetAuthorById(1);
            return View(values);
        }
    }
}
