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

        public Rectangle GetSelectionSquare()
        {
            int h_max = -1;
            int h_min = 100000;
            int w_max = -1;
            int w_min = 100000;

            foreach(MyPoint p in this.Points)
            {
                if(p.P.Y > h_max) h_max = p.P.Y;
                if(p.P.Y < h_min) h_min = p.P.Y;
                if(p.P.X > w_max) w_max = p.P.X;
                if(p.P.X < w_min) w_min = p.P.X;
            }

            return new Rectangle(w_min, h_min, w_max - w_min, h_max - h_min);
        }
    }
}
