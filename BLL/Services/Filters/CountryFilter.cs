using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public class CountryFilter : IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }

        public CountryFilter(string country)
        {
            if (country != null)               
                Filter = num => !string.IsNullOrEmpty(num.Country) ? num.Country.Contains(country) : false;
        }
    }
}
