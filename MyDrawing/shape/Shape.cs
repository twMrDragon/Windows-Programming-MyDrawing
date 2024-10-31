using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.shape
{
    public class Shape
    {
        public string ShapeName { get; set; }

        public string Content { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //public abstract void OnDraw(Graphics graphics);
    }
}
