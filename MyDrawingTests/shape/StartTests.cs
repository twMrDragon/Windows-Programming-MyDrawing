using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class StartTests
    {
        Start start;

        [TestInitialize]
        public void SetUp()
        {
            start = new Start();
            start.X = 0;
            start.Y = 10;
            start.Width = 200;
            start.Height = 100;
        }

        [TestMethod()]
        public void StartTest()
        {
            Assert.AreEqual("Start", start.ShapeName);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            start.DrawShape(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawEllipse", adapter.Command[1]);
        }

        [TestMethod()]
        public void IsPointInTest()
        {
            Assert.IsFalse(start.IsPointIn(0, 10));
            Assert.IsFalse(start.IsPointIn(200, 110));
            Assert.IsTrue(start.IsPointIn(100, 55));
        }
    }
}