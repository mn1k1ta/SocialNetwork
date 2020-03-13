using DAL.Identity;
using DAL.Interfaces;
using DAL.Model;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly SocialNetworkDbContext _context;
        private IUserProfileRepository _userProfileRepository;
        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;
        private IFriendsRepository _friendsRepository;

        public UnitOfWork(SocialNetworkDbContext context,
          ApplicationRoleManager applicationRoleManager,
          ApplicationUserManager applicationUserManager,
          SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
            applicationUser = applicationUserManager;
            aplicationRole = applicationRoleManager;
            _context = context;
        }
        public SignInManager<ApplicationUser> signInManager { get; }
        public ApplicationRoleManager aplicationRole { get; }
        public ApplicationUserManager applicationUser { get; }

        public IUserProfileRepository userProfileRepository
        {
            get
            {
                if (_userProfileRepository == null)
                    _userProfileRepository = new UserProfileRepository(_context);
                return _userProfileRepository;
            }
        }

        public ICommentRepository commentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);
                return _commentRepository;
            }
        }

        public IPostRepository postRepository
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_context);
                return _postRepository;
            }
        }

        public IFriendsRepository friendsRepository
        {
            get
            {
                if (_friendsRepository == null)
                    _friendsRepository = new FriendsRepository(_context);
                return _friendsRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
