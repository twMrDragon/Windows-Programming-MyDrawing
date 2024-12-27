using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class LineTests
    {

        Line line;
        [TestInitialize]
        public void SetUp()
        {
            line = new Line();
        }

        [TestMethod()]
        public void DrawTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            line.DrawShape(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawLine", adapter.Command[1]);
        }

        [TestMethod()]
        public void SetStartConnectPointTest()
        {
            Start start = new Start()
            {
                X = 0,
                Y = 0,
                Width = 200,
                Height = 100
            };
            line.SetStartConnectPoint(start, Shape.ConnectPoint.Top);
            Assert.AreEqual(start, line.StartShape);
            Assert.AreEqual(Shape.ConnectPoint.Top, line.StartShapeConnectPoint);
            Assert.AreEqual(100, line.EndX);
            Assert.AreEqual(0, line.EndY);
        }

        [TestMethod()]
        public void SetEndConnectPointTest()
        {
            Start start = new Start();
            line.SetEndConnectPoint(start, Shape.ConnectPoint.Top);
            Assert.AreEqual(start, line.EndShape);
            Assert.AreEqual(Shape.ConnectPoint.Top, line.EndShapeConnectPoint);
        }

        [TestMethod()]
        public void PropertyChangedTest()
        {
            Start start = new Start();
            bool flag = false;
            line.PropertyChanged += () => { flag = !flag; };
            Assert.IsFalse(flag);
            line.StartX = 1;
            Assert.IsTrue(flag);
            line.StartY = 2;
            Assert.IsFalse(flag);
            line.EndX = 3;
            Assert.IsTrue(flag);
            line.EndY = 4;
            Assert.IsFalse(flag);

            line.StartShape = start;
            Assert.IsTrue(flag);
            line.StartShapeConnectPoint = Shape.ConnectPoint.Right;
            Assert.IsFalse(flag);
            line.EndShape = start;
            Assert.IsTrue(flag);
            line.EndShapeConnectPoint = Shape.ConnectPoint.Right;
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void IsPointInTest()
        {
            line.StartX = 0;
            line.StartY = 0;
            line.EndX = 100;
            line.EndY = 100;
            Assert.IsFalse(line.IsPointIn(0, 0));
            Assert.IsFalse(line.IsPointIn(50, 50));
            Assert.IsFalse(line.IsPointIn(100, 100));
        }

        [TestMethod()]
        public void XYWidhtHeightTest()
        {
            line.StartX = 0;
            line.StartY = 0;
            line.EndX = 200;
            line.EndY = 100;
            Assert.AreEqual(0, line.X);
            Assert.AreEqual(0, line.Y);
            Assert.AreEqual(200, line.Width);
            Assert.AreEqual(100, line.Height);
            line.StartX = 200;
            line.StartY = 100;
            line.EndX = 0;
            line.EndY = 0;
            Assert.AreEqual(0, line.X);
            Assert.AreEqual(0, line.Y);
            Assert.AreEqual(200, line.Width);
            Assert.AreEqual(100, line.Height);
        }
    }
}