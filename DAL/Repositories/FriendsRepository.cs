using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FriendsRepository : BaseRepository<Friends>,IFriendsRepository
    {
        public FriendsRepository(DbContext context) : base(context)
        {

        }
    }
}
