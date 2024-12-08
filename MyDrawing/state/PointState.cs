﻿using MyDrawing.shape;
using System.Collections.Generic;

namespace MyDrawing.state
{
    public class PointState : IState
    {
        readonly Model model;

        bool isPressed = false;
        double firstX = 0;
        double firstY = 0;

        public PointState(Model model)
        {
            this.model = model;
        }

        public void MouseDown(double x, double y)
        {
            this.model.selectedShape = null;
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                if (shapes[i].IsPointIn(x, y))
                {
                    this.model.selectedShape = shapes[i];
                    break;
                }
            }
            this.model.NotifiyModelChange();
            if (this.model.selectedShape == null)
                return;
            isPressed = true;
            firstX = x;
            firstY = y;
        }

        public void MouseMove(double x, double y)
        {
            if (!isPressed)
                return;
            if (this.model.selectedShape == null)
                return;
            double dX = x - firstX;
            double dY = y - firstY;
            this.model.selectedShape.X += (int)dX;
            this.model.selectedShape.Y += (int)dY;
            firstX = x;
            firstY = y;
            this.model.NotifiyModelChange();
        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed)
                return;
            if (this.model.selectedShape == null)
                return;
            isPressed = false;
            this.model.selectedShape.X += (int)(x - firstX);
            this.model.selectedShape.Y += (int)(y - firstY);
            this.model.NotifiyModelChange();
        }
    }
}
