using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.presentationModel;
using MyDrawing.shape;

namespace MyDrawing.state.Tests
{
    [TestClass()]
    public class PointStateTests
    {
        Model model;
        PresentationModel presentationModel;
        IState pointState;

        [TestInitialize]
        public void SetUp()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            presentationModel.AddShape(Shape.Type.Start, "Start content", -10, -10, 100, 100);
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            pointState = presentationModel.pointState;
        }

        [TestMethod()]
        public void PointStateSelectedShape()
        {
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseDown(50, 50);
            Assert.AreNotEqual(null, model.SelectedShape);
        }

        [TestMethod()]
        public void PointStateNotSelectedShape()
        {
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseDown(200, 200);
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseMove(300, 300);
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseUp(400, 400);
            Assert.AreEqual(null, model.SelectedShape);
        }

        [TestMethod()]
        public void PointStateNotSelectedShape2()
        {
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseDown(-5, -5);
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseMove(0, 0);
            Assert.AreEqual(null, model.SelectedShape);
            pointState.MouseUp(10, 10);
            Assert.AreEqual(null, model.SelectedShape);
        }

        [TestMethod]
        public void PointStateSelectedAndMoveShape()
        {
            pointState.MouseDown(50, 50);
            pointState.MouseMove(100, 200);
            Assert.AreEqual(50, model.SelectedShape.X);
            Assert.AreEqual(150, model.SelectedShape.Y);

            Assert.AreEqual(50, model.SelectedShape.ContentRelativelyX);
            Assert.AreEqual(50, model.SelectedShape.ContentRelativelyY);

            pointState.MouseUp(150, 300);
            Assert.AreEqual(100, model.SelectedShape.X);
            Assert.AreEqual(250, model.SelectedShape.Y);

            Assert.AreEqual(50, model.SelectedShape.ContentRelativelyX);
            Assert.AreEqual(50, model.SelectedShape.ContentRelativelyY);
        }

        [TestMethod]
        public void PointStateSelectedAndMoveContent()
        {
            pointState.MouseDown(50, 50);
            pointState.MouseDown(50, 42);
            pointState.MouseMove(100, 200);
            Assert.AreEqual(100, model.SelectedShape.ContentRelativelyX);
            Assert.AreEqual(208, model.SelectedShape.ContentRelativelyY);
            pointState.MouseUp(150, 300);
            Assert.AreEqual(150, model.SelectedShape.ContentRelativelyX);
            Assert.AreEqual(308, model.SelectedShape.ContentRelativelyY);

        }

        [TestMethod]
        public void PointStateOnlyMouseMove()
        {
            pointState.MouseMove(100, 200);
            Assert.AreEqual(null, model.SelectedShape);
        }

        [TestMethod]
        public void PointStateOnlyMouseUp()
        {
            pointState.MouseUp(100, 200);
            Assert.AreEqual(null, model.SelectedShape);
        }
    }
}