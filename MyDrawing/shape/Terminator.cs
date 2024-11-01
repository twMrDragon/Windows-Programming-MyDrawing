using MyDrawing.graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.shape
{
    internal class Terminator : Shape
    {
        public Terminator()
        {
            this.ShapeName = "Terminator";
        }
        public override void Draw(IGraphics graphics)
        {
            try
            {
                graphics.DrawArc(X, Y, Height, Height, 90, 180);
                graphics.DrawArc(X + Width - Height, Y, Height, Height, 270, 180);
                graphics.DrawLine(X + Height / 2, Y, X + Width - Height / 2, Y);
                graphics.DrawLine(X + Height / 2, Y + Height, X + Width - Height / 2, Y + Height);
                this.DrawContent(graphics);
            }
            catch
            {
            }
        }
    }
}
