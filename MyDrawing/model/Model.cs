using MyDrawing.graphics;
using MyDrawing.shape;
using System;
using System.Collections.Generic;

namespace MyDrawing
{
    /// <summary>
    /// 成員大部分只放會顯示在介面上的物件
    /// </summary>
    public class Model
    {
        // Observer pattern
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // 圖形s
        readonly private List<Shape> shapes = new List<Shape>();
        public Shape.Type notCompleteShapeType;
        private Shape notCompleteShape = null;
        public Shape NotCompleteShape
        {
            get => notCompleteShape;
            set
            {
                notCompleteShape = value;
                if (notCompleteShape != null)
                    notCompleteShape.PropertyChanged += () => { NotifiyModelChange(); };
                NotifiyModelChange();
            }
        }
        private Shape selectedShape = null;
        public Shape SelectedShape
        {
            get => selectedShape;
            set
            {
                selectedShape = value;
                NotifiyModelChange();
            }
        }
        private Shape hoverShape = null;
        public Shape HoverShape
        {
            get => hoverShape;
            set
            {
                hoverShape = value;
                NotifiyModelChange();
            }
        }

        // 連線s
        readonly private List<Line> lines = new List<Line>();
        private Line notCompleteLine = null;
        public Line NotCompleteLine
        {
            get => notCompleteLine;
            set
            {
                notCompleteLine = value;
                if (notCompleteLine != null)
                    notCompleteLine.PropertyChanged += () => { NotifiyModelChange(); };
                NotifiyModelChange();
            }
        }


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
            if (shape == null)
                return;
            this.shapes.Add(shape);
            shape.PropertyChanged += () => { NotifiyModelChange(); };
            NotifiyModelChange();
        }
        public void RemoveShapeAt(int index)
        {
            if (shapes[index] == selectedShape)
                selectedShape = null;
            shapes.RemoveAt(index);
            NotifiyModelChange();
        }
        public void InsertShape(int index, Shape shape)
        {
            this.shapes.Insert(index, shape);
            shape.PropertyChanged += () => { NotifiyModelChange(); };
            NotifiyModelChange();
        }

        public IList<Line> GetLines()
        {
            return lines.AsReadOnly();
        }

        public void AddLine(Line line)
        {
            if (line == null)
                return;
            this.lines.Add(line);
            NotifiyModelChange();
        }

        public void RemoveLineFromEnd()
        {
            this.lines.RemoveAt(this.lines.Count - 1);
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

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }
    }
}
