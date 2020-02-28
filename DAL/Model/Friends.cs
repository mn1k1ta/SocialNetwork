using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Friends
    {
        public int FriendsId { get; set; }
        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int FriendId { get; set; }
  
    }
}
