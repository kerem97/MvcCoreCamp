using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCamp.Models
{
    public class AddProfileImage
    {
        public int AuthorID { get; set; }

        public string AuthorName { get; set; }

        public string AuthorAbout { get; set; }

        public IFormFile AuthorImage { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }

        public bool AuthorStatus { get; set; }
    }
}
