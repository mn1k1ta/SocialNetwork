using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public class AgeFilter : IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }

        public AgeFilter(int minAge, int maxAge)
        {
            if (minAge != 0 && maxAge != 0)
                Filter = u => ((DateTime.Now.Year - u.Birthday.Year) <= maxAge) && ((DateTime.Now.Year - u.Birthday.Year) >= minAge);
            
        }
    }
}
