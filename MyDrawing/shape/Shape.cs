using MyDrawing.graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Size size = TextRenderer.MeasureText(this.Content, new Font("Arial", 7));
            double offsetX = (Width - size.Width) / 2.0;
            double offsetY = (Height - size.Height) / 2.0;
            graphics.DrawString(this.Content, X + offsetX, Y + offsetY);
        }
    }
}
