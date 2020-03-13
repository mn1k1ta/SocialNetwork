using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public interface IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }
    }
}
