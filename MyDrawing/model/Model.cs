using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public class Model
    {
        // 維護圖形清單的增刪查
        private Shapes shapes = new Shapes();

        public string[] GetShapeTypesName()
        {
            return Enum.GetNames(typeof(ShapeFactory.ShapeType));
        }

        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        public bool TryCreateShape(string strShapeType, string strContent, string strX, string strY, string strHeight, string strWidth)
        {
            // 檢查資料是否都有填寫
            try
            {
                ShapeFactory.ShapeType shapeType = (ShapeFactory.ShapeType)Enum.Parse(typeof(ShapeFactory.ShapeType), strShapeType);
                // 內容為空也不被認可
                if (strContent == string.Empty)
                    throw new ArgumentNullException("strContent is empty");
                int x = int.Parse(strX);
                int y = int.Parse(strY);
                int height = int.Parse(strHeight);
                int width = int.Parse(strWidth);
                this.CreateShape(shapeType, strContent, x, y, height, width);
                return true;
            }
            catch
            {
                return false;
            }
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
