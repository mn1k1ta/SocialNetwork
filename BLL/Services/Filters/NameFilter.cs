using DAL.Model;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Filters
{
    public class NameFilter : IFilter
    {
        public Expression<Func<UserProfile, bool>> Filter { get; }

        public NameFilter(string name)
        {
            if (name != null)
                Filter = num => !string.IsNullOrEmpty(num.Name) ? num.Name.Contains(name) : false;
        }
    }
}
