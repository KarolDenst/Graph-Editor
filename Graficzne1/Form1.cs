using Graficzne1.Constraints;
using Graficzne1.Enums;
using Graficzne1.MyObjects;
using Graficzne1.SelectedObjects;

namespace Graficzne1
{
    public partial class Form1 : Form
    {
        private Mode mode = Mode.Place;
        private List<MyPolygon> polygons = new List<MyPolygon>();
        private MyPolygon polygon = new MyPolygon();
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3);
        Pen lenConstPen = new Pen(Color.Red, 3);

        MyPoint? selectedPoint = null;
        SelectedPolygon? selectedPolygon = null;
        SelectedEdge? selectedEdge = null;

        DrawingMode drawingMode = DrawingMode.Library;

        SolidBrush brush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        int parrellarConstraintCounter = 0;

        public Form1()
        {
            InitializeComponent();

            //Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pictureBox.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            SetUpStartScene();
        }

        // RadioButton Section
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

            DrawPolygons();
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

        private void parrellarConstraintButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedEdge = null;
            setMode();
        }

        private void LengthConstraintButton_CheckedChanged(object sender, EventArgs e)
        {
            setMode();
        }

        private void deleteConstraintButton_CheckedChanged(object sender, EventArgs e)
        {
            setMode();
        }

        private void setMode()
        {
            if (placeButton.Checked) mode = Mode.Place;
            else if (moveButton.Checked) mode = Mode.Move;
            else if (deleteButton.Checked) mode = Mode.Delete;
            else if (AddVertexButton.Checked) mode = Mode.AddVertex;
            else if (LengthConstraintButton.Checked) mode = Mode.LengthConstraint;
            else if (parrellarConstraintButton.Checked) mode = Mode.ParrellarConstraint;
            else if (deleteConstraintButton.Checked) mode = Mode.DeleteConstraint;
        }

        // Drawing Mode Radio button
        private void libraryButton_CheckedChanged(object sender, EventArgs e)
        {
            SetDrawingMode();
        }

        private void bresenhamButton_CheckedChanged(object sender, EventArgs e)
        {
            SetDrawingMode();
        }

        private void SetDrawingMode()
        {
            if (libraryButton.Checked) drawingMode = DrawingMode.Library;
            else if (bresenhamButton.Checked) drawingMode = DrawingMode.Bresenham;

            DrawPolygons();
        }

        // Drawing Section
        private void DrawPolygon(MyPolygon polygon)
        {
            switch (drawingMode)
            {
                case DrawingMode.Library:
                    DrawLibrary(polygon);
                    break;
                case DrawingMode.Bresenham:
                    DrawBresenham(polygon);
                    break;
                default:
                    break;
            }            
        }

        private void DrawVertexes(MyPolygon polygon)
        {
            if (polygon.Points.Count < 1) return;
            int offset = Constants.VertexOffset;
            int size = Constants.VertexSize;

            graphics.FillEllipse(brush, polygon.Points[0].P.X - offset, polygon.Points[0].P.Y - offset, size, size);
            for (int i = 1; i < polygon.Points.Count; i++)
            {
                graphics.FillEllipse(brush, polygon.Points[i].P.X - offset, polygon.Points[i].P.Y - offset, size, size);
            }
        }

        private void DrawLibrary(MyPolygon polygon)
        {
            DrawVertexes(polygon);

            graphics.DrawLine(pen, polygon.Points[0].P, polygon.Points[1].P);
            for (int i = 1; i < polygon.Points.Count; i++)
            {
                graphics.DrawLine(pen, polygon.Points[i - 1].P, polygon.Points[i].P);
            }
            graphics.DrawLine(pen, polygon.Points[0].P, polygon.Points[polygon.Points.Count - 1].P);
        }

        private void DrawBresenham(MyPolygon polygon)
        {
            DrawVertexes(polygon);

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            DrawLineBresenham(polygon.Points[0].P, polygon.Points[1].P, bitmap);
            for (int i = 1; i < polygon.Points.Count; i++)
            {
                DrawLineBresenham(polygon.Points[i - 1].P, polygon.Points[i].P, bitmap);
            }
            DrawLineBresenham(polygon.Points[0].P, polygon.Points[polygon.Points.Count - 1].P, bitmap);

            graphics.DrawImage(bitmap, 0, 0,
                bitmap.Width, bitmap.Height);
        }

        // Code idea from:
        // https://www.geeksforgeeks.org/bresenhams-line-generation-algorithm/
        private void DrawLineBresenham(Point p1, Point p2, Bitmap bitmap)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int pk;

            if (dx < dy)
            {
                pk = 2 * dx - dy;
                for (int i = 0; i <= dy; i++)
                {
                    if (y1 < y2) y1++;
                    else y1--;

                    if (pk < 0)
                    {
                        bitmap.SetPixel(x1, y1, Color.Black);

                        pk = pk + 2 * dx;
                    }
                    else
                    {
                        if (x1 < x2) x1++;
                        else x1--;

                        bitmap.SetPixel(x1, y1, Color.Black);

                        pk = pk + 2 * dx - 2 * dy;
                    }
                }
                return;
            }

            pk = 2 * dy - dx;
            for (int i = 0; i <= dx; i++)
            {
                if (x1 < x2) x1++;
                else x1--;

                if (pk < 0)
                {
                    bitmap.SetPixel(x1, y1, Color.Black);

                    pk = pk + 2 * dy;
                }
                else
                {
                    if (y1 < y2) y1++;
                    else y1--;

                    bitmap.SetPixel(x1, y1, Color.Black);
                    
                    pk = pk + 2 * dy - 2 * dx;
                }
            }

        }

        private void DrawCurrentPolygonLibrary()
        {
            DrawVertexes(polygon);

            if (polygon.Points.Count < 2) return;
            graphics.DrawLine(pen, polygon.Points[0].P, polygon.Points[1].P);
            for (int i = 1; i < polygon.Points.Count; i++)
            {
                graphics.DrawLine(pen, polygon.Points[i - 1].P, polygon.Points[i].P);
            }
        }

        private bool TrySavePolygon(Point p)
        {
            if (polygon.Points.Count < 3) return false;
            if (Geometry.GetSquaredDistance(p, polygon.Points[0].P) < Constants.MaxSquaredDistanceToSelect)
            {
                if (polygon.Points.Count >= 3)
                {
                    polygons.Add(polygon);
                    polygon = new MyPolygon();
                    DrawPolygons();
                    return true;
                }
            }

            return false;
        }

        private void DrawPolygons()
        {
            graphics.Clear(Color.White);
            foreach (MyPolygon poly in polygons)
            {
                DrawPolygon(poly);
            }
            DrawCurrentPolygonLibrary();
            //if (polygon.Points.Count > 2) DrawPolygon(polygon);
            DrawConstraints();
            pictureBox.Refresh();
        }

        private void DrawPolygonsWithCurrent(Point p)
        {
            graphics.Clear(Color.White);
            foreach (MyPolygon poly in polygons)
            {
                DrawPolygon(poly);
            }
            DrawCurrentPolygonLibrary();
            DrawLineToMouse(p);
            pictureBox.Refresh();
        }

        private void DrawLineToMouse(Point p)
        {
            if (polygon.Points.Count > 0)
            {
                graphics.DrawLine(pen, polygon.Points[polygon.Points.Count - 1].P, p);
            }
        }

        // Mouse Events
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    if (TrySavePolygon(e.Location)) break;
                    polygon.Points.Add(new MyPoint(e.Location, ref polygon));
                    graphics.Clear(Color.White);
                    DrawPolygons();
                    break;
                case Mode.Move:
                    break;
                case Mode.Delete:
                    DeletePoint(e.Location);
                    DrawPolygons();
                    break;
                case Mode.AddVertex:
                    AddVertexInTheMiddle(e.Location);
                    DrawPolygons();
                    break;
                case Mode.LengthConstraint:
                    TryAddLengthConstraint(e.Location);
                    DrawPolygons();
                    break;
                case Mode.ParrellarConstraint:
                    TryAddParrellarConstraint(e.Location);
                    DrawPolygons();
                    break;
                case Mode.DeleteConstraint:
                    TryRemoveConstraint(e.Location);
                    DrawPolygons();
                    break;
                default:
                    break;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    break;
                case Mode.Move:
                    SelectPoint(e.Location);
                    if (selectedPoint is not null) break;
                    SelectEdge(e.Location);
                    if (selectedEdge is not null) break;
                    SelectPolygon(e.Location);
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    if (polygon.Points.Count <= 0) return;
                    DrawPolygonsWithCurrent(e.Location);
                    break;
                case Mode.Move:
                    if (selectedPoint is not null)
                    {
                        selectedPoint.Move(e.Location);
                        DrawPolygons();
                    }
                    else if (selectedPolygon is not null)
                    {
                        selectedPolygon.polygon.Move(e.Location, selectedPolygon);
                        DrawPolygons();
                    }
                    else if (selectedEdge is not null)
                    {
                        selectedEdge.Move(e.Location);
                        DrawPolygons();
                    }
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.Place:
                    break;
                case Mode.Move:
                    selectedPoint = null;
                    selectedPolygon = null;
                    selectedEdge = null;
                    break;
                case Mode.Delete:
                    break;
                default:
                    break;
            }
        }

        // Select Object
        private void SelectPoint(Point p)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                for (int j = 0; j < polygons[i].Points.Count; j++)
                {
                    if (Geometry.GetSquaredDistance(polygons[i].Points[j].P, p) > Constants.MaxSquaredDistanceToSelect) continue;
                    
                    selectedPoint = polygons[i].Points[j];
                }
            }
        }

        private void SelectEdge(Point p)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isLineWithinDistance(polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P, p))
                {
                    MyPoint p1 = polygons[i].Points[0];
                    MyPoint p2 = polygons[i].Points[polygons[i].Points.Count - 1];

                    selectedEdge = new SelectedEdge(ref p1, ref p2, p, polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P);
                    return;
                }

                for (int j = 0; j < polygons[i].Points.Count - 1; j++)
                {
                    if (Geometry.isLineWithinDistance(polygons[i].Points[j].P, polygons[i].Points[j + 1].P, p))
                    {
                        MyPoint p1 = polygons[i].Points[j];
                        MyPoint p2 = polygons[i].Points[j + 1];

                        selectedEdge = new SelectedEdge(ref p1, ref p2, p, polygons[i].Points[j].P, polygons[i].Points[j + 1].P);
                        return;
                    }
                }
            }
        }

        private void SelectPolygon(Point p)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isInsideRectangle(polygons[i].GetSelectionSquare(), p))
                {
                    MyPolygon poly = polygons[i];
                    selectedPolygon = new SelectedPolygon(p, ref poly);
                    return;
                }
            }
        }

        // Utility
        private void AddVertexInTheMiddle(Point p)
        {
            SelectedPoint point = FindEdge(p);
            if (point.pointIndex == -1) return;
            if (point.pointIndex == 0)
            {
                polygons[point.polygonIndex].Points[0].RemoveConstraints();
                polygons[point.polygonIndex].Points[^1].RemoveConstraints();
            }
            else
            {
                polygons[point.polygonIndex].Points[point.pointIndex - 1].RemoveConstraints();
                polygons[point.polygonIndex].Points[point.pointIndex].RemoveConstraints();
            }
            MyPolygon polygon = polygons[point.polygonIndex];
            polygons[point.polygonIndex].Points.Insert(point.pointIndex, new MyPoint(p, ref polygon));
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

        private void DeletePoint(Point p)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                for (int j = 0; j < polygons[i].Points.Count; j++)
                {
                    if (Geometry.GetSquaredDistance(polygons[i].Points[j].P, p) > Constants.MaxSquaredDistanceToSelect) continue;

                    if (mode == Mode.Delete)
                    {
                        if (polygons[i].Points.Count < 4)
                        {
                            polygons.RemoveAt(i);
                            return;
                        }

                        polygons[i].Points[j].RemoveConstraints();
                        polygons[i].Points.RemoveAt(j);

                        return;
                    }
                }
            }
        }

        // Constraints

        private void TryAddLengthConstraint(Point p)
        {
            SelectEdge(p);
            if (selectedEdge is null) return;

            int edgeLength = Geometry.GetEdgeLength(selectedEdge.point1.P, selectedEdge.point2.P);

            string lengthText = Prompt.ShowDialog("Input maximum edge length", "123", edgeLength.ToString());

            int length = Convert.ToInt32(lengthText);

            selectedEdge.point1.lengthConstraint = new LengthConstraint(length, ref selectedEdge.point2);
            selectedEdge.point2.lengthConstraint = new LengthConstraint(length, ref selectedEdge.point1);

            selectedEdge.point1.Move(selectedEdge.point1.P);
            selectedEdge = null;
        }

        private void TryAddParrellarConstraint(Point p)
        {
            if(selectedEdge is null)
            {
                SelectEdge(p);
                if (selectedEdge is not null)
                {
                    graphics.DrawLine(lenConstPen,
                        selectedEdge.point1.P,
                        selectedEdge.point2.P);
                    pictureBox.Refresh();
                }
                return;
            }

            SelectedEdge? selectedEdge2 = null;

            for (int i = 0; i < polygons.Count; i++)
            {
                if (Geometry.isLineWithinDistance(polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P, p))
                {
                    MyPoint p1 = polygons[i].Points[0];
                    MyPoint p2 = polygons[i].Points[polygons[i].Points.Count - 1];

                    selectedEdge2 = new SelectedEdge(ref p1, ref p2, p, polygons[i].Points[0].P, polygons[i].Points[polygons[i].Points.Count - 1].P);
                }

                for (int j = 0; j < polygons[i].Points.Count - 1; j++)
                {
                    MyPoint p1 = polygons[i].Points[j];
                    MyPoint p2 = polygons[i].Points[j + 1];

                    if (Geometry.isLineWithinDistance(polygons[i].Points[j].P, polygons[i].Points[j + 1].P, p))
                    {
                        selectedEdge2 = new SelectedEdge(ref p1, ref p2, p, polygons[i].Points[j].P, polygons[i].Points[j + 1].P);
                    }
                }
            }

            if (selectedEdge2 is null) return;

            MyPoint point1 = selectedEdge.point1;
            MyPoint point2 = selectedEdge.point2;
            MyPoint point3 = selectedEdge2.point1;
            MyPoint point4 = selectedEdge2.point2;

            if ((point1.P.Y < point2.P.Y && point3.P.Y < point4.P.Y) || (point1.P.Y > point2.P.Y && point3.P.Y > point4.P.Y))
            {
                point1.parrellarConstraints.Add(new ParrellarConstraint(ref point2, ref point4, ref point3, parrellarConstraintCounter));
                point2.parrellarConstraints.Add(new ParrellarConstraint(ref point1, ref point3, ref point4, parrellarConstraintCounter));
                point3.parrellarConstraints.Add(new ParrellarConstraint(ref point4, ref point2, ref point1, parrellarConstraintCounter));
                point4.parrellarConstraints.Add(new ParrellarConstraint(ref point3, ref point1, ref point2, parrellarConstraintCounter));
            }
            else
            {
                point1.parrellarConstraints.Add(new ParrellarConstraint(ref point2, ref point3, ref point4, parrellarConstraintCounter));
                point2.parrellarConstraints.Add(new ParrellarConstraint(ref point1, ref point4, ref point3, parrellarConstraintCounter));
                point3.parrellarConstraints.Add(new ParrellarConstraint(ref point4, ref point1, ref point2, parrellarConstraintCounter));
                point4.parrellarConstraints.Add(new ParrellarConstraint(ref point3, ref point2, ref point1, parrellarConstraintCounter));
            }

            point4.Move(point4.P, -1);
            selectedEdge = null;
            parrellarConstraintCounter++;
        }

        private void DrawConstraints()
        {
            for(int i = 0; i < polygons.Count; i++)
            {
                for(int j = 0; j < polygons[i].Points.Count; j++)
                {
                    if (polygons[i].Points[j].lengthConstraint is not null)
                    {
                        int px = (polygons[i].Points[j].P.X + polygons[i].Points[j].lengthConstraint.P.P.X) / 2 - Constants.ConstraintOffset;
                        int py = (polygons[i].Points[j].P.Y + polygons[i].Points[j].lengthConstraint.P.P.Y) / 2 - Constants.ConstraintOffset;
                        graphics.DrawString(polygons[i].Points[j].lengthConstraint.Length.ToString(), Font, redBrush, new Point(px, py));
                        //graphics.DrawEllipse(lenConstPen, new Rectangle(px, py, Constants.ConstraintSize, Constants.ConstraintSize));
                    }

                    foreach (ParrellarConstraint constraint in polygons[i].Points[j].parrellarConstraints)
                    {
                        int px = (polygons[i].Points[j].P.X + constraint.sameEdgePoint.P.X) / 2 - Constants.ConstraintOffset;
                        int py = (polygons[i].Points[j].P.Y + constraint.sameEdgePoint.P.Y) / 2 - Constants.ConstraintOffset;
                        graphics.DrawString(constraint.id.ToString(), Font, greenBrush, new Point(px, py));
                        //graphics.DrawEllipse(lenConstPen, new Rectangle(px, py, Constants.ConstraintSize, Constants.ConstraintSize));
                    }
                }
            }
        }

        private void SetUpStartScene()
        {
            // polygon 1
            MyPolygon polygon1 = new MyPolygon();

            MyPoint point1 = new MyPoint(new Point(10, 10), ref polygon);
            MyPoint point2 = new MyPoint(new Point(110, 10), ref polygon);
            MyPoint point3 = new MyPoint(new Point(80, 120), ref polygon);
            MyPoint point4 = new MyPoint(new Point(10, 140), ref polygon);

            point1.parrellarConstraints.Add(new ParrellarConstraint(ref point2, ref point3, ref point4, parrellarConstraintCounter));
            point2.parrellarConstraints.Add(new ParrellarConstraint(ref point1, ref point4, ref point3, parrellarConstraintCounter));
            point3.parrellarConstraints.Add(new ParrellarConstraint(ref point4, ref point1, ref point2, parrellarConstraintCounter));
            point4.parrellarConstraints.Add(new ParrellarConstraint(ref point3, ref point2, ref point1, parrellarConstraintCounter));

            //point1.parrellarConstraints.Add(new ParrellarConstraint(ref point2, ref point4, ref point3, parrellarConstraintCounter));
            //point2.parrellarConstraints.Add(new ParrellarConstraint(ref point1, ref point3, ref point4, parrellarConstraintCounter));
            //point3.parrellarConstraints.Add(new ParrellarConstraint(ref point4, ref point2, ref point1, parrellarConstraintCounter));
            //point4.parrellarConstraints.Add(new ParrellarConstraint(ref point3, ref point1, ref point2, parrellarConstraintCounter));

            point4.Move(point4.P, -1);

            polygon1.Points.Add(point1);
            polygon1.Points.Add(point2);
            polygon1.Points.Add(point3);
            polygon1.Points.Add(point4);

            // polygon 2
            MyPolygon polygon2 = new MyPolygon();

            MyPoint point5 = new MyPoint(new Point(210, 210), ref polygon);
            MyPoint point6 = new MyPoint(new Point(310, 210), ref polygon);
            MyPoint point7 = new MyPoint(new Point(210, 320), ref polygon);

            int length = 100;

            point5.lengthConstraint = new LengthConstraint(length, ref point6);
            point6.lengthConstraint = new LengthConstraint(length, ref point5);

            point6.Move(point6.P, -1);

            polygon2.Points.Add(point5);
            polygon2.Points.Add(point6);
            polygon2.Points.Add(point7);

            // Draw
            polygons.Add(polygon1);
            polygons.Add(polygon2);

            DrawPolygons();
            pictureBox.Refresh();
        }

        private void TryRemoveConstraint(Point p)
        {
            SelectedPoint point = FindEdge(p);
            if (point.pointIndex == -1) return;
            if (point.pointIndex == 0)
            {
                polygons[point.polygonIndex].Points[0].RemoveConstraints();
                polygons[point.polygonIndex].Points[^1].RemoveConstraints();
            }
            else
            {
                polygons[point.polygonIndex].Points[point.pointIndex - 1].RemoveConstraints();
                polygons[point.polygonIndex].Points[point.pointIndex].RemoveConstraints();
            }           
        }
    }
}