namespace Graficzne1.SelectedObjects
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
