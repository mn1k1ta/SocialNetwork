using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
}
