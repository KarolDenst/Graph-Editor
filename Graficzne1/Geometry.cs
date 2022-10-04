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

        // Code taken from here
        // https://stackoverflow.com/questions/53173712/calculating-distance-of-point-to-linear-line
        public static bool isLineWithinDistance(Point lineStart, Point lineEnd, Point e)
        {
            int variance = Constants.LineToPointVariance;

            double x1 = lineStart.X;
            double x2 = lineEnd.X;
            double y1 = lineStart.Y;
            double y2 = lineEnd.Y;

            double mouseX = e.X; // Mouse X position
            double mouseY = e.Y; // Mouse Y position

            double AB = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double AP = Math.Sqrt((mouseX - x1) * (mouseX - x1) + (mouseY - y1) * (mouseY - y1));
            double PB = Math.Sqrt((x2 - mouseX) * (x2 - mouseX) + (y2 - mouseY) * (y2 - mouseY));

            if ((AP + PB) >= (AB - variance / 4) && (AP + PB) <= (AB + variance / 4)) return true;

            return false;
        }
    }
}
