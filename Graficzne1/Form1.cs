using System.Security.Cryptography.Xml;

namespace Graficzne1
{
    public partial class Form1 : Form
    {
        private Mode mode = Mode.Place;
        private List<MyPolygon> polygons = new List<MyPolygon>();
        private MyPolygon polygon = new MyPolygon();
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3);
        SelectedPoint selectedPoint = new SelectedPoint();
        SolidBrush brush = new SolidBrush(Color.Black);
        SelectedPolygon selectedPolygon = new SelectedPolygon();
        SelectedEdge selectedEdge = new SelectedEdge();

        public Form1()
        {
            InitializeComponent();

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
        }

        private void placeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!placeButton.Checked)
            {
                if (polygon.Points.Count > 2)
                {
                    polygons.Add(polygon);
                }
                polygon = new MyPolygon();
            }
            setMode();   
        }

        private void moveButton_CheckedChanged(object sender, EventArgs e)
        {
            setMode();
        }

        private void deleteButton_CheckedChanged(object sender, EventArgs e)
        {
            setMode();
        }

        private void AddVertexButton_CheckedChanged(object sender, EventArgs e)
        {
            setMode();
        }

        private void setMode()
        {
            if (placeButton.Checked) mode = Mode.Place;
            else if (moveButton.Checked) mode = Mode.Move;
            else if (deleteButton.Checked) mode = Mode.Delete;
            else if (AddVertexButton.Checked) mode = Mode.AddEdge;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    polygon.Points.Add(new MyPoint(e.Location));
                    graphics.Clear(Color.White);
                    DrawPolygons();
                    break;
                case Mode.Move:
                    break;
                case Mode.Delete:
                    SelectPoint(e.Location);
                    DeleteSelectedPoint();
                    selectedPoint = new SelectedPoint();
                    break;
                case Mode.AddEdge:
                    AddVertexInTheMiddle(e.Location);
                    DrawPolygons();
                    break;
                default:
                    break;
            }
        }

        private void AddVertexInTheMiddle(Point p)
        {
            SelectedPoint point = FindEdge(p);
            if (point.pointIndex == -1) return;
            polygons[point.polygonIndex].Points.Insert(point.pointIndex, new MyPoint(p));
        }

        private SelectedPoint FindEdge(Point p)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isLineWithinDistance(polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P, p))
                {
                    return new SelectedPoint(0, i);
                }
                for (int j = 0; j < polygons[i].Points.Count - 1; j++)
                {
                    if (Geometry.isLineWithinDistance(polygons[i].Points[j].P, polygons[i].Points[j + 1].P, p))
                    {
                        return new SelectedPoint(j + 1, i);
                    }
                }
            }

            return new SelectedPoint();
        }

        // Code taken from here
        // https://stackoverflow.com/questions/53173712/calculating-distance-of-point-to-linear-line
        

        private void DeleteSelectedPoint()
        {
            if (selectedPoint.polygonIndex < 0) return;

            if (polygons[selectedPoint.polygonIndex].Points.Count < 4)
            {
                polygons.Remove(polygons[selectedPoint.polygonIndex]);
                DrawPolygons();
                return;
            }

            polygons[selectedPoint.polygonIndex].Points.Remove(polygons[selectedPoint.polygonIndex].Points[selectedPoint.pointIndex]);
            DrawPolygons();
        }

        private void DrawPolygons()
        {
            graphics.Clear(Color.White);
            //pictureBox.Refresh();
            foreach (MyPolygon poly in polygons)
            {
                DrawPolygon(poly);
            }
            if (polygon.Points.Count > 2) DrawPolygon(polygon);
            pictureBox.Refresh();
        }

        private void Test()
        {
            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap(200, 200);

            // Set each pixel in myBitmap to black.
            for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
                {
                    myBitmap.SetPixel(Xcount, Ycount, Color.Black);
                }
            }

            // Draw myBitmap to the screen again.
            graphics.DrawImage(myBitmap, myBitmap.Width, 0,
                myBitmap.Width, myBitmap.Height);
        }

        private void DrawPolygon(MyPolygon polygon)
        {
            int offset = Constants.VertexOffset;
            int size = Constants.VertexSize;
            
            graphics.DrawLine(pen, polygon.Points[0].P, polygon.Points[1].P);
            graphics.FillEllipse(brush, polygon.Points[0].P.X - offset, polygon.Points[0].P.Y - offset, size, size);
            for (int i = 1; i < polygon.Points.Count; i++)
            {
                graphics.DrawLine(pen, polygon.Points[i - 1].P, polygon.Points[i].P);
                graphics.FillEllipse(brush, polygon.Points[i].P.X - offset, polygon.Points[i].P.Y - offset, size, size);
            }
            graphics.DrawLine(pen, polygon.Points[0].P, polygon.Points[polygon.Points.Count - 1].P);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    break;
                case Mode.Move:
                    SelectPoint(e.Location);
                    if (selectedPoint.pointIndex != -1) break;
                    SelectEdge(e.Location);
                    if (selectedEdge.index1 != -1) break;
                    SelectPolygon(e.Location);
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }

        private void SelectPolygon(Point p)
        {
            for(int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isInsideRectangle(polygons[i].GetSelectionSquare(), p))
                {
                    selectedPolygon = new SelectedPolygon(i, p, polygons[i]);
                    return;
                }
            }
        }

        private void SelectEdge(Point p)
        {
            for(int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isLineWithinDistance(polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P, p))
                {
                    selectedEdge = new SelectedEdge(i, 0, polygons[i].Points.Count - 1, p, polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P);
                    return;
                }

                for (int j = 0; j < polygons[i].Points.Count - 1; j++)
                {
                    if (Geometry.isLineWithinDistance(polygons[i].Points[j].P, polygons[i].Points[j + 1].P, p))
                    {
                        selectedEdge = new SelectedEdge(i, j, j + 1, p, polygons[i].Points[j].P, polygons[i].Points[j + 1].P);
                        return;
                    }
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    break;
                case Mode.Move:
                    selectedPoint = new SelectedPoint();
                    selectedPolygon = new SelectedPolygon();
                    selectedEdge = new SelectedEdge();
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }
        
        private void SelectPoint(Point p)
        {
            for(int i = 0; i < polygons.Count; i++)
            {
                for(int j = 0; j < polygons[i].Points.Count; j++)
                {
                    if (Geometry.GetSquaredDistance(polygons[i].Points[j].P, p) > Constants.MaxSquaredDistanceToSelect) continue;
                    selectedPoint.polygonIndex = i;
                    selectedPoint.pointIndex = j;
                }
            }
        }

        private void MoveSelected(Point p)
        {
            polygons[selectedPoint.polygonIndex].Points[selectedPoint.pointIndex].P = p;

            DrawPolygons();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    break;
                case Mode.Move:
                    if (selectedPoint.pointIndex > -1) MoveSelected(e.Location);
                    else if (selectedPolygon.index > -1) MoveSelectedPolygon(e.Location);
                    else if (selectedEdge.polygonIndex > -1) MoveSelectedEdge(e.Location);
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }

        private void MoveSelectedEdge(Point p)
        {
            int dx = p.X - selectedEdge.selectedLocation.X;
            int dy = p.Y - selectedEdge.selectedLocation.Y;

            polygons[selectedEdge.polygonIndex].Points[selectedEdge.index1].P.X = selectedEdge.originalP1.X + dx;
            polygons[selectedEdge.polygonIndex].Points[selectedEdge.index1].P.Y = selectedEdge.originalP1.Y + dy;

            polygons[selectedEdge.polygonIndex].Points[selectedEdge.index2].P.X = selectedEdge.originalP2.X + dx;
            polygons[selectedEdge.polygonIndex].Points[selectedEdge.index2].P.Y = selectedEdge.originalP2.Y + dy;

            DrawPolygons();
        }

        private void MoveSelectedPolygon(Point p)
        {
            int dx = p.X - selectedPolygon.selectedLocation.X;
            int dy = p.Y - selectedPolygon.selectedLocation.Y;

            for(int i = 0; i < polygons[selectedPolygon.index].Points.Count; i++)
            {
                polygons[selectedPolygon.index].Points[i].P.X = selectedPolygon.polygon.Points[i].P.X + dx;
                polygons[selectedPolygon.index].Points[i].P.Y = selectedPolygon.polygon.Points[i].P.Y + dy;
            }

            DrawPolygons();   
        }
    }
}