using Graficzne1.Constraints;

namespace Graficzne1.MyObjects
{
    internal class MyPoint
    {
        public MyPolygon MyPolygon;
        public Point P;
        public LengthConstraint? lengthConstraint;
        public List<ParrellarConstraint> parrellarConstraints;

        public MyPoint(Point p, ref MyPolygon myPolygon)
        {
            P = p;
            lengthConstraint = null;
            parrellarConstraints = new List<ParrellarConstraint>();
            MyPolygon = myPolygon;
        }

        public bool Move(Point p, int retry = 0)
        {
            Point original = P;
            if (!TryMovePoint(p))
            {
                P = original;
                return false;
            }
            return true;
        }

        private bool TryMovePoint(Point p, int retry = 0)
        {
            P = p;

            //if (!ApplyLengthConstraints(retry)) return false;
            bool parrellarWorked = ApplyParrellarConstraints(retry);
            bool lengthWorked = ApplyLengthConstraints(retry);

            return parrellarWorked && lengthWorked;
        }

        private bool ApplyLengthConstraints(int retry)
        {
            if (retry > Constants.RetryTimes) return false;

            if (lengthConstraint != null)
            {
                int len = Geometry.GetEdgeLength(P, lengthConstraint.P.P);
                if (Math.Abs(len - lengthConstraint.Length) > Constants.LengthEonstraint)
                {
                    double dx = -P.X + lengthConstraint.P.P.X;
                    double dy = -P.Y + lengthConstraint.P.P.Y;
                    double ratio = Convert.ToDouble(lengthConstraint.Length) / Convert.ToDouble(len);

                    double px = ratio * dx + P.X;
                    double py = ratio * dy + P.Y;

                    return lengthConstraint.P.TryMovePoint(new Point(Convert.ToInt32(px), Convert.ToInt32(py)), retry + 1);
                }
            }

            return true;
        }

        private bool ApplyParrellarConstraints(int retry)
        {
            bool worked = true;

            foreach(ParrellarConstraint constraint in parrellarConstraints)
            {
                if (Geometry.IsSameAngle(P,
                    constraint.sameEdgePoint.P,
                    constraint.otherEdgePointSymetric.P,
                    constraint.otherEdgePointAsymetric.P)) continue;

                double len1 = Geometry.GetEdgeLength(P, constraint.sameEdgePoint.P);
                double len2 = Geometry.GetEdgeLength(constraint.otherEdgePointSymetric.P, constraint.otherEdgePointAsymetric.P);
                double ratio = len2 / len1;
                double dx = P.X - constraint.sameEdgePoint.P.X;
                double dy = P.Y - constraint.sameEdgePoint.P.Y;

                int x = Convert.ToInt32(constraint.otherEdgePointAsymetric.P.X + dx * ratio);
                int y = Convert.ToInt32(constraint.otherEdgePointAsymetric.P.Y + dy * ratio);

                Point p = new Point(x, y);

                if (!constraint.otherEdgePointSymetric.Move(p, retry + 1)) worked = false;
            }

            return worked;
        }

        public void RemoveConstraints()
        {
            if (lengthConstraint is not null) lengthConstraint.P.lengthConstraint = null;

            lengthConstraint = null;

            foreach (ParrellarConstraint constraint in parrellarConstraints)
            {
                constraint.sameEdgePoint.parrellarConstraints.RemoveAll(x => x.id == constraint.id);
                constraint.otherEdgePointSymetric.parrellarConstraints.RemoveAll(x => x.id == constraint.id);
                constraint.otherEdgePointAsymetric.parrellarConstraints.RemoveAll(x => x.id == constraint.id);
            }

            parrellarConstraints = new List<ParrellarConstraint>();
        }
    }
}
