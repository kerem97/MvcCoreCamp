using Microsoft.AspNetCore.Mvc;
using MvcCoreCamp.Areas.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            var jsonAuthors = JsonConvert.SerializeObject(authors);
            return Json(jsonAuthors);
        }

        public IActionResult GetAuthorByID(int authorid)
        {
            var findAuthor = authors.FirstOrDefault(x => x.ID == authorid);
            var jsonAuthors = JsonConvert.SerializeObject(findAuthor);
            return Json(jsonAuthors);
        }

        public static List<AuthorClass> authors = new List<AuthorClass>
        {
            new AuthorClass
            {
                ID=1,
                Name="Ayşe"
            },
            new AuthorClass
            {
                ID=2,
                Name="Ahmet"
            }
        };
    }
}
