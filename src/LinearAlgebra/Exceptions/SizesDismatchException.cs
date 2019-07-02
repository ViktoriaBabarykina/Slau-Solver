using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class SizesDismatchException : LinearAlgebraException
    {
        public SizesDismatchException()
        {

        }

        public SizesDismatchException(string message) : base(message)
        {

        }
    }
}
