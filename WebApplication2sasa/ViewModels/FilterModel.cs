using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class FilterModel
    {
        private string name;
        private string gender;
        private string country;
        private string city;
        private int ageMin;
        private int ageMax;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)&&value!= "undefined")
                    name = value;

            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != "undefined")
                    gender = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != "undefined")
                    city = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != "undefined")
                    country = value;
            }
        }
        public int MinAge
        {
            get
            {
                return ageMin;
            }
            set
            {
                if (value != 0)
                    ageMin = value;
            }
        }
        public int MaxAge
        {
            get
            {
                return ageMax;
            }
            set
            {
                if (value != 0)
                    ageMax = value;
            }
        }
    }
}
