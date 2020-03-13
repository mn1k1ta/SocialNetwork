using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        SignInManager<ApplicationUser> signInManager { get; }
        ApplicationRoleManager aplicationRole { get; }
        ApplicationUserManager applicationUser { get; }
        IUserProfileRepository userProfileRepository { get; }
        ICommentRepository commentRepository { get; }
        IPostRepository postRepository { get; }
        IFriendsRepository friendsRepository { get; }
        Task SaveAsync();
        

    }
}
