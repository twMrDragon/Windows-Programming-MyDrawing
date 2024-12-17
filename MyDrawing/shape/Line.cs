using MyDrawing.graphics;

namespace MyDrawing.shape
{
    public class Line
    {
        // Observer pattern
        public delegate void PropertyChangedEventHandler();
        public event PropertyChangedEventHandler PropertyChanged;

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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
                }
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
                    PropertyChanged?.Invoke();
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
                    PropertyChanged?.Invoke();
                }
            }
        }

        public void Draw(IGraphics graphics)
        {
            int startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
            int startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
            int endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
            int endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;

            graphics.SetColor("#000000");
            graphics.DrawLine(startX, startY, endX, endY);
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
    }
}
