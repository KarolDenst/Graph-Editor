﻿using Graficzne1.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.MyObjects
{
    internal class MyPoint
    {
        public Point P;
        public List<IConstraint> constraints;

        public MyPoint(Point p)
        {
            P = p;
            constraints = new List<IConstraint>();
        }
    }
}