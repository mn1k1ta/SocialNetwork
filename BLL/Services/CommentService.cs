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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OperationDetails> CreateCommentAsync(CommentDTO commentDTO, int postId)
        {
            if (commentDTO == null)
                return new OperationDetails(false, "Comment is null", "Comment");
            var post = await _database.postRepository.GetByIdAsync(postId);
            if (post == null)
                return new OperationDetails(false, "Post eith this id is null", "PostId");
            var comment = _mapper.Map<Comment>(commentDTO);
            comment.Post = post;
            _database.commentRepository.Create(comment);
            await _database.SaveAsync();
            return new OperationDetails(true, "Comment is created","CommentCreate");
        }
        public async Task<OperationDetails> DeleteCommentAsync(int commentId)
        {
            var comment = await _database.commentRepository.GetByIdAsync(commentId);
            if (comment == null)
                return new OperationDetails(false, "User is not deleted", "Delete");
            _database.commentRepository.Delete(comment);
            await _database.SaveAsync();
            return new OperationDetails(true, "Deleted is Completed", "Deleted");

        }

        public async Task<ICollection<CommentDTO>> GetAllComentsAsync()
        {
            var comments = await _database.commentRepository.GetAllAsync();
            if (comments.Count == 0)
                throw new UserException(false, "Comments is null", "Comments");
            return _mapper.Map<ICollection<CommentDTO>>(comments);
        }

        public async Task<ICollection<CommentDTO>> GetAllCommentsByPostAsync(int postId)
        {
            var post = await _database.postRepository.GetByIdAsync(postId);
            if (post == null)
                throw new UserException(false, "POst with this id is not found", "GetlAllPost");
            return _mapper.Map<ICollection<CommentDTO>>(await _database.commentRepository.GetWhereAsync(c => c.PostId == postId));
        }

        public async Task<CommentDTO> GetCommentById(int commentId)
        {
            var comment = await _database.commentRepository.GetByIdAsync(commentId);
            if (comment == null)
                throw new UserException(false, "Comment with this id is null", "Comment");
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task<OperationDetails> UpdateCommentAsync(CommentDTO commentDTO)
        {
            if(commentDTO==null)
                return new OperationDetails(false, "Comment  is null", "UpdateComment");
            var comment = await _database.commentRepository.GetByIdAsync(commentDTO.CommentId);
            if (comment == null)
                return new OperationDetails(false, "Comment with this id is null","UpdateComment");
            _database.commentRepository.Update(_mapper.Map(commentDTO, comment));
            await _database.SaveAsync();
            return new OperationDetails(true, "User is Updated", "Update");

        }
    }
}
