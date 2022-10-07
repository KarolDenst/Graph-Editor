using Graficzne1.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1.MyObjects
{
    internal class MyPoint
    {
        public MyPolygon MyPolygon;
        public Point P;
        public List<LengthConstraint> lengthConstraints;
        public List<ParrellarConstraint> parrellarConstraints;

        public MyPoint(Point p, MyPolygon myPolygon)
        {
            P = p;
            lengthConstraints = new List<LengthConstraint>();
            parrellarConstraints = new List<ParrellarConstraint>();
            MyPolygon = myPolygon;
        }

        public void Move(Point p, int retry = 0)
        {
            Point original = P;
            if (!TryMovePoint(p)) P = original;

        }

        private bool TryMovePoint(Point p, int retry = 0)
        {
            P = p;

            return ApplyLengthConstraints(retry);
        }

        private bool ApplyLengthConstraints(int retry)
        {
            if (retry > Constants.RetryTimes) return false;

            foreach (LengthConstraint constraint in lengthConstraints)
            {
                int len = Geometry.GetEdgeLength(P, constraint.P.P);
                if (Math.Abs(len - constraint.Length) > Constants.LengthEonstraint)
                {
                    double dx = P.X - constraint.P.P.X;
                    double dy = P.Y - constraint.P.P.Y;
                    double ratio = Convert.ToDouble(constraint.Length) / Convert.ToDouble(len);

                    double px = ratio * dx + constraint.P.P.X;
                    double py = ratio * dy + constraint.P.P.Y;

                    return TryMovePoint(new Point(Convert.ToInt32(px), Convert.ToInt32(py)), retry + 1);
                }
            }

            return true;
        }

        private void ApplyParrellarConstraint(int retry)
        {
            foreach(ParrellarConstraint constraint in parrellarConstraints)
            {
                if (Geometry.IsSameAngle(P,
                    constraint.sameEdgePoint.P,
                    constraint.otherEdgePointSymetric.P,
                    constraint.otherEdgePointAsymetric.P)) continue;


            }
        }
    }
}
