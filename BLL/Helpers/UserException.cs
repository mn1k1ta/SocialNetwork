using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    class UserException:Exception
    {
        public UserException(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            ExceptionMessage = message;
            Property = prop;
        }
        public bool Succedeed { get; private set; }
        public string ExceptionMessage { get; private set; }
        public string Property { get; private set; }
    }
}
