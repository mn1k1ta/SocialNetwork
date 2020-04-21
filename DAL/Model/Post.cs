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
        public int UserProfileId { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
