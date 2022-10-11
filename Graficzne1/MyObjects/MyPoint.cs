using Graficzne1.Constraints;

namespace Graficzne1.MyObjects
{
    internal class MyPoint
    {
        public MyPolygon MyPolygon;
        public Point P;
        public List<LengthConstraint> lengthConstraints;
        public List<ParrellarConstraint> parrellarConstraints;

        public MyPoint(Point p, ref MyPolygon myPolygon)
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

            //if (!ApplyLengthConstraints(retry)) return false;
            ApplyParrellarConstraints(retry);
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
                    //double dx = P.X - constraint.P.P.X;
                    //double dy = P.Y - constraint.P.P.Y;
                    //double ratio = Convert.ToDouble(constraint.Length) / Convert.ToDouble(len);

                    //double px = ratio * dx + constraint.P.P.X;
                    //double py = ratio * dy + constraint.P.P.Y;

                    //return TryMovePoint(new Point(Convert.ToInt32(px), Convert.ToInt32(py)), retry + 1);

                    double dx = -P.X + constraint.P.P.X;
                    double dy = -P.Y + constraint.P.P.Y;
                    double ratio = Convert.ToDouble(constraint.Length) / Convert.ToDouble(len);

                    double px = ratio * dx + P.X;
                    double py = ratio * dy + P.Y;

                    return constraint.P.TryMovePoint(new Point(Convert.ToInt32(px), Convert.ToInt32(py)), retry + 1);
                }
            }

            return true;
        }

        private void ApplyParrellarConstraints(int retry)
        {
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

                constraint.otherEdgePointSymetric.Move(p, retry + 1);
            }
        }

        public void RemoveConstraints()
        {
            foreach(LengthConstraint constraint in lengthConstraints)
            {
                constraint.P.lengthConstraints.RemoveAll(x => x.P == this);
            }

            lengthConstraints = new List<LengthConstraint>();

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
