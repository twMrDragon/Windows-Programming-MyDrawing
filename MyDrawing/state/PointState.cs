using MyDrawing.shape;
using System.Collections.Generic;

namespace MyDrawing.state
{
    public class PointState : IState
    {
        readonly Model model;

        bool isPressed = false;
        double firstX = 0;
        double firstY = 0;
        bool isPressContent = false;
        Shape lastSelectShape = null;

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
                // 點擊已選形狀的文字的控制點
                isPressContent = (this.lastSelectShape == shapes[i]) && (shapes[i].IsPointInContentControlPoint(x, y));
                if (isPressContent)
                {
                    this.model.selectedShape = lastSelectShape;
                    break;
                }

                // 點選形狀
                if (shapes[i].IsPointIn(x, y))
                {
                    this.model.selectedShape = shapes[i];
                    break;
                }
            }
            lastSelectShape = this.model.selectedShape;
            this.model.NotifiyModelChange();
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
            if (this.isPressContent)
            {
                this.model.selectedShape.ContentRelativelyX += (int)dX;
                this.model.selectedShape.ContentRelativelyY += (int)dY;
            }
            else
            {
                this.model.selectedShape.X += (int)dX;
                this.model.selectedShape.Y += (int)dY;
            }
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
            if (this.isPressContent)
            {
                this.model.selectedShape.ContentRelativelyX += (int)(x - firstX);
                this.model.selectedShape.ContentRelativelyY += (int)(y - firstY);
            }
            else
            {
                this.model.selectedShape.X += (int)(x - firstX);
                this.model.selectedShape.Y += (int)(y - firstY);
            }
            this.model.NotifiyModelChange();
        }
    }
}
