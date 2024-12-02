using MyDrawing.graphics;
using System;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Terminator : Shape
    {
        public Terminator()
        {
            this.ShapeName = "Terminator";
        }
        public override void Draw(IGraphics graphics)
        {
            try
            {
                // 參考 visio 修正
                double arcWidth = Math.Min(Height, Width / 2.0);
                graphics.DrawArc(X, Y, arcWidth, Height, 90, 180);
                graphics.DrawArc(X + Width - arcWidth, Y, arcWidth, Height, 270, 180);
                graphics.DrawLine(X + arcWidth / 2, Y, X + Width - arcWidth / 2, Y);
                graphics.DrawLine(X + arcWidth / 2, Y + Height, X + Width - arcWidth / 2, Y + Height);
                this.DrawContent(graphics);
            }
            catch
            {
                // DrawArc 如果 width 或 height 為 0 會報錯
            }
        }

        public override bool IsPointIn(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            double arcWidth = Math.Min(Height, Width / 2.0);
            graphicsPath.AddArc(X, Y, (float)arcWidth, Height, 90, 180);
            graphicsPath.AddLine((float)(X + arcWidth / 2), Y, (float)(X + Width - arcWidth / 2), Y);
            graphicsPath.AddArc((float)(X + Width - arcWidth), Y, (float)arcWidth, Height, 270, 180);
            graphicsPath.AddLine((float)(X + arcWidth / 2), Y + Height, (float)(X + Width - arcWidth / 2), Y + Height);
            graphicsPath.CloseAllFigures();
            return graphicsPath.IsVisible((float)x, (float)y);
        }
    }
}
