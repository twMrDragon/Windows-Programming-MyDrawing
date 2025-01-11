using MyDrawing.graphics;
using MyDrawing.shape;
using Newtonsoft.Json.Linq;
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

        // 連線
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
            notCompleteLine?.DrawShape(graphics);

            hoverShape?.DrawConnectPoint(graphics);
        }

        public string GenerateShapesDataOfJson()
        {
            JArray jArray = new JArray();

            foreach (Shape shape in this.shapes)
            {
                JObject jObject = new JObject()
                {
                    { "shapeType",Enum.GetName(typeof(Shape.Type), shape.ShapeType)},
                };
                if (shape.ShapeType != Shape.Type.Line)
                {
                    jObject["content"] = shape.Content;
                    jObject["x"] = shape.X;
                    jObject["y"] = shape.Y;
                    jObject["width"] = shape.Width;
                    jObject["height"] = shape.Height;
                    jObject["contentRelativelyX"] = shape.ContentRelativelyX;
                    jObject["contentRelativelyY"] = shape.ContentRelativelyY;
                }
                else
                {
                    Line line = shape as Line;
                    jObject["startShapeIndex"] = shapes.IndexOf(line.StartShape);
                    jObject["endShapeIndex"] = shapes.IndexOf(line.EndShape);
                    jObject["startShapeConnectPoint"] = Enum.GetName(typeof(Shape.ConnectPoint), line.StartShapeConnectPoint);
                    jObject["endShapeConnectPoint"] = Enum.GetName(typeof(Shape.ConnectPoint), line.EndShapeConnectPoint);
                }
                jArray.Add(jObject);
            }
            return jArray.ToString();
        }

        public void ParseShapesDataFromJson(string json)
        {
            this.shapes.Clear();

            JArray jArray = JArray.Parse(json);
            List<Line> lines = new List<Line>();
            List<JObject> lineJObjects = new List<JObject>();
            foreach (JObject jObject in jArray)
            {
                if (jObject["shapeType"].ToString() == "Line")
                {
                    Line line = new Line()
                    {
                        StartShapeConnectPoint = (Shape.ConnectPoint)Enum.Parse(typeof(Shape.ConnectPoint), jObject["startShapeConnectPoint"].ToString()),
                        EndShapeConnectPoint = (Shape.ConnectPoint)Enum.Parse(typeof(Shape.ConnectPoint), jObject["endShapeConnectPoint"].ToString())
                    };
                    lineJObjects.Add(jObject);
                    lines.Add(line);
                    this.shapes.Add(line);
                }
                else
                {
                    Shape shape = ShapeFactory.CreateShape((Shape.Type)Enum.Parse(typeof(Shape.Type), jObject["shapeType"].ToString()));
                    shape.Content = jObject["content"].ToString();
                    shape.X = int.Parse(jObject["x"].ToString());
                    shape.Y = int.Parse(jObject["y"].ToString());
                    shape.Width = int.Parse(jObject["width"].ToString());
                    shape.Height = int.Parse(jObject["height"].ToString());
                    shape.ContentRelativelyX = int.Parse(jObject["contentRelativelyX"].ToString());
                    shape.ContentRelativelyY = int.Parse(jObject["contentRelativelyY"].ToString());
                    this.shapes.Add(shape);
                }
            }
            var shapes = this.GetShapes();
            for (int i = 0; i < lines.Count; i++)
            {
                JObject jObject = lineJObjects[i];
                lines[i].StartShape = shapes[int.Parse(jObject["startShapeIndex"].ToString())];
                lines[i].EndShape = shapes[int.Parse(jObject["endShapeIndex"].ToString())];
            }
            this.notCompleteLine = null;
            this.selectedShape = null;
            this.hoverShape = null;
            NotifiyModelChange();
        }

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }
    }
}
