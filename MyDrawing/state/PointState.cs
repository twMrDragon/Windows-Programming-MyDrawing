using MyDrawing.command;
using MyDrawing.presentationModel;
using MyDrawing.shape;
using System.Collections.Generic;

namespace MyDrawing.state
{
    public class PointState : IState
    {
        readonly Model model;
        readonly PresentationModel presentationModel;

        bool isPressed = false;
        double startX = 0, startY = 0;
        double pointX = 0, pointY = 0;
        readonly bool[] lastIsPressContent = { false, false };
        readonly Shape[] lastSelectShape = { null, null };
        MoveCommand moveCommand;
        TextMoveCommand textMoveCommand;

        public PointState(Model model, PresentationModel presentationModel)
        {
            this.model = model;
            this.presentationModel = presentationModel;
        }

        public void MouseDown(double x, double y)
        {
            if (!(x > 0 && y > 0))
                return;
            isPressed = true;

            lastSelectShape[1] = this.model.SelectedShape;
            lastSelectShape[0] = lastSelectShape[1];
            lastIsPressContent[0] = lastIsPressContent[1];
            this.model.SelectedShape = null;
            IList<Shape> shapes = this.model.GetShapes();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                // 點擊已選形狀的文字的控制點
                lastIsPressContent[1] = (this.lastSelectShape[1] == shapes[i]) && (shapes[i].IsPointInContentControlPoint(x, y));
                if (lastIsPressContent[1])
                {
                    this.model.SelectedShape = shapes[i];
                    textMoveCommand = new TextMoveCommand(this.model.SelectedShape);
                    textMoveCommand.SetStartPoint(x, y);
                    break;
                }

                // 點選形狀
                if (shapes[i].IsPointIn(x, y))
                {
                    this.model.SelectedShape = shapes[i];
                    moveCommand = new MoveCommand(this.model.SelectedShape);
                    moveCommand.SetStartPoint(x, y);
                    break;
                }
            }
            lastSelectShape[1] = this.model.SelectedShape;
            startX = x;
            startY = y;
            pointX = x;
            pointY = y;
        }

        public void MouseMove(double x, double y)
        {
            if (!isPressed)
                return;
            if (this.model.SelectedShape == null)
                return;
            double dX = x - pointX;
            double dY = y - pointY;
            if (this.lastIsPressContent[1])
            {
                this.model.SelectedShape.ContentRelativelyX += (int)dX;
                this.model.SelectedShape.ContentRelativelyY += (int)dY;
            }
            else
            {
                this.model.SelectedShape.X += (int)dX;
                this.model.SelectedShape.Y += (int)dY;
            }
            pointX = x;
            pointY = y;
        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed)
                return;
            isPressed = false;
            if (this.model.SelectedShape == null)
                return;
            if (this.lastIsPressContent[1])
            {
                this.model.SelectedShape.ContentRelativelyX += (int)(x - pointX);
                this.model.SelectedShape.ContentRelativelyY += (int)(y - pointY);
                if (startX == x && startY == y)
                    return;
                textMoveCommand.SetEndPoint(x, y);
                this.presentationModel.Execute(textMoveCommand);
                textMoveCommand = null;
            }
            else
            {
                this.model.SelectedShape.X += (int)(x - pointX);
                this.model.SelectedShape.Y += (int)(y - pointY);
                if (startX == x && startY == y)
                    return;
                moveCommand.SetEndPoint(x, y);
                this.presentationModel.Execute(moveCommand);
                moveCommand = null;
            }
        }

        public bool IsContentDoubleClick()
        {
            bool sameShapeFlag = (this.model.SelectedShape == lastSelectShape[1]) && (lastSelectShape[0] == lastSelectShape[1]);
            bool contentClickFlag = this.lastIsPressContent[1] && this.lastIsPressContent[0];
            return sameShapeFlag && contentClickFlag;
        }
    }
}
