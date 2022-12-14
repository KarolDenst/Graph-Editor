using Graficzne1.MyObjects;

namespace Graficzne1.SelectedObjects
{
    internal class SelectedPolygon
    {
        public MyPolygon polygon;
        public Point selectedLocation;
        public MyPolygon originalPolygon;

        public SelectedPolygon(Point p, ref MyPolygon poly)
        {
            this.polygon = poly;
            selectedLocation = p;

            originalPolygon = new MyPolygon();
            foreach (MyPoint point in poly.Points)
            {
                originalPolygon.Points.Add(new MyPoint(new Point(point.P.X, point.P.Y), ref originalPolygon));
            }
        }
    }
}
