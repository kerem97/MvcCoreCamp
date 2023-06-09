﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int BlogRate { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }

    }
}
