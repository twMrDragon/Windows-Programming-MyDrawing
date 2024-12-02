using MyDrawing.graphics;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Process : Shape
    {
        public Process()
        {
            this.ShapeName = "Process";
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X, Y, Width, Height);
            this.DrawContent(graphics);
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(X, Y, X + Width, Y);
            graphicsPath.AddLine(X + Width, Y, X + Width, Y + Height);
            graphicsPath.AddLine(X + Width, Y + Height, X, Y + Height);
            graphicsPath.AddLine(X, Y + Height, X, Y);
            graphicsPath.CloseAllFigures();
            return graphicsPath.IsVisible((float)x, (float)y);
        }
    }
}
