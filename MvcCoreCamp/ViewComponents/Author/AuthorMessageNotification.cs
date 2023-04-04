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
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "murat@gmail.com";
            var values = mm.GetInboxListByAuthor(p);

          
            return View(values);
        }
    }
}
