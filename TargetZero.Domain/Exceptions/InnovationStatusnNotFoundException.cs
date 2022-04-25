using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetZero.Domain.Exceptions
{
    public class InnovationStatusnNotFoundException : Exception
    {
        public InnovationStatusnNotFoundException()
        {
        }

        public InnovationStatusnNotFoundException(string message)
            : base(message)
        {
        }

        public InnovationStatusnNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
