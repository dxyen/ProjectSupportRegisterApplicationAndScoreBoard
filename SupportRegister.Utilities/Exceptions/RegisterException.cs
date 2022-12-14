using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Utilities.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException()
        {
        }

        public RegisterException(string message)
            : base(message)
        {
        }

        public RegisterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
