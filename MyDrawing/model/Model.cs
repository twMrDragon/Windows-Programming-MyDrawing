using MyDrawing.graphics;
using MyDrawing.shape;
using System;
using System.Collections.Generic;

namespace MyDrawing
{
    public class Model
    {
        // Observer pattern
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // 圖形s
        readonly private List<Shape> shapes = new List<Shape>();

        public Shape.Type notCompleteShapeType;
        public Shape notCompleteShape = null;
        public Shape selectedShape = null;
        public Shape hoverShape = null;

        // 連線s
        readonly private List<Line> lines = new List<Line>();
        public Line notCompleteLine = null;


        static public string[] GetShapeTypesName()
        {
            return Enum.GetNames(typeof(Shape.Type));
        }

        public IList<Shape> GetShapes()
        {
            return shapes.AsReadOnly();
        }

        public void AddShape(Shape shape)
        {
            this.shapes.Add(shape);
            NotifiyModelChange();
        }
        public void RemoveShapeAt(int index)
        {
            shapes.RemoveAt(index);
            selectedShape = null;
            NotifiyModelChange();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape item in shapes)
            {
                item.DrawShape(graphics);
                item.DrawContent(graphics);
            }
            notCompleteShape?.DrawShape(graphics);
            selectedShape?.DrawContentBorder(graphics);
            selectedShape?.DrawBorder(graphics);

            foreach (Line line in lines)
                line.Draw(graphics);
            notCompleteLine?.Draw(graphics);

            hoverShape?.DrawConnectPoint(graphics);
        }

        public void AddLineFromNotComplete()
        {
            if (this.notCompleteLine == null)
                return;
            this.lines.Add(notCompleteLine);
            this.notCompleteLine = null;
            NotifiyModelChange();
        }

        public void AddShapeFromNotComplete()
        {
            if (this.notCompleteShape == null)
                return;
            this.shapes.Add(notCompleteShape);
            NotifiyModelChange();
        }

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }
    }
}
