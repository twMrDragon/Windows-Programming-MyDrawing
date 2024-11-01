using MyDrawing.graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
