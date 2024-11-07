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

        public void CreateShape(Shape.Type shapeType, string content, int x, int y, int width, int height)
        {
            Shape shape = ShapeFactory.CreateShape(shapeType);
            shape.Content = content;
            shape.X = x;
            shape.Y = y;
            shape.Width = width;
            shape.Height = height;
            shapes.Add(shape);
        }

        public void RemoveShapeByIndex(int index)
        {
            shapes.RemoveAt(index);
        }

        public void AddShape(Shape shape)
        {
            this.shapes.Add(shape);
        }
    }
}
