using Graficzne1.Enums;
using Graficzne1.MyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.Constraints
{
    internal class LengthConstraint
    {
        public int Length;
        public MyPoint P;

        public LengthConstraint(int length, ref MyPoint p)
        {
            Length = length;
            P = p;
        }
    }
}
