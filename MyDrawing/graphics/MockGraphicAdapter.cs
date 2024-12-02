using System.Collections.Generic;

namespace MyDrawing.graphics
{
    public class MockGraphicAdapter : IGraphics
    {

        public IList<string> Command
        {
            get { return this.command.AsReadOnly(); }
        }

        readonly private List<string> command = new List<string>();
        public void ClearAll()
        {
            this.command.Clear();
        }

        public void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
        {
            this.command.Add("DrawArc");
        }

        public void DrawEllipse(double x, double y, double width, double height)
        {
            this.command.Add("DrawEllipse");
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            this.command.Add("DrawLine");
        }

        public void DrawPolygon(double[] x, double[] y)
        {
            this.command.Add("DrawPolygon");
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            this.command.Add("DrawRectangle");
        }

        public void DrawString(string s, double x, double y)
        {
            this.command.Add("DrawString");
        }

        public void SetColor(string hex)
        {
            this.command.Add("SetColor");
        }
    }
}
