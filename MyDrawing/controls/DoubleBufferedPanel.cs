using System.Windows.Forms;

namespace MyDrawing.controls
{
    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
