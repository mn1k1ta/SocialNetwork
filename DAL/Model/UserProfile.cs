using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }        
        public string Country { get; set; }
        public string Sity { get; set; }
        public string AboutMe { get; set; }
        public string MaritalStatus { get; set; }
        public string Img { get; set; }
        public string AplicationUserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Friends> Friends { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
