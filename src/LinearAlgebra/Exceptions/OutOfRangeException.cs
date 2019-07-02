using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class OutOfRangeException : LinearAlgebraException
    {
        public OutOfRangeException()
        {

        }

        public OutOfRangeException(string message) : base(message)
        {

        }
    }
}
