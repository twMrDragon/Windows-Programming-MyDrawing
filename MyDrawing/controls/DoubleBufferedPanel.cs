using System.Windows.Forms;

namespace MyDrawing.controls
{
    public class DoubleBufferedPanel : Panel
    {
        public bool IsDoubleBufferedEnabled
        {
            get { return this.DoubleBuffered; }
        }

        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
