﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Controllers
{
    public class AuthorController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

    }
}