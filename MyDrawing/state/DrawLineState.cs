using MyDrawing.command;
using MyDrawing.presentationModel;
using MyDrawing.shape;
using System.Collections.Generic;

namespace MyDrawing.state
{
    public class DrawLineState : IState
    {
        readonly private Model model;
        readonly private PresentationModel presentationModel;
        private bool isPressed = false;
        private List<Shape.ConnectPoint> connectPoints = new List<Shape.ConnectPoint>() { Shape.ConnectPoint.Top, Shape.ConnectPoint.Right, Shape.ConnectPoint.Bottom, Shape.ConnectPoint.Left };

        public DrawLineState(Model model, PresentationModel presentationModel)
        {
            this.model = model;
            this.presentationModel = presentationModel;
        }

        public void MouseDown(double x, double y)
        {
            if (!(x > 0 && y > 0))
                return;

            isPressed = true;

            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                bool inConnectPointFlag = false;
                foreach (Shape.ConnectPoint connectPoint in connectPoints)
                {
                    if (shapes[i].IsPointInConnectPoint(x, y, connectPoint))
                    {
                        inConnectPointFlag = true;
                        this.model.NotCompleteLine = new Line();
                        this.model.NotCompleteLine.SetStartConnectPoint(shapes[i], connectPoint);
                        return;
                    }
                }
            }
        }

        public void MouseMove(double x, double y)
        {
            this.model.HoverShape = null;
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                // 經過形狀
                if (shapes[i].IsPointIn(x, y) ||
                    shapes[i].IsPointInConnectPoint(x, y, Shape.ConnectPoint.Top) ||
                    shapes[i].IsPointInConnectPoint(x, y, Shape.ConnectPoint.Right) ||
                    shapes[i].IsPointInConnectPoint(x, y, Shape.ConnectPoint.Bottom) ||
                    shapes[i].IsPointInConnectPoint(x, y, Shape.ConnectPoint.Left))
                {
                    this.model.HoverShape = shapes[i];
                    break;
                }
            }

            if (!isPressed)
                return;
            if (this.model.NotCompleteLine == null)
                return;

            this.model.NotCompleteLine.EndX = (int)x;
            this.model.NotCompleteLine.EndY = (int)y;

        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed)
                return;
            isPressed = false;

            if (this.model.NotCompleteLine == null)
                return;

            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                foreach (Shape.ConnectPoint connectPoint in connectPoints)
                {
                    if (shapes[i].IsPointInConnectPoint(x, y, connectPoint))
                    {
                        // 同一個形狀同一個連接點
                        bool sameShapeFlag = this.model.NotCompleteLine.StartShape == shapes[i];
                        bool sameConnectPointFlag = this.model.NotCompleteLine.StartShapeConnectPoint == connectPoint;
                        if (sameShapeFlag && sameConnectPointFlag)
                            break;

                        this.model.NotCompleteLine.SetEndConnectPoint(shapes[i], connectPoint);
                        this.presentationModel.Execute(new DarwLineCommand(this.model, this.model.NotCompleteLine));
                        this.model.NotCompleteLine = null;
                        return;
                    }
                }
            }
            this.model.NotCompleteLine = null;
        }
    }
}
