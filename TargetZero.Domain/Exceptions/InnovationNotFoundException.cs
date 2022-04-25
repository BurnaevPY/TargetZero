using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetZero.Domain.Exceptions
{
    public class InnovationNotFoundException : Exception
    {
        public InnovationNotFoundException()
        {
        }

        public InnovationNotFoundException(string message)
            : base(message)
        {
        }

        public InnovationNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
