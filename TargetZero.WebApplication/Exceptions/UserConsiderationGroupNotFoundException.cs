using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.WebApplication.Exceptions
{
    public class UserConsiderationGroupNotFoundException : Exception
    {
        public UserConsiderationGroupNotFoundException()
        {
        }

        public UserConsiderationGroupNotFoundException(string message)
            : base(message)
        {
        }

        public UserConsiderationGroupNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
