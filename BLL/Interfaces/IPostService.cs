using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        Task<OperationDetails> CreatePostAsync(PostDTO postDTO,int userProfileDTOId);
        Task<OperationDetails> DeletePostAsync(int id);
        Task<OperationDetails> UpdatePostAsync(PostDTO postDTO);
        Task<ICollection<PostDTO>> GetAllPost();
        Task<PostDTO> GetPostById(int postId);
        Task<ICollection<PostDTO>> GetAllPostByUser(int userId);
        Task<ICollection<PostDTO>> GetPostByNameAsync(string name);


    }
}
