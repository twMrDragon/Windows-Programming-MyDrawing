using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        Shape shape;

        [TestInitialize]
        public void SetUp()
        {
            shape = new Start();
            shape.Content = "Start Content";
        }

        [TestMethod()]
        public void DrawContentTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            shape.DrawContent(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawString", adapter.Command[1]);
        }

        [TestMethod()]
        public void DrawBorderTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            shape.DrawBorder(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawRectangle", adapter.Command[1]);
            Assert.AreEqual("SetColor", adapter.Command[2]);
            Assert.AreEqual("DrawEllipse", adapter.Command[3]);
            Assert.AreEqual("DrawEllipse", adapter.Command[4]);
            Assert.AreEqual("DrawEllipse", adapter.Command[5]);
            Assert.AreEqual("DrawEllipse", adapter.Command[6]);
            Assert.AreEqual("DrawEllipse", adapter.Command[6]);
            Assert.AreEqual("DrawEllipse", adapter.Command[7]);
            Assert.AreEqual("DrawEllipse", adapter.Command[8]);
            Assert.AreEqual("DrawEllipse", adapter.Command[9]);
        }
    }
}