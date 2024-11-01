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
            PointF[] pointFs = new PointF[4];
            pointFs[0] = new PointF(X + Width / 2, Y);
            pointFs[1] = new PointF(X + Width, Y + Height / 2);
            pointFs[2] = new PointF(X + Width / 2, Y + Height);
            pointFs[3] = new PointF(X, Y + Height / 2);
            graphics.DrawPolygon(pointFs);
            this.DrawContent(graphics);
        }
    }
}
