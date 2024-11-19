﻿using MyDrawing.graphics;
using System;

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
                // 參考 visio 修正
                double arcWidth = Math.Min(Height, Width / 2.0);
                graphics.DrawArc(X, Y, arcWidth, Height, 90, 180);
                graphics.DrawArc(X + Width - arcWidth, Y, arcWidth, Height, 270, 180);
                graphics.DrawLine(X + arcWidth / 2, Y, X + Width - arcWidth / 2, Y);
                graphics.DrawLine(X + arcWidth / 2, Y + Height, X + Width - arcWidth / 2, Y + Height);
                this.DrawContent(graphics);
            }
            catch
            {
                // DrawArc 如果 width 或 height 為 0 會報錯
            }
        }
    }
}
