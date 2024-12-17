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
            line.Draw(adapter);
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
    }
}