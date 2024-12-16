namespace MyDrawing.command
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
