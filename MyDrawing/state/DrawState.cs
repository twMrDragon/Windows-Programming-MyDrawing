using MyDrawing.presentationModel;
using System;
using System.Text;

namespace MyDrawing.state
{
    class DrawState : IState
    {
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
            this.model.notCompleteShape = ShapeFactory.CreateShape(this.model.notCompleteShapeType);
            this.model.NotifiyModelChange();
        }

        public void MouseMove(double x, double y)
        {
            if (!isPressed)
                return;
            this.secondX = x;
            this.secondY = y;
            FixNotCompletedShape();
            this.model.NotifiyModelChange();
        }

        public void MouseUp(double x, double y)
        {
            if (!isPressed)
                return;
            isPressed = false;
            this.secondX = x;
            this.secondY = y;
            this.model.notCompleteShape.Content = GenerateRandomContent();
            FixNotCompletedShape();
            this.model.AddShapeFromNotComplete();
            this.model.selectedShape = this.model.notCompleteShape;
            this.model.notCompleteShape = null;
            this.presentationModel.SetToPointState();
            this.model.NotifiyModelChange();
        }

        private void FixNotCompletedShape()
        {
            double smallerX = firstX < secondX ? firstX : secondX;
            double largerX = firstX < secondX ? secondX : firstX;
            double smallerY = firstY < secondY ? firstY : secondY;
            double largerY = firstY < secondY ? secondY : firstY;
            this.model.notCompleteShape.X = (int)smallerX;
            this.model.notCompleteShape.Y = (int)smallerY;
            this.model.notCompleteShape.Width = (int)(largerX - smallerX);
            this.model.notCompleteShape.Height = (int)(largerY - smallerY);
        }

        static private string GenerateRandomContent()
        {
            Random random = new Random();
            int length = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                result.Append(chars[random.Next(chars.Length)]);

            return result.ToString();
        }
    }
}
