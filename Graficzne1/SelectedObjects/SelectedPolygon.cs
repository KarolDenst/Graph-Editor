using Graficzne1.MyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                originalPolygon.Points.Add(new MyPoint(new Point(point.P.X, point.P.Y), originalPolygon));
            }
        }
    }
}
