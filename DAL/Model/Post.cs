using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
