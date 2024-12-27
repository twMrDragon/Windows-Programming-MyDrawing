using MyDrawing.shape;

namespace MyDrawing.command
{
    public class TextMoveCommand : ICommand
    {
        Shape shape;
        double startX, startY;
        double endX, endY;
        bool firstTimeFlag = true;

        public TextMoveCommand(Shape shape)
        {
            this.shape = shape;
        }

        public void SetStartPoint(double startX, double startY)
        {
            this.startX = startX;
            this.startY = startY;
        }
        public void SetEndPoint(double endX, double endY)
        {
            this.endX = endX;
            this.endY = endY;
        }

        public void Execute()
        {
            if (firstTimeFlag)
            {
                firstTimeFlag = false;
                return;
            }
            this.shape.ContentRelativelyX += (int)(endX - startX);
            this.shape.ContentRelativelyY += (int)(endY - startY);
        }

        public void UnExecute()
        {
            this.shape.ContentRelativelyX -= (int)(endX - startX);
            this.shape.ContentRelativelyY -= (int)(endY - startY);
        }
    }
}
