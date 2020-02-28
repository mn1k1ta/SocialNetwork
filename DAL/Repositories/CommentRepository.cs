using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CommentRepository : BaseRepository<Comment>,ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
              
        }
    }
}
