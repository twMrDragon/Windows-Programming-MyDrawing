using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public class Model
    {
        // 維護圖形清單的增刪查
        private Shapes shapes = new Shapes();

        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        public void CreateShape(ShapeFactory.ShapeType shapeType, string content, int x, int y, int height, int width)
        {
            shapes.CreateShape(shapeType, content, x, y, height, width);
        }

        public void RemoveShape(int index)
        {
            shapes.RemoveShapeByIndex(index);

        }
    }
}
