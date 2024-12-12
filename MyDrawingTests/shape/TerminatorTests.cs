using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class TerminatorTests
    {
        Terminator terminator;

        [TestInitialize]
        public void SetUp()
        {
            terminator = new Terminator();
            terminator.X = 0;
            terminator.Y = 10;
            terminator.Width = 200;
            terminator.Height = 100;
        }

        [TestMethod()]
        public void TerminatorTest()
        {
            Assert.AreEqual("Terminator", terminator.ShapeName);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            terminator.DrawShape(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawArc", adapter.Command[1]);
            Assert.AreEqual("DrawArc", adapter.Command[2]);
            Assert.AreEqual("DrawLine", adapter.Command[3]);
            Assert.AreEqual("DrawLine", adapter.Command[4]);
        }

        [TestMethod()]
        public void IsPointInTest()
        {
            Assert.IsFalse(terminator.IsPointIn(0, 10));
            Assert.IsFalse(terminator.IsPointIn(200, 110));
            Assert.IsTrue(terminator.IsPointIn(100, 55));

            terminator.Width = 0;
            Assert.IsFalse(terminator.IsPointIn(0, 10));
            terminator.Height = 0;
            Assert.IsFalse(terminator.IsPointIn(0, 10));
        }
    }
}