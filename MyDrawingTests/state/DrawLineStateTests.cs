using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.presentationModel;
using MyDrawing.shape;

namespace MyDrawing.state.Tests
{
    [TestClass()]
    public class DrawLineStateTests
    {

        DrawLineState drawLineState;
        PresentationModel presentationModel;
        Model model;

        [TestInitialize]
        public void SetUp()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
            drawLineState = presentationModel.drawLineState;
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 0, 200, 100);
            presentationModel.AddShape(Shape.Type.Process, "Content", 300, 300, 200, 100);
        }

        [TestMethod]
        public void DrawLineStateMouseDownAtIllegal()
        {
            Assert.AreEqual(null, model.NotCompleteLine);
            drawLineState.MouseDown(100, 0);
            Assert.AreEqual(null, model.NotCompleteLine);
        }

        [TestMethod]
        public void DrawLineStateMouseOnlyMove()
        {
            Assert.AreEqual(null, model.HoverShape);
            drawLineState.MouseMove(100, 50);
            Assert.AreNotEqual(null, model.HoverShape);
            drawLineState.MouseMove(250, 150);
            Assert.AreEqual(null, model.HoverShape);
            drawLineState.MouseMove(400, 350);
            Assert.AreNotEqual(null, model.HoverShape);
        }

        [TestMethod]
        public void DrawLineStateMouseOnlyUp()
        {
            Assert.AreEqual(2, model.GetShapes().Count);
            drawLineState.MouseUp(100, 50);
            Assert.AreEqual(2, model.GetShapes().Count);
        }

        [TestMethod]
        public void DrawLineStateMouseDownNotAtConnectPoint()
        {
            drawLineState.MouseDown(200, 100);
            Assert.IsNull(model.NotCompleteLine);
            drawLineState.MouseMove(100, 50);
            Assert.IsNull(model.NotCompleteLine);
            drawLineState.MouseMove(250, 150);
            Assert.IsNull(model.NotCompleteLine);
            drawLineState.MouseMove(400, 350);
            Assert.IsNull(model.NotCompleteLine);
            drawLineState.MouseUp(400, 300);
            Assert.IsNull(model.NotCompleteLine);
            Assert.AreEqual(2, model.GetShapes().Count);
        }

        [TestMethod]
        public void DrawLineStateFinishLine()
        {
            Assert.AreEqual(2, model.GetShapes().Count);
            drawLineState.MouseDown(200, 50);
            drawLineState.MouseMove(250, 150);
            drawLineState.MouseUp(400, 300);
            Assert.AreEqual(3, model.GetShapes().Count);
        }

        [TestMethod]
        public void DrawLineStateDidntFinishLine()
        {
            Assert.AreEqual(2, model.GetShapes().Count);
            drawLineState.MouseDown(200, 50);
            drawLineState.MouseMove(250, 150);
            drawLineState.MouseMove(250, 150);
            Assert.AreEqual(2, model.GetShapes().Count);
        }

        [TestMethod]
        public void DrawLineStateFinishAtSamePoint()
        {
            Assert.AreEqual(2, model.GetShapes().Count);
            drawLineState.MouseDown(200, 50);
            drawLineState.MouseMove(250, 150);
            drawLineState.MouseUp(200, 50);
            Assert.AreEqual(2, model.GetShapes().Count);
        }

        [TestMethod]
        public void DrawLineStatePassLine()
        {
            Line line = new Line();
            line.StartShape = model.GetShapes()[0];
            line.StartShape = model.GetShapes()[1];
            line.StartShapeConnectPoint = Shape.ConnectPoint.Bottom;
            line.EndShapeConnectPoint = Shape.ConnectPoint.Top;
            model.AddShape(line);
            Assert.IsNull(model.HoverShape);
            drawLineState.MouseDown(100, 100);
            drawLineState.MouseMove(100, 100);
            Assert.IsNotNull(model.HoverShape);
            // 線的左連接點
            drawLineState.MouseMove(250, 200);
            Assert.IsNull(model.HoverShape);
            drawLineState.MouseMove(400, 300);
            Assert.IsNotNull(model.HoverShape);
            drawLineState.MouseUp(400, 300);
            Assert.AreEqual(4, model.GetShapes().Count);
        }
    }
}