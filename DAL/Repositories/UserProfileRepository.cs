using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {

        }
    }
}
