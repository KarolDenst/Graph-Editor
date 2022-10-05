using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal class SelectedEdge
    {
        public int polygonIndex;
        public int index1;
        public int index2;
        public Point selectedLocation;
        public Point originalP1;
        public Point originalP2;

        public SelectedEdge()
        {
            index1 = -1;
            index2 = -1;
            polygonIndex = -1;
        }

        public SelectedEdge(int polygonIndex, int index1, int index2, Point p, Point p1, Point p2)
        {
            this.polygonIndex = polygonIndex;
            this.index1 = index1;
            this.index2 = index2;

            selectedLocation = p;
            this.originalP1 = p1;
            this.originalP2 = p2;
        }
    }
}
