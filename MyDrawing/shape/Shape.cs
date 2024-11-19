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

        public abstract void Draw(IGraphics graphics);

        public void DrawContent(IGraphics graphics)
        {
            double centerX = X + Width / 2;
            double centerY = Y + Height / 2;
            graphics.DrawString(this.Content, centerX, centerY);
        }
    }
}
