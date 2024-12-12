using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        Shape shape;
        MockGraphicAdapter adapter;

        [TestInitialize]
        public void SetUp()
        {
            shape = new Start();
            shape.Content = "Start Content";
            adapter = new MockGraphicAdapter();
        }

        [TestMethod()]
        public void DrawContentTest()
        {
            shape.DrawContent(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawString", adapter.Command[1]);
        }

        [TestMethod()]
        public void DrawBorderTest()
        {
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

        [TestMethod()]
        public void DrawContentBorderTest()
        {
            shape.Content = null;
            shape.DrawContentBorder(adapter);
            Assert.AreEqual(0, adapter.Command.Count);

            shape.Content = "Content";
            shape.DrawContentBorder(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("DrawRectangle", adapter.Command[1]);
            Assert.AreEqual("SetColor", adapter.Command[2]);
            Assert.AreEqual("FillEllipse", adapter.Command[3]);
        }

        [TestMethod()]
        public void IsPointInContentControlPointTest()
        {
            shape.Content = null;
            shape.X = 0;
            shape.Y = 0;
            shape.Width = 200;
            shape.Height = 100;
            Assert.IsFalse(shape.IsPointInContentControlPoint(0, 0));
            Assert.IsFalse(shape.IsPointInContentControlPoint(100, 50));
            Assert.IsFalse(shape.IsPointInContentControlPoint(200, 100));

            shape.Content = "Hello";
            Assert.IsFalse(shape.IsPointInContentControlPoint(0, 0));
            Assert.IsFalse(shape.IsPointInContentControlPoint(100, 42));
        }
    }
}