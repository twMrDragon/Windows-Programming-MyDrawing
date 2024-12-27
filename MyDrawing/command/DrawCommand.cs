using MyDrawing.shape;

namespace MyDrawing.command
{
    public class DrawCommand : ICommand
    {
        Model model;
        Shape shape;
        int index;

        public DrawCommand(Model model, Shape shape)
        {
            this.model = model;
            this.shape = shape;
        }
        public void Execute()
        {
            this.index = this.model.GetShapes().Count;
            this.model.AddShape(this.shape);
        }

        public void UnExecute()
        {
            this.model.RemoveShapeAt(index);
        }
    }
}
