using MyDrawing.shape;
using System.Collections.Generic;

namespace MyDrawing.state
{
    public class DrawLineState : IState
    {
        readonly private Model model;
        private bool isPressed = false;
        private List<Shape.ConnectPoint> connectPoints = new List<Shape.ConnectPoint>() { Shape.ConnectPoint.Top, Shape.ConnectPoint.Right, Shape.ConnectPoint.Bottom, Shape.ConnectPoint.Left };

        public DrawLineState(Model model)
        {
            this.model = model;
        }
        public void MouseDown(double x, double y)
        {
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                bool flag = false;
                foreach (Shape.ConnectPoint connectPoint in connectPoints)
                {
                    if (shapes[i].IsPointInTopConnectPoint(x, y, connectPoint))
                    {
                        flag = true;
                        this.model.notCompleteLine = new Line();
                        this.model.notCompleteLine.SetStartConnectPoint(shapes[i], connectPoint);
                        break;
                    }
                }
                if (flag)
                {
                    this.model.NotifiyModelChange();
                    break;
                }
            }
            isPressed = true;
        }

        public void MouseMove(double x, double y)
        {
            this.model.hoverShape = null;
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                // 經過形狀
                if (shapes[i].IsPointIn(x, y) ||
                    shapes[i].IsPointInTopConnectPoint(x, y, Shape.ConnectPoint.Top) ||
                    shapes[i].IsPointInTopConnectPoint(x, y, Shape.ConnectPoint.Right) ||
                    shapes[i].IsPointInTopConnectPoint(x, y, Shape.ConnectPoint.Bottom) ||
                    shapes[i].IsPointInTopConnectPoint(x, y, Shape.ConnectPoint.Left))
                {
                    this.model.hoverShape = shapes[i];
                    break;
                }
            }
            if (isPressed && this.model.notCompleteLine != null)
            {
                this.model.notCompleteLine.EndX = x;
                this.model.notCompleteLine.EndY = y;
            }
            this.model.NotifiyModelChange();
        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed || this.model.notCompleteLine == null)
                return;
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                bool flag = false;
                foreach (Shape.ConnectPoint connectPoint in connectPoints)
                {
                    if (shapes[i].IsPointInTopConnectPoint(x, y, connectPoint))
                    {
                        flag = true;

                        // 同一個形狀同一個連接點
                        bool sameShapeFlag = this.model.notCompleteLine.StartShape == this.model.notCompleteLine.EndShape;
                        bool sameConnectPointFlag = this.model.notCompleteLine.StartShapeConnectPoint == this.model.notCompleteLine.EndShapeConnectPoint;
                        if (sameShapeFlag && sameConnectPointFlag)
                            break;

                        this.model.notCompleteLine.SetEndConnectPoint(shapes[i], connectPoint);
                        this.model.AddLineFromNotComplete();
                        break;
                    }
                }
                if (flag)
                    break;
            }
            this.model.notCompleteLine = null;
            this.model.NotifiyModelChange();
            isPressed = false;
        }
    }
}
