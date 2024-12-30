using MyDrawing.graphics;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Start : Shape
    {

        public Start()
        {
            this.ShapeName = "Start";
            this.ShapeType = Shape.Type.Start;
        }
        public override void DrawShape(IGraphics graphics)
        {
            graphics.SetColor("#000000");
            graphics.DrawEllipse(X, Y, Width, Height);
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(X, Y, Width, Height);
            return graphicsPath.IsVisible((float)x, (float)y);
        }
    }
}
