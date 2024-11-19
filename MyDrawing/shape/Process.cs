using MyDrawing.graphics;

namespace MyDrawing.shape
{
    internal class Process : Shape
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
    }
}
