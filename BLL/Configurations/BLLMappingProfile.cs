using AutoMapper;
using BLL.ModelDTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Configurations
{
    public class BLLMappingProfile:Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Friends, FriendsDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
        }
    }
}
