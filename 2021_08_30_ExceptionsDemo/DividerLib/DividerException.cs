using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividerLib
{
    public class DividerException : Exception
    {

        public DividerException()
        {
        }

        public DividerException(string message)
            : base(message)
        {
        }

        public DividerException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

    }
}
