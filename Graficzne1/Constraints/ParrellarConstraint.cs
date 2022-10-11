using Graficzne1.MyObjects;

namespace Graficzne1.Constraints
{
    internal class ParrellarConstraint
    {
        public int id;
        public MyPoint sameEdgePoint;
        public MyPoint otherEdgePointAsymetric;
        public MyPoint otherEdgePointSymetric;

        public ParrellarConstraint(ref MyPoint sameEdgePoint, ref MyPoint otherEdgePointAsymetric, ref MyPoint otherEdgePointSymetric, int id)
        {
            this.sameEdgePoint = sameEdgePoint;
            this.otherEdgePointAsymetric = otherEdgePointAsymetric;
            this.otherEdgePointSymetric = otherEdgePointSymetric;
            this.id = id;
        }
    }
}
