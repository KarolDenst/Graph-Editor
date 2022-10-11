using Graficzne1.SelectedObjects;

namespace Graficzne1.MyObjects
{
    internal class MyPolygon
    {
        public List<MyPoint> Points;

        public MyPolygon(List<MyPoint> points)
        {
            Points = points;
        }

        public MyPolygon()
        {
            Points = new List<MyPoint>();
        }

        public Rectangle GetSelectionSquare()
        {
            int h_max = -1;
            int h_min = 100000;
            int w_max = -1;
            int w_min = 100000;

            foreach (MyPoint p in Points)
            {
                if (p.P.Y > h_max) h_max = p.P.Y;
                if (p.P.Y < h_min) h_min = p.P.Y;
                if (p.P.X > w_max) w_max = p.P.X;
                if (p.P.X < w_min) w_min = p.P.X;
            }

            return new Rectangle(w_min, h_min, w_max - w_min, h_max - h_min);
        }

        public void Move(Point p, SelectedPolygon selectedPolygon)
        {
            int dx = p.X - selectedPolygon.selectedLocation.X;
            int dy = p.Y - selectedPolygon.selectedLocation.Y;

            for (int i = 0; i < selectedPolygon.polygon.Points.Count; i++)
            {
                selectedPolygon.polygon.Points[i].P.X = selectedPolygon.originalPolygon.Points[i].P.X + dx;
                selectedPolygon.polygon.Points[i].P.Y = selectedPolygon.originalPolygon.Points[i].P.Y + dy;
            }
        }
    }
}
