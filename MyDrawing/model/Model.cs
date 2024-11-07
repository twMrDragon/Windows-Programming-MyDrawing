using MyDrawing.graphics;
using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDrawing
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // 維護圖形清單的增刪查
        readonly private Shapes shapes = new Shapes();

        bool isPressed = false;
        Shape.Type notCompleteShapeType;
        Shape notCompleteShape;
        double firstX = 0;
        double firstY = 0;
        double secondX = 0;
        double secondY = 0;

        static public string[] GetShapeTypesName()
        {
            return Enum.GetNames(typeof(Shape.Type));
        }

        public IList<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        public void CreateShape(Shape.Type shapeType, string content, int x, int y, int width, int height)
        {
            shapes.CreateShape(shapeType, content, x, y, width, height);
            NotifiyModelChange();
        }

        public void RemoveShape(int index)
        {
            shapes.RemoveShapeByIndex(index);
            NotifiyModelChange();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape item in shapes.GetShapes())
                item.Draw(graphics);
            if (isPressed)
            {
                FixNotCompletedShape();
                notCompleteShape.Draw(graphics);
            }
        }

        private void FixNotCompletedShape()
        {
            double smallerX = firstX < secondX ? firstX : secondX;
            double largerX = firstX < secondX ? secondX : firstX;
            double smallerY = firstY < secondY ? firstY : secondY;
            double largerY = firstY < secondY ? secondY : firstY;
            this.notCompleteShape.X = (int)smallerX;
            this.notCompleteShape.Y = (int)smallerY;
            this.notCompleteShape.Width = (int)(largerX - smallerX);
            this.notCompleteShape.Height = (int)(largerY - smallerY);
        }

        private void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }

        public void SelectNotCompleteShapeType(Shape.Type shapeType)
        {
            this.notCompleteShapeType = shapeType;
        }

        public void HandleMousePressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                isPressed = true;
                this.notCompleteShape = ShapeFactory.CreateShape(this.notCompleteShapeType);
                firstX = x;
                firstY = y;
            }
        }

        public void HandleMouseReleases(double x, double y)
        {
            if (isPressed)
            {
                isPressed = false;
                this.secondX = x;
                this.secondY = y;
                this.notCompleteShape.Content = GenerateRandomContent();
                FixNotCompletedShape();
                this.shapes.AddShape(this.notCompleteShape);
                NotifiyModelChange();
            }
        }

        public void HandleMouseMoved(double x, double y)
        {
            if (isPressed)
            {
                this.secondX = x;
                this.secondY = y;
                NotifiyModelChange();
            }
        }

        static private string GenerateRandomContent()
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
