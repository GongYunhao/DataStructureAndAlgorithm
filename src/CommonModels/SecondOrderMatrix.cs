using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace CommonModels
{
    public class SecondOrderMatrix
    {
        private readonly long int1;
        private readonly long int2;
        private readonly long int3;
        private readonly long int4;

        public SecondOrderMatrix(long upperLeft, long upperRight, long lowerLeft, long lowerRight)
        {
            int1 = upperLeft;
            int2 = upperRight;
            int3 = lowerLeft;
            int4 = lowerRight;
        }

        public static SecondOrderMatrix operator *(SecondOrderMatrix a, SecondOrderMatrix b)
        {
            return new SecondOrderMatrix(
                a.int1 * b.int1 + a.int2 * b.int3,
                a.int1 * b.int2 + a.int2 * b.int4,
                a.int3 * b.int1 + a.int4 * b.int3,
                a.int3 * b.int2 + a.int4 * b.int4);
        }

        public long GetFirstNumber()
        {
            return int1;
        }
    }
}
