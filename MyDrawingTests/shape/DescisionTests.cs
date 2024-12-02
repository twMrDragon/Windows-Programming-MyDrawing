using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class DescisionTests
    {
        Descision descision;

        [TestInitialize]
        public void SetUp()
        {
            descision = new Descision();
            descision.X = 0;
            descision.Y = 10;
            descision.Width = 200;
            descision.Height = 100;
        }

        [TestMethod()]
        public void DescisionTest()
        {
            Assert.AreEqual("Descision", descision.ShapeName);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            descision.DrawShape(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawPolygon", adapter.Command[1]);
        }

        [TestMethod()]
        public void IsPointInTest()
        {
            Assert.IsFalse(descision.IsPointIn(0, 10));
            Assert.IsFalse(descision.IsPointIn(200, 110));
            Assert.IsTrue(descision.IsPointIn(100, 55));
        }
    }
}