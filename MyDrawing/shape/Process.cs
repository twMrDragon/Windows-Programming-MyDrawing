using MyDrawing.graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
