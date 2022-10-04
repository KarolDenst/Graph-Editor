using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal struct SelectedPoint
    {
        public int pointIndex;
        public int polygonIndex;

        public SelectedPoint()
        {
            pointIndex = -1;
            polygonIndex = -1;
        }

        public SelectedPoint(int point, int polygon)
        {
            pointIndex = point;
            polygonIndex = polygon;
        }
    }
}
