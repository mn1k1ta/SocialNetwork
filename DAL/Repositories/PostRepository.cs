using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepository : BaseRepository<Post>,IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {

        }
    }
}
