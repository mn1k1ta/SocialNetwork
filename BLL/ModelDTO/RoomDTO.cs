using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
}
