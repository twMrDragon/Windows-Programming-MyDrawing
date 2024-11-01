using MyDrawing.graphics;
using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler modelChanged;

        bool isPressed = false;
        ShapeFactory shapeFactory = new ShapeFactory();
        ShapeFactory.ShapeType notCompleteShapeType;
        Shape notCompleteShape;
        double firstX = 0;
        double firstY = 0;
        double secondX = 0;
        double secondY = 0;

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

        public void CreateShape(ShapeFactory.ShapeType shapeType, string content, int x, int y, int width, int height)
        {
            shapes.CreateShape(shapeType, content, x, y, width, height);
            NotifiModelChange();
        }

        public void RemoveShape(int index)
        {
            shapes.RemoveShapeByIndex(index);
            NotifiModelChange();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape item in shapes.GetShapes())
                item.Draw(graphics);
            if (isPressed)
                DrawNotCompletedShape(graphics);
        }
        private void DrawNotCompletedShape(IGraphics graphics)
        {
            double smallerX = firstX < secondX ? firstX : secondX;
            double largerX = firstX < secondX ? secondX : firstX;
            double smallerY = firstY < secondY ? firstY : secondY;
            double largerY = firstY < secondY ? secondY : firstY;
            this.notCompleteShape.X = (int)smallerX;
            this.notCompleteShape.Y = (int)smallerY;
            this.notCompleteShape.Width = (int)(largerX - smallerX);
            this.notCompleteShape.Height = (int)(largerY - smallerY);
            notCompleteShape.Draw(graphics);
        }

        private void NotifiModelChange()
        {
            if (modelChanged != null)
                modelChanged();
        }

        public void DrawingShapeTypeSelect(ShapeFactory.ShapeType shapeType)
        {
            this.notCompleteShapeType = shapeType;
        }

        public void MousePressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                this.notCompleteShape = shapeFactory.CreateShape(this.notCompleteShapeType);
                isPressed = true;
                firstX = x;
                firstY = y;
            }
        }

        public void MouseReleases(double x, double y)
        {
            if (isPressed)
            {
                isPressed = false;
                this.notCompleteShape.Content = RandomContent();
                this.shapes.AddShapes(this.notCompleteShape);
                NotifiModelChange();
            }
        }

        public void MouseMoved(double x, double y)
        {
            this.secondX = x;
            this.secondY = y;
            NotifiModelChange();
        }

        private string RandomContent()
        {
            Random random = new Random();
            int length = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                result.Append(chars[random.Next(chars.Length)]);

            return result.ToString();
        }
    }
}
