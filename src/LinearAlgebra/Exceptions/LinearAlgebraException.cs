using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class LinearAlgebraException : Exception
    {
        public LinearAlgebraException()
        {
                
        }

        public LinearAlgebraException(string message) : base(message)
        {

        }
    }
}
