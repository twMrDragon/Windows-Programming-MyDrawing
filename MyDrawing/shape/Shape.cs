using MyDrawing.graphics;
using MyDrawing.utils;
using System.Drawing.Drawing2D;

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

        public enum ConnectPoint
        {
            Top,
            Right,
            Bottom,
            Left
        }

        public string ShapeName { get; set; }

        public string Content { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        // 相對於圖案左上角
        public int ContentRelativelyX { get; set; }
        public int ContentRelativelyY { get; set; }

        public abstract void DrawShape(IGraphics graphics);
        public abstract bool IsPointIn(double x, double y);

        public bool IsPointInContentControlPoint(double x, double y)
        {
            if (string.IsNullOrEmpty(this.Content))
                return false;
            GraphicsPath graphicsPath = new GraphicsPath();
            double height = Utils.CalculateStringHeight(Content);
            double size = 9;
            double ellipseX = ContentRelativelyX - size / 2 + X;
            double ellipseY = ContentRelativelyY - size / 2 - height / 2 + Y;
            graphicsPath.AddEllipse((int)ellipseX, (int)ellipseY, (int)size, (int)size);
            return graphicsPath.IsVisible((float)x, (float)y);
        }

        public bool IsPointInTopConnectPoint(double x, double y, ConnectPoint connectPoint)
        {
            GraphicsPath graphics = new GraphicsPath();
            int radius = 6;
            int diameter = radius * 2;
            if (connectPoint == ConnectPoint.Top)
                graphics.AddEllipse(X + Width / 2 - radius, Y - radius, diameter, diameter);
            else if (connectPoint == ConnectPoint.Right)
                graphics.AddEllipse(X + Width - radius, Y + Height / 2 - radius, diameter, diameter);
            else if (connectPoint == ConnectPoint.Bottom)
                graphics.AddEllipse(X + Width / 2 - radius, Y + Height - radius, diameter, diameter);
            else if (connectPoint == ConnectPoint.Left)
                graphics.AddEllipse(X - radius, Y + Height / 2 - radius, diameter, diameter);
            return graphics.IsVisible((float)x, (float)y);
        }

        public void DrawContent(IGraphics graphics)
        {
            if (string.IsNullOrEmpty(this.Content))
                return;
            double centerX = X + ContentRelativelyX;
            double centerY = Y + ContentRelativelyY;
            graphics.SetColor("#000000");
            graphics.DrawString(this.Content, centerX, centerY);
        }

        public void DrawContentBorder(IGraphics graphics)
        {
            if (string.IsNullOrEmpty(this.Content))
                return;
            double width = Utils.CalculateStringWidth(this.Content);
            double height = Utils.CalculateStringHeight(this.Content);
            double x = ContentRelativelyX - width / 2 + X;
            double y = ContentRelativelyY - height / 2 + Y;
            graphics.SetColor("#FF0000");
            graphics.DrawRectangle(x, y, width, height);

            double size = 9;
            x = ContentRelativelyX - size / 2 + X;
            y = ContentRelativelyY - size / 2 - height / 2 + Y;
            graphics.SetColor("#f28500");
            graphics.FillEllipse(x, y, size, size);
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

        public void DrawConnectPoint(IGraphics graphics)
        {
            graphics.SetColor("#808080");
            int radius = 6;
            int diameter = radius * 2;
            graphics.FillEllipse(X + Width / 2 - radius, Y - radius, diameter, diameter);
            graphics.FillEllipse(X + Width - radius, Y + Height / 2 - radius, diameter, diameter);
            graphics.FillEllipse(X + Width / 2 - radius, Y + Height - radius, diameter, diameter);
            graphics.FillEllipse(X - radius, Y + Height / 2 - radius, diameter, diameter);
        }

        public double GetPointX(ConnectPoint connectPoint)
        {
            switch (connectPoint)
            {
                case ConnectPoint.Top:
                    return X + Width / 2;
                case ConnectPoint.Right:
                    return X + Width;
                case ConnectPoint.Bottom:
                    return X + Width / 2;
                case ConnectPoint.Left:
                    return X;
                default:
                    return X;
            }
        }
        public double GetPointY(ConnectPoint connectPoint)
        {
            switch (connectPoint)
            {
                case ConnectPoint.Top:
                    return Y;
                case ConnectPoint.Right:
                    return Y + Height / 2;
                case ConnectPoint.Bottom:
                    return Y + Height;
                case ConnectPoint.Left:
                    return Y + Height / 2;
                default:
                    return Y;
            }
        }
    }
}
