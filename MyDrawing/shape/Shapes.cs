using System.Collections.Generic;

namespace MyDrawing.shape
{
    internal class Shapes
    {
        // 保存當前圖形
        readonly private List<Shape> shapes = new List<Shape>();

        public IList<Shape> GetShapes()
        {
            return shapes.AsReadOnly();
        }

        public void RemoveShapeAt(int index)
        {
            shapes.RemoveAt(index);
        }

        public void AddShape(Shape shape)
        {
            this.shapes.Add(shape);
        }
    }
}
