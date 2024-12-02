using MyDrawing.graphics;

namespace MyDrawing.shape
{
    public abstract class Shape
    {
        public enum Type
        {
            Start,
            Terminator,
            Process,
            Descision
        }

        public string ShapeName { get; set; }

        public string Content { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void DrawShape(IGraphics graphics);
        public abstract bool IsPointIn(double x, double y);

        public void DrawContent(IGraphics graphics)
        {
            double centerX = X + Width / 2;
            double centerY = Y + Height / 2;
            graphics.SetColor("#000000");
            graphics.DrawString(this.Content, centerX, centerY);
        }

        public void DrawBorder(IGraphics graphics)
        {
            graphics.SetColor("#FF0000");
            graphics.DrawRectangle(X, Y, Width, Height);

            // 邊框圓圈 左上順時鐘
            graphics.SetColor("#808080");
            int radius = 3;
            int diameter = radius * 2;
            graphics.DrawEllipse(X - radius, Y - radius, diameter, diameter);
            graphics.DrawEllipse(X + Width / 2 - radius, Y - radius, diameter, diameter);
            graphics.DrawEllipse(X + Width - radius, Y - radius, diameter, diameter);
            graphics.DrawEllipse(X + Width - radius, Y + Height / 2 - radius, diameter, diameter);
            graphics.DrawEllipse(X + Width - radius, Y + Height - radius, diameter, diameter);
            graphics.DrawEllipse(X + Width / 2 - radius, Y + Height - radius, diameter, diameter);
            graphics.DrawEllipse(X - radius, Y + Height - radius, diameter, diameter);
            graphics.DrawEllipse(X - radius, Y + Height / 2 - radius, diameter, diameter);
        }
    }
}
