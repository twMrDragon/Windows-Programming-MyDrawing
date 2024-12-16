using MyDrawing.shape;

namespace MyDrawing.command
{
    public class TextChangeCommand : ICommand
    {
        Shape shape;
        string newContent;
        string originContent;

        public TextChangeCommand(Shape shape, string newContent)
        {
            this.shape = shape;
            this.newContent = newContent;
        }
        public void Execute()
        {
            this.originContent = shape.Content;
            this.shape.Content = newContent;
        }

        public void UnExecute()
        {
            this.shape.Content = originContent;
        }
    }
}
