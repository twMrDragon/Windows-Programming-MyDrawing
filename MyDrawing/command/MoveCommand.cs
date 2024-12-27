using MyDrawing.shape;

namespace MyDrawing.command
{
    public class MoveCommand : ICommand
    {
        Shape shape;
        double startX, startY;
        double endX, endY;
        bool firstTimeFlag = true;

        public MoveCommand(Shape shape)
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
            // 因為是在 mouseup 才建立，所以第一次不要動
            if (firstTimeFlag)
            {
                firstTimeFlag = false;
                return;
            }
            this.shape.X += (int)(endX - startX);
            this.shape.Y += (int)(endY - startY);
        }

        public void UnExecute()
        {
            this.shape.X -= (int)(endX - startX);
            this.shape.Y -= (int)(endY - startY);
        }
    }
}
