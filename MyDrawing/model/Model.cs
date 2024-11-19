using MyDrawing.graphics;
using MyDrawing.shape;
using MyDrawing.state;
using System;
using System.Collections.Generic;

namespace MyDrawing
{
    public class Model
    {
        // Observer pattern
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // 維護圖形清單的增刪查
        readonly private Shapes shapes = new Shapes();

        // state
        public IState currnetState;
        readonly public IState pointState;
        readonly public IState drawState;

        public Shape.Type notCompleteShapeType;
        public Shape notCompleteShape = null;

        public Shape selectedShape = null;

        public Model()
        {
            this.pointState = new PointState(this);
            this.drawState = new DrawState(this);
            SetToPointState();
        }

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
            Shape shape = ShapeFactory.CreateShape(shapeType);
            shape.Content = content;
            shape.X = x;
            shape.Y = y;
            shape.Width = width;
            shape.Height = height;
            shapes.AddShape(shape);
            NotifiyModelChange();
        }

        public void RemoveShapeAt(int index)
        {
            shapes.RemoveShapeAt(index);
            selectedShape = null;
            NotifiyModelChange();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape item in shapes.GetShapes())
                item.Draw(graphics);
            notCompleteShape?.Draw(graphics);
            selectedShape?.DrawBorder(graphics);
        }
        public void AddShapeFromNotComplete()
        {
            this.shapes.AddShape(notCompleteShape);
            this.selectedShape = notCompleteShape;
            this.notCompleteShape = null;
        }

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }

        public void SetToDrawState(Shape.Type shapeType)
        {
            this.currnetState = this.drawState;
            this.notCompleteShapeType = shapeType;
            this.selectedShape = null;
            NotifiyModelChange();
        }

        public void SetToPointState()
        {
            this.currnetState = this.pointState;
        }

        public void HandleMousePressed(double x, double y)
        {
            currnetState.MouseDown(x, y);
        }

        public void HandleMouseReleases(double x, double y)
        {
            currnetState.MouseUp(x, y);
        }

        public void HandleMouseMoved(double x, double y)
        {
            currnetState.MouseMove(x, y);
        }
    }
}
