using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<OperationDetails> CreateCommentAsync(CommentDTO commentDTO,int postId);
        Task<OperationDetails> UpdateCommentAsync(CommentDTO commentDTO);
        Task<OperationDetails> DeleteCommentAsync(int commentId);
        Task<ICollection<CommentDTO>> GetAllComentsAsync();
        Task<ICollection<CommentDTO>> GetAllCommentsByPostAsync(int postId);
        Task<CommentDTO> GetCommentById(int commentId);

    }
}
