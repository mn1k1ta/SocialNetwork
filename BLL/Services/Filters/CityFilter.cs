using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public class CityFilter : IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }

        public CityFilter(string city)
        {
            if (city != null)              
                Filter = num => !string.IsNullOrEmpty(num.Sity) ? num.Sity.Contains(city) : false;
        }
    }
}
