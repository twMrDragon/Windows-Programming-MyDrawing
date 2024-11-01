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

        public List<Shape> GetShapes()
        {
            return shapes;
        }

        public void CreateShape(ShapeFactory.ShapeType shapeType, string content, int x, int y, int height, int width)
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

        public void AddShapes(Shape shape)
        {
            this.shapes.Add(shape);
        }
    }
}
