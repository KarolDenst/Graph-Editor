using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficzne1
{
    internal static class Geometry
    {
        public static int GetSquaredDistance(Point p1, Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }

        public static bool isInsideRectangle(Rectangle rect, Point p)
        {
            if (rect.Top > p.Y) return false;
            if (rect.Left > p.X) return false;
            if (rect.Bottom < p.Y) return false;
            if (rect.Right < p.X) return false;

            return true;
        }
    }
}
