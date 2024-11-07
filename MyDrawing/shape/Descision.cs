using MyDrawing.graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.shape
{
    internal class Descision : Shape
    {
        public Descision()
        {
            this.ShapeName = "Descision";
        }
        public override void Draw(IGraphics graphics)
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
            graphics.DrawPolygon(x,y);
            this.DrawContent(graphics);
        }
    }
}
