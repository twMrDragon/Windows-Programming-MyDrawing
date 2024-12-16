using MyDrawing.shape;

namespace MyDrawing.command
{
    public class DarwLineCommand : ICommand
    {
        Model model;
        Line line;

        public DarwLineCommand(Model model, Line line)
        {
            this.model = model;
            this.line = line;
        }

        public void Execute()
        {
            this.model.AddLine(this.line);
        }

        public void UnExecute()
        {
            this.model.RemoveLineFromEnd();
        }
    }
}
