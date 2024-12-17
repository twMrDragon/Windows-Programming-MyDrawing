using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.presentationModel;
using MyDrawing.shape;

namespace MyDrawing.state.Tests
{
    [TestClass()]
    public class DrawStateTests
    {
        IState drawState;
        PresentationModel presentationModel;
        Model model;

        [TestInitialize]
        public void SetUp()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            drawState = presentationModel.drawState;
        }

        [TestMethod()]
        public void DrawStateDrawLeftTopToRightBottom()
        {
            presentationModel.drawState.notCompleteShapeType = Shape.Type.Start;

            // 左上畫到右下
            drawState.MouseDown(1, 2);
            Assert.AreNotEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseMove(50, 51);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseUp(100, 101);
            Assert.AreNotEqual(0, model.GetShapes().Count);
            Assert.AreEqual(null, model.NotCompleteShape);
        }

        [TestMethod()]
        public void DrawStateDrawLeftBottomToRightTop()
        {
            presentationModel.drawState.notCompleteShapeType = Shape.Type.Start;

            // 左下畫到右上
            drawState.MouseDown(1, 101);
            Assert.AreNotEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseMove(50, 51);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseUp(100, 2);
            Assert.AreNotEqual(0, model.GetShapes().Count);
            Assert.AreEqual(null, model.NotCompleteShape);
        }

        [TestMethod()]
        public void DrawStateDrawRightBottomToLeftTop()
        {
            presentationModel.drawState.notCompleteShapeType = Shape.Type.Start;

            // 右下畫到左上
            drawState.MouseDown(100, 101);
            Assert.AreNotEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseMove(50, 51);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseUp(1, 2);
            Assert.AreNotEqual(0, model.GetShapes().Count);
            Assert.AreEqual(null, model.NotCompleteShape);
        }

        [TestMethod()]
        public void DrawStateDrawRightTopToLeftBottom()
        {
            presentationModel.drawState.notCompleteShapeType = Shape.Type.Start;

            // 右上畫到左下
            drawState.MouseDown(100, 2);
            Assert.AreNotEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseMove(50, 51);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseUp(1, 101);
            Assert.AreNotEqual(0, model.GetShapes().Count);
            Assert.AreEqual(null, model.NotCompleteShape);
        }

        [TestMethod()]
        public void DrawStateOnlyMouseDownLeastOrEqualThan0()
        {
            drawState.MouseDown(0, -1);
            Assert.AreEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            drawState.MouseDown(-2, -3);
            Assert.AreEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);
        }

        [TestMethod()]
        public void DrawStateOnlyMouseMove()
        {
            drawState.MouseMove(1, 2);
            Assert.AreEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);
        }

        [TestMethod()]
        public void DrawStateOnlyMouseUp()
        {
            drawState.MouseUp(1, 2);
            Assert.AreEqual(null, model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);
        }
    }
}