using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class ProcessTests
    {

        Process process;

        [TestInitialize]
        public void SetUp()
        {
            process = new Process();
            process.X = 0;
            process.Y = 10;
            process.Width = 200;
            process.Height = 100;
        }

        [TestMethod()]
        public void ProcessTest()
        {
            Assert.AreEqual("Process", process.ShapeName);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            process.DrawShape(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawRectangle", adapter.Command[1]);
        }

        [TestMethod()]
        public void IsPointInTest()
        {
            Assert.IsTrue(process.IsPointIn(0, 10));
            Assert.IsFalse(process.IsPointIn(200, 110));
            Assert.IsTrue(process.IsPointIn(199, 109));
            Assert.IsTrue(process.IsPointIn(100, 55));
        }
    }
}