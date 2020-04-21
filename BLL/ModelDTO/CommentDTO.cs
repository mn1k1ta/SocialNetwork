using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Img { get; set; }
        public DateTime DateTime { get; set; }       
    }
}
