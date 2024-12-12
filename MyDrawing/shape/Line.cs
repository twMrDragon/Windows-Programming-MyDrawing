using MyDrawing.graphics;

namespace MyDrawing.shape
{
    public class Line
    {
        public Shape StartShape { get; set; }
        public Shape EndShape { get; set; }

        public double StartX { get; set; }
        public double StartY { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }

        public Shape.ConnectPoint StartShapeConnectPoint { get; set; }
        public Shape.ConnectPoint EndShapeConnectPoint { get; set; }

        public void Draw(IGraphics graphics)
        {
            double startX = StartShape != null ? StartShape.GetPointX(StartShapeConnectPoint) : StartX;
            double startY = StartShape != null ? StartShape.GetPointY(StartShapeConnectPoint) : StartY;
            double endX = EndShape != null ? EndShape.GetPointX(EndShapeConnectPoint) : EndX;
            double endY = EndShape != null ? EndShape.GetPointY(EndShapeConnectPoint) : EndY;

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
