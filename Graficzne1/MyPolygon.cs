using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal class MyPolygon
    {
        public List<MyPoint> Points;

        public MyPolygon(List<MyPoint> points)
        {
            this.Points = points;
        }

        public MyPolygon()
        {
            this.Points = new List<MyPoint>();
        }
    }
}
