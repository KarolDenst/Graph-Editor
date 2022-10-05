using Graficzne1.MyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.Constraints
{
    internal class ParrellarConstraint
    {
        public int id;
        public MyPoint sameEdgePoint;
        public MyPoint otherEdgePointAsymetric;
        public MyPoint otherEdgePointSymetric;

        public ParrellarConstraint(MyPoint sameEdgePoint, MyPoint otherEdgePointAsymetric, MyPoint otherEdgePointSymetric, int id)
        {
            this.sameEdgePoint = sameEdgePoint;
            this.otherEdgePointAsymetric = otherEdgePointAsymetric;
            this.otherEdgePointSymetric = otherEdgePointSymetric;
            this.id = id;
        }
    }
}
