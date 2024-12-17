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
            shape = new Start()
            {
                Content = "Start Content",
                X = 0,
                Y = 0,
                Width = 200,
                Height = 100,
                ContentRelativelyX = 100,
                ContentRelativelyY = 50
            };
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
            Assert.IsFalse(shape.IsPointInContentControlPoint(0, 0));
            Assert.IsFalse(shape.IsPointInContentControlPoint(100, 50));
            Assert.IsFalse(shape.IsPointInContentControlPoint(200, 100));

            shape.Content = "Hello";
            Assert.IsFalse(shape.IsPointInContentControlPoint(0, 0));
            Assert.IsFalse(shape.IsPointInContentControlPoint(100, 50));
        }

        [TestMethod()]
        public void DrawConnectPointTest()
        {
            shape.DrawConnectPoint(adapter);
            Assert.AreEqual("SetColor", adapter.Command[0]);
            Assert.AreEqual("FillEllipse", adapter.Command[1]);
            Assert.AreEqual("FillEllipse", adapter.Command[2]);
            Assert.AreEqual("FillEllipse", adapter.Command[3]);
            Assert.AreEqual("FillEllipse", adapter.Command[4]);
        }

        [TestMethod()]
        public void PropertyChangedTest()
        {
            bool flag = false;
            shape.PropertyChanged += () => { flag = !flag; };
            Assert.IsFalse(flag);
            shape.Content = null;
            Assert.IsTrue(flag);
            shape.X = 1;
            Assert.IsFalse(flag);
            shape.Y = 1;
            Assert.IsTrue(flag);
            shape.Width = 201;
            Assert.IsFalse(flag);
            shape.Height = 101;
            Assert.IsTrue(flag);
            shape.ContentRelativelyX = 101;
            Assert.IsFalse(flag);
            shape.ContentRelativelyY = 51;
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void PropertyNotChangedTest()
        {
            bool flag = false;
            shape.PropertyChanged += () => { flag = !flag; };
            Assert.IsFalse(flag);
            shape.Content = "Start Content";
            Assert.IsFalse(flag);
            shape.X = 0;
            Assert.IsFalse(flag);
            shape.Y = 0;
            Assert.IsFalse(flag);
            shape.Width = 200;
            Assert.IsFalse(flag);
            shape.Height = 100;
            Assert.IsFalse(flag);
            shape.ContentRelativelyX = 100;
            Assert.IsFalse(flag);
            shape.ContentRelativelyY = 50;
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void GetPointXTest()
        {
            Assert.AreEqual(100, shape.GetPointX(Shape.ConnectPoint.Top));
            Assert.AreEqual(200, shape.GetPointX(Shape.ConnectPoint.Right));
            Assert.AreEqual(100, shape.GetPointX(Shape.ConnectPoint.Bottom));
            Assert.AreEqual(0, shape.GetPointX(Shape.ConnectPoint.Left));

            Assert.AreEqual(100, shape.GetPointX((Shape.ConnectPoint)(-1)));
        }

        [TestMethod()]
        public void GetPointYTest()
        {
            Assert.AreEqual(0, shape.GetPointY(Shape.ConnectPoint.Top));
            Assert.AreEqual(50, shape.GetPointY(Shape.ConnectPoint.Right));
            Assert.AreEqual(100, shape.GetPointY(Shape.ConnectPoint.Bottom));
            Assert.AreEqual(50, shape.GetPointY(Shape.ConnectPoint.Left));

            Assert.AreEqual(0, shape.GetPointY((Shape.ConnectPoint)(-1)));
        }

        [TestMethod()]
        public void IsPointInConnectPointTest()
        {
            Assert.IsTrue(shape.IsPointInConnectPoint(100, 0, Shape.ConnectPoint.Top));
            Assert.IsTrue(shape.IsPointInConnectPoint(200, 50, Shape.ConnectPoint.Right));
            Assert.IsTrue(shape.IsPointInConnectPoint(100, 100, Shape.ConnectPoint.Bottom));
            Assert.IsTrue(shape.IsPointInConnectPoint(0, 50, Shape.ConnectPoint.Left));

            Assert.IsFalse(shape.IsPointInConnectPoint(0, 50, (Shape.ConnectPoint)(-1)));
        }
    }
}