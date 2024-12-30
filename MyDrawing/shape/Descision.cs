using MyDrawing.graphics;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Descision : Shape
    {
        public Descision()
        {
            this.ShapeName = "Descision";
            this.ShapeType = Shape.Type.Descision;
        }
        public override void DrawShape(IGraphics graphics)
        {
            double[] x = new double[4];
            double[] y = new double[4];
            x[0] = X + Width / 2;
            y[0] = Y;
            x[1] = X + Width;
            y[1] = Y + Height / 2;
            x[2] = X + Width / 2;
            y[2] = Y + Height;
            x[3] = X;
            y[3] = Y + Height / 2;
            graphics.SetColor("#000000");
            graphics.DrawPolygon(x, y);
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(X + Width / 2, Y, X + Width, Y + Height / 2);
            graphicsPath.AddLine(X + Width, Y + Height / 2, X + Width / 2, Y + Height);
            graphicsPath.AddLine(X + Width / 2, Y + Height, X, Y + Height / 2);
            graphicsPath.AddLine(X, Y + Height / 2, X + Width / 2, Y);
            graphicsPath.CloseAllFigures();
            return graphicsPath.IsVisible((float)x, (float)y);
        }
    }
}
