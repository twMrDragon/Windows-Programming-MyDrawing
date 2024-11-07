using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.shape
{
    internal class Shapes
    {
        // 保存當前圖形
        private List<Shape> shapes = new List<Shape>();
        // 創建圖形寫在 ShapeFactory
        private ShapeFactory factory = new ShapeFactory();

        public IList<Shape> GetShapes()
        {
            return shapes.AsReadOnly();
        }

        public void CreateShape(Shape.Type shapeType, string content, int x, int y, int width, int height)
        {
            Shape shape = factory.CreateShape(shapeType);
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
