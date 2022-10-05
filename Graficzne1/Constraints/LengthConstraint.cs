using Graficzne1.Enums;
using Graficzne1.MyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.Constraints
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
