using LinearAlgebra.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LinearAlgebraTests
{
    [TestClass]
    public class DenseVectorTest : VectorTest
    {
        public DenseVectorTest()
        {
            _vectorFactory = new DenseVectorFactory();
        }
    }
}
