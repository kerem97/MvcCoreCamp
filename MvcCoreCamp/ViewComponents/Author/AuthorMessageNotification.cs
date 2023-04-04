using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.ViewComponents.Author
{
    public class AuthorMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = mm.GetInboxListByAuthor(id);


            return View(values);
        }
    }
}
