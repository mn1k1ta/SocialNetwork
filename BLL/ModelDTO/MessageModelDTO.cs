using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
    public class MessageModelDTO
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public DateTime Date { get; set; }
        public string Img { get; set; }
    }
}
