﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
