﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.graphics
{
    public interface IGraphics
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawRectangle(double x, double y, double width, double height);
        void DrawEllipse(double x, double y, double width, double height);
        void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle);
        void DrawString(string s, double x, double y);
        void DrawPolygon(PointF[] points);
    }
}