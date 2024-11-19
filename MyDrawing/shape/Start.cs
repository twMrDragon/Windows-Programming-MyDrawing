using MyDrawing.graphics;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    internal class Start : Shape
    {

        public Start()
        {
            this.ShapeName = "Start";
        }
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);
            this.DrawContent(graphics);
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(X, Y, Width, Height);
            return graphicsPath.IsVisible((float)x, (float)y);
        }
    }
}
