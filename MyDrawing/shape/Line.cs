using MyDrawing.graphics;
using System;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Line : Shape
    {
        public Line()
        {
            this.ShapeName = "Line";
            this.ShapeType = Shape.Type.Line;
        }

        private Shape startShape;
        private Shape endShape;
        private int startX;
        private int startY;
        private int endX;
        private int endY;
        private Shape.ConnectPoint startShapeConnectPoint;
        private Shape.ConnectPoint endShapeConnectPoint;

        public Shape StartShape
        {
            get => startShape;
            set
            {
                if (startShape != value)
                {
                    startShape = value;
                    OnPropertyChanged();
                }
            }
        }
        public Shape EndShape
        {
            get => endShape;
            set
            {
                if (endShape != value)
                {
                    endShape = value;
                    OnPropertyChanged();
                }
            }
        }

        public int StartX
        {
            get => startX;
            set
            {
                if (startX != value)
                {
                    startX = value;
                    OnPropertyChanged();
                }
            }
        }
        public int StartY
        {
            get => startY;
            set
            {
                if (startY != value)
                {
                    startY = value;
                    OnPropertyChanged();
                }
            }
        }
        public int EndX
        {
            get => endX;
            set
            {
                if (endX != value)
                {
                    endX = value;
                    OnPropertyChanged();
                }
            }
        }
        public int EndY
        {
            get => endY;
            set
            {
                if (endY != value)
                {
                    endY = value;
                    OnPropertyChanged();
                }
            }
        }
        public override int X
        {
            get
            {
                int startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
                int endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
                return Math.Min(startX, endX);
            }
        }

        public override int Y
        {
            get
            {
                int startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
                int endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;
                return Math.Min(startY, endY);
            }
        }

        public override int Width
        {
            get
            {
                int startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
                int endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
                return Math.Abs(startX - endX);
            }
        }

        public override int Height
        {
            get
            {
                int startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
                int endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;
                return Math.Abs(startY - endY);
            }
        }

        public Shape.ConnectPoint StartShapeConnectPoint
        {
            get => startShapeConnectPoint;
            set
            {
                if (startShapeConnectPoint != value)
                {
                    startShapeConnectPoint = value;
                    OnPropertyChanged();
                }
            }
        }
        public Shape.ConnectPoint EndShapeConnectPoint
        {
            get => endShapeConnectPoint;
            set
            {
                if (endShapeConnectPoint != value)
                {
                    endShapeConnectPoint = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SetStartConnectPoint(Shape startShape, Shape.ConnectPoint connectPoint)
        {
            this.StartShape = startShape;
            this.StartShapeConnectPoint = connectPoint;
            this.EndX = startShape.GetPointX(connectPoint);
            this.EndY = startShape.GetPointY(connectPoint);
        }
        public void SetEndConnectPoint(Shape endShape, Shape.ConnectPoint connectPoint)
        {
            this.EndShape = endShape;
            this.EndShapeConnectPoint = connectPoint;
        }

        public override void DrawShape(IGraphics graphics)
        {
            int startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
            int startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
            int endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
            int endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;

            graphics.SetColor("#000000");
            graphics.DrawLine(startX, startY, endX, endY);
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
            int startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
            int endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
            int endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;
            graphicsPath.AddLine(startX, startY, endX, endY);
            return graphicsPath.IsVisible((int)x, (int)y);
        }
    }
}
