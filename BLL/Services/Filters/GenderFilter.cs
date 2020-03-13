using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public class GenderFilter : IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }

        public GenderFilter(string gender)
        {
            if (gender != null)
                Filter = num => !string.IsNullOrEmpty(num.Gender) ? num.Gender == gender : false;
        }
    }
}
