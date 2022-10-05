using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal class SelectedPolygon
    {
        public int index;
        public Point selectedLocation;
        public MyPolygon polygon;

        public SelectedPolygon()
        {
            index = -1;
        }

        public SelectedPolygon(int index, Point p, MyPolygon poly)
        {
            this.index = index;
            selectedLocation = p;

            polygon = new MyPolygon();
            foreach(MyPoint point in poly.Points)
            {
                polygon.Points.Add(new MyPoint(new Point(point.P.X, point.P.Y)));
            }
        }
    }
}
