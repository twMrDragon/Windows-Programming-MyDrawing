using MyDrawing.graphics;

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
    }
}
