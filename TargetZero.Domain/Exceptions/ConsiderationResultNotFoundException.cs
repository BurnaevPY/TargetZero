using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetZero.Domain.Exceptions
{
    public class ConsiderationResultNotFoundException : Exception
    {
        public ConsiderationResultNotFoundException()
        {
        }

        public ConsiderationResultNotFoundException(string message)
            : base(message)
        {
        }

        public ConsiderationResultNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
