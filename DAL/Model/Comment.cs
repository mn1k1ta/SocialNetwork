using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Comment
    {
        public int CommentId { get; set; }        
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
