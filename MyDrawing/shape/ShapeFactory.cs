﻿using MyDrawing.shape;

namespace MyDrawing
{
    public class ShapeFactory
    {
        protected ShapeFactory()
        {

        }

        // 建立哪個圖形的條件判斷寫在這
        static public Shape CreateShape(Shape.Type shapeType)
        {
            switch (shapeType)
            {
                case Shape.Type.Start:
                    return new Start();
                case Shape.Type.Terminator:
                    return new Terminator();
                case Shape.Type.Process:
                    return new Process();
                case Shape.Type.Descision:
                    return new Descision();
                default:
                    return new Start();
            }
        }
    }
}
