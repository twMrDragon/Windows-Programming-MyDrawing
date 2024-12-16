using MyDrawing.shape;

namespace MyDrawing.command
{
    public class DeleteCommand : ICommand
    {
        Model model;
        Shape shape;
        int index;
        public DeleteCommand(Model model, int index)
        {
            this.model = model;
            this.index = index;
        }

        public void Execute()
        {
            this.shape = this.model.GetShapes()[index];
            this.model.RemoveShapeAt(index);
        }

        public void UnExecute()
        {
            this.model.InsertShape(this.index, this.shape);
        }
    }
}
