using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
