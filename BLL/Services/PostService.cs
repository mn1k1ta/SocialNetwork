using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService:IPostService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public PostService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> CreatePostAsync(PostDTO postDTO, int userProfileDTOid)
        {
            if (postDTO == null)
                return new OperationDetails(false, "Post is null", "Post");            
            var userProfile = await _database.userProfileRepository.GetByIdAsync(userProfileDTOid);
            if (userProfile == null)
                return new OperationDetails(false, "UserProfile is null", "UserProfile");
            var post = _mapper.Map<Post>(postDTO);
            post.UserProfile = userProfile;
            post.DateTime = DateTime.Now;
            _database.postRepository.Create(post);
            await _database.SaveAsync();
            return new OperationDetails(true, "Post is CREATED", "Create");                      
        }

        public async Task<OperationDetails> DeletePostAsync(int id)
        {
            var post = await _database.postRepository.GetByIdAsync(id);
            if (post == null)
                return new OperationDetails(false, "Post with this id is null!", "Post");
            _database.postRepository.Delete(post);
            await _database.SaveAsync();
            return new OperationDetails(true, "Post is deleted!", "Post");
        }

        public async Task<ICollection<PostDTO>> GetAllPost()
        {
            var posts = await _database.postRepository.GetAllAsync();
            if (posts == null)
                throw new UserException(false, "Post is null", "Post");
            return _mapper.Map<ICollection<PostDTO>>(posts);
                                                
        }

        public async Task<ICollection<PostDTO>> GetAllPostByUser(int userId)
        {
            var posts = await _database.postRepository.GetWhereAsync(p => p.UserProfile.UserProfileId == userId);
            if(posts==null)
                throw new UserException(true, "Post with this user is NULL!", "GetByUser");
            return _mapper.Map<ICollection<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostById(int postId)
        {
            var post = await _database.postRepository.GetByIdAsync(postId);
            if (post == null)
                throw new UserException(true, "Post with this id is NULL!","GetById");
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<OperationDetails> UpdatePostAsync(PostDTO postDTO)
        {
            var post = await _database.postRepository.GetByIdAsync(postDTO.PostId);
            if (post == null)
                return new OperationDetails(false, "User is not found!", "Update");
            _database.postRepository.Update(_mapper.Map(postDTO,_mapper.Map<Post>(post)));
            await _database.SaveAsync();
            return new OperationDetails(true, "User is UPDATED", "Update");
        }
     
        public async Task<ICollection<PostDTO>> GetPostByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new UserException(false, "Name is Null!", "Name");
            var posts = await _database.postRepository.GetWhereAsync(p => p.PostName.Contains(name));
            return _mapper.Map<ICollection<PostDTO>>(posts);

            
        }

    }
}
