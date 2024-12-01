namespace MyDrawing.state
{
    public interface IState
    {
        void MouseDown(double x, double y);
        void MouseUp(double x, double y);
        void MouseMove(double x, double y);
    }
}
