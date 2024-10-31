using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class ShapeFactory
    {
        public enum ShapeType
        {
            Start,
            Terminator,
            Process,
            Descision
        }

        // 建立哪個圖形的條件判斷寫在這
        public Shape CreateShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Start:
                    return new Start();
                case ShapeType.Terminator:
                    return new Terminator();
                case ShapeType.Process:
                    return new Process();
                case ShapeType.Descision:
                    return new Descision();
                default:
                    return new Start();
            }
        }
    }
}
