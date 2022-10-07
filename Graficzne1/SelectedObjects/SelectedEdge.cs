using Graficzne1.MyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
