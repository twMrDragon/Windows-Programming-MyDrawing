using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyDrawing.graphics
{
    internal class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void ClearAll()
        {

        }

        public void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
        {
            this.graphics.DrawArc(Pens.Black, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
        }

        public void DrawEllipse(double x, double y, double width, double height)
        {
            this.graphics.DrawEllipse(Pens.Black, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            this.graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }


        public void DrawPolygon(PointF[] points)
        {
            this.graphics.DrawPolygon(Pens.Black, points);
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            this.graphics.DrawRectangle(Pens.Black, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawString(string s, double x, double y)
        {
            // graphics.DrawString 會把 x y 當成左上角繪製文字
            this.graphics.DrawString(s, new Font("Arial", 7), Brushes.Black, (float)x, (float)y);
        }
    }
}
