using Graficzne1.MyObjects;

namespace Graficzne1.SelectedObjects
{
    internal class SelectedEdge
    {
        public MyPoint point1;
        public MyPoint point2;
        public Point selectedLocation;
        public Point originalP1;
        public Point originalP2;

        public SelectedEdge(ref MyPoint point1, ref MyPoint point2, Point p, Point p1, Point p2)
        {
            this.point1 = point1;
            this.point2 = point2;

            selectedLocation = p;
            originalP1 = p1;
            originalP2 = p2;
        }

        public void Move(Point p)
        {
            int dx = p.X - selectedLocation.X;
            int dy = p.Y - selectedLocation.Y;

            Point p1 = new Point(originalP1.X + dx, originalP1.Y + dy);
            Point p2 = new Point(originalP2.X + dx, originalP2.Y + dy);

            point1.Move(p1);
            point2.Move(p2);
        }
    }
}
