using Graficzne1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.Constraints
{
    internal interface IConstraint
    {
        ConstraintType GetConstraintType();
    }
}
