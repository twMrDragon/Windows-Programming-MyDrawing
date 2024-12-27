using MyDrawing.command;
using MyDrawing.presentationModel;
using MyDrawing.shape;
using MyDrawing.utils;

namespace MyDrawing.state
{
    public class DrawState : IState
    {
        public Shape.Type notCompleteShapeType;
        readonly Model model;
        readonly PresentationModel presentationModel;

        bool isPressed = false;
        double firstX = 0;
        double firstY = 0;
        double secondX = 0;
        double secondY = 0;

        public DrawState(Model model, PresentationModel presentationModel)
        {
            this.model = model;
            this.presentationModel = presentationModel;
        }

        public void MouseDown(double x, double y)
        {
            if (!(x > 0 && y > 0))
                return;

            isPressed = true;
            firstX = x;
            firstY = y;
            this.model.NotCompleteShape = ShapeFactory.CreateShape(this.notCompleteShapeType);
        }

        public void MouseMove(double x, double y)
        {
            if (!isPressed)
                return;
            this.secondX = x;
            this.secondY = y;
            FixNotCompletedShape();
        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed)
                return;
            isPressed = false;

            this.secondX = x;
            this.secondY = y;
            FixNotCompletedShape();
            this.model.NotCompleteShape.Content = Utils.GenerateRandomString();
            this.presentationModel.Execute(new DrawCommand(this.model, this.model.NotCompleteShape));
            this.model.SelectedShape = this.model.NotCompleteShape;
            this.model.NotCompleteShape = null;
            this.presentationModel.SetToPointState();
        }

        private void FixNotCompletedShape()
        {
            double smallerX = firstX < secondX ? firstX : secondX;
            double largerX = firstX < secondX ? secondX : firstX;
            double smallerY = firstY < secondY ? firstY : secondY;
            double largerY = firstY < secondY ? secondY : firstY;
            this.model.NotCompleteShape.X = (int)smallerX;
            this.model.NotCompleteShape.Y = (int)smallerY;
            this.model.NotCompleteShape.Width = (int)(largerX - smallerX);
            this.model.NotCompleteShape.Height = (int)(largerY - smallerY);
            this.model.NotCompleteShape.ContentRelativelyX = this.model.NotCompleteShape.Width / 2;
            this.model.NotCompleteShape.ContentRelativelyY = this.model.NotCompleteShape.Height / 2;
        }
    }
}
