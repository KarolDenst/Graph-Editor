using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal class LengthConstraint : IConstraint
    {
        public int Length;
        public MyPoint P;
        public ConstraintType GetConstraintType()
        {
            return ConstraintType.Length;
        }

        public LengthConstraint(int length, MyPoint p)
        {
            Length = length;
            P = p;
        }
    }
}
