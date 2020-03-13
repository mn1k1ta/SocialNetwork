using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }       
    }
}
