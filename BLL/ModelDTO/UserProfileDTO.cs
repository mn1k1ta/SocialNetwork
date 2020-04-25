using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class UserProfileDTO
    {
        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Sity { get; set; }
        public string AboutMe { get; set; }
        public string MaritalStatus { get; set; }
        public string Img { get; set; }
        public string AplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
