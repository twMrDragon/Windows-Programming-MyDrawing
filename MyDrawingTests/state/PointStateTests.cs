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
            presentationModel.CreateShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            pointState = presentationModel.pointState;
        }

        [TestMethod()]
        public void PointStateSelectedShape()
        {
            Assert.AreEqual(null, model.selectedShape);
            pointState.MouseDown(50, 50);
            Assert.AreNotEqual(null, model.selectedShape);
        }

        [TestMethod()]
        public void PointStateNotSelectedShape()
        {
            Assert.AreEqual(null, model.selectedShape);
            pointState.MouseDown(200, 200);
            Assert.AreEqual(null, model.selectedShape);
            pointState.MouseMove(300, 300);
            Assert.AreEqual(null, model.selectedShape);
            pointState.MouseUp(400, 400);
            Assert.AreEqual(null, model.selectedShape);
        }

        [TestMethod]
        public void PointStateSelectedAndMoveShape()
        {
            pointState.MouseDown(50, 50);
            pointState.MouseMove(100, 200);
            Assert.AreEqual(50, model.selectedShape.X);
            Assert.AreEqual(150, model.selectedShape.Y);

            Assert.AreEqual(50, model.selectedShape.ContentRelativelyX);
            Assert.AreEqual(50, model.selectedShape.ContentRelativelyY);

            pointState.MouseUp(150, 300);
            Assert.AreEqual(100, model.selectedShape.X);
            Assert.AreEqual(250, model.selectedShape.Y);

            Assert.AreEqual(50, model.selectedShape.ContentRelativelyX);
            Assert.AreEqual(50, model.selectedShape.ContentRelativelyY);
        }

        [TestMethod]
        public void PointStateSelectedAndMoveContent()
        {
            pointState.MouseDown(50, 50);
            pointState.MouseDown(50, 42);
            pointState.MouseMove(100, 200);
            Assert.AreEqual(100, model.selectedShape.ContentRelativelyX);
            Assert.AreEqual(208, model.selectedShape.ContentRelativelyY);
            pointState.MouseUp(150, 300);
            Assert.AreEqual(150, model.selectedShape.ContentRelativelyX);
            Assert.AreEqual(308, model.selectedShape.ContentRelativelyY);

        }

        [TestMethod]
        public void PointStateOnlyMouseMove()
        {
            pointState.MouseMove(100, 200);
            Assert.AreEqual(null, model.selectedShape);
        }

        [TestMethod]
        public void PointStateOnlyMouseUp()
        {
            pointState.MouseUp(100, 200);
            Assert.AreEqual(null, model.selectedShape);
        }
    }
}