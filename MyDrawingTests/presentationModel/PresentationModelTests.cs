using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.controls;
using MyDrawing.shape;
using System.Linq;

namespace MyDrawing.presentationModel.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        PresentationModel presentationModel;
        Model model;

        [TestInitialize]
        public void SetUp()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
        }

        [TestMethod()]
        public void CreateShapeTest()
        {
            Assert.AreEqual(0, model.GetShapes().Count);
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            Assert.AreEqual(1, model.GetShapes().Count);
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            Assert.AreEqual(2, model.GetShapes().Count);
        }

        [TestMethod()]
        public void SetToDrawStateTest()
        {
            presentationModel.SetToDrawState(Shape.Type.Start);
            Assert.AreEqual(Shape.Type.Start, presentationModel.drawState.notCompleteShapeType);
            Assert.AreEqual(presentationModel.drawState, presentationModel.CurrentState);

            presentationModel.SetToDrawState(Shape.Type.Process);
            Assert.AreEqual(Shape.Type.Process, presentationModel.drawState.notCompleteShapeType);
            Assert.AreEqual(presentationModel.drawState, presentationModel.CurrentState);

            presentationModel.SetToDrawState(Shape.Type.Terminator);
            Assert.AreEqual(Shape.Type.Terminator, presentationModel.drawState.notCompleteShapeType);
            Assert.AreEqual(presentationModel.drawState, presentationModel.CurrentState);

            presentationModel.SetToDrawState(Shape.Type.Descision);
            Assert.AreEqual(Shape.Type.Descision, presentationModel.drawState.notCompleteShapeType);
            Assert.AreEqual(presentationModel.drawState, presentationModel.CurrentState);
        }

        [TestMethod()]
        public void SetToPointStateTest()
        {
            presentationModel.SetToPointState();
            Assert.AreEqual(presentationModel.pointState, presentationModel.CurrentState);
        }

        [TestMethod()]
        public void SetToDrawLineStateTest()
        {
            presentationModel.SetToDrawLineState();
            Assert.AreEqual(presentationModel.drawLineState, presentationModel.CurrentState);
        }

        [TestMethod()]
        public void DrawStateTest()
        {
            presentationModel.SetToDrawState(Shape.Type.Start);
            presentationModel.HandleMousePressed(1, 1);
            presentationModel.HandleMouseMoved(50, 50);
            presentationModel.HandleMouseReleases(100, 200);
            Assert.AreNotEqual(0, model.GetShapes().Count);
            Shape shape = model.GetShapes().Last();
            Assert.AreEqual(1, shape.X);
            Assert.AreEqual(1, shape.Y);
            Assert.AreEqual(99, shape.Width);
            Assert.AreEqual(199, shape.Height);
        }

        [TestMethod()]
        public void PointStateTest()
        {
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            presentationModel.SetToPointState();
            presentationModel.HandleMousePressed(50, 50);
            presentationModel.HandleMouseMoved(100, 100);
            presentationModel.HandleMouseReleases(200, 200);
            Shape shape = model.GetShapes().Last();
            Assert.AreEqual(150, shape.X);
            Assert.AreEqual(160, shape.Y);
            Assert.AreEqual(200, shape.Width);
            Assert.AreEqual(100, shape.Height);
        }

        [TestMethod()]
        public void LabelShapeContentChangeTest()
        {
            presentationModel.LabelShapeContentChange("");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeContentColor);

            presentationModel.LabelShapeContentChange("Content");
            Assert.AreEqual("#000000", presentationModel.LabelShapeContentColor);
        }

        [TestMethod()]
        public void LabelShapeXChangeTest()
        {
            presentationModel.LabelShapeXChange("");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeXColor);

            presentationModel.LabelShapeXChange("X");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeXColor);

            presentationModel.LabelShapeXChange("3.14");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeXColor);

            presentationModel.LabelShapeXChange("-1");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeXColor);

            presentationModel.LabelShapeXChange("0");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeXColor);

            presentationModel.LabelShapeXChange("1");
            Assert.AreEqual("#000000", presentationModel.LabelShapeXColor);
        }

        [TestMethod()]
        public void LabelShapeYChangeTest()
        {
            presentationModel.LabelShapeYChange("");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeYColor);

            presentationModel.LabelShapeYChange("Y");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeYColor);

            presentationModel.LabelShapeYChange("3.14");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeYColor);

            presentationModel.LabelShapeYChange("-1");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeYColor);

            presentationModel.LabelShapeYChange("0");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeYColor);

            presentationModel.LabelShapeYChange("1");
            Assert.AreEqual("#000000", presentationModel.LabelShapeYColor);
        }

        [TestMethod()]
        public void LabelShapeWidthChangeTest()
        {
            presentationModel.LabelShapeWidthChange("");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeWidthColor);

            presentationModel.LabelShapeWidthChange("Width");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeWidthColor);

            presentationModel.LabelShapeWidthChange("3.14");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeWidthColor);

            presentationModel.LabelShapeWidthChange("-1");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeWidthColor);

            presentationModel.LabelShapeWidthChange("0");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeWidthColor);

            presentationModel.LabelShapeWidthChange("1");
            Assert.AreEqual("#000000", presentationModel.LabelShapeWidthColor);
        }

        [TestMethod()]
        public void LabelShapeHeightChangeTest()
        {
            presentationModel.LabelShapeHeightChange("");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeHeightColor);

            presentationModel.LabelShapeHeightChange("Width");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeHeightColor);

            presentationModel.LabelShapeHeightChange("3.14");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeHeightColor);

            presentationModel.LabelShapeHeightChange("-1");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeHeightColor);

            presentationModel.LabelShapeHeightChange("0");
            Assert.AreEqual("#FF0000", presentationModel.LabelShapeHeightColor);

            presentationModel.LabelShapeHeightChange("1");
            Assert.AreEqual("#000000", presentationModel.LabelShapeHeightColor);
        }

        [TestMethod()]
        public void IsBtnAddEnabledTest()
        {
            presentationModel.LabelShapeContentChange("");
            Assert.IsFalse(presentationModel.IsBtnAddEnabled);

            presentationModel.LabelShapeContentChange("Content");
            presentationModel.LabelShapeXChange("1");
            presentationModel.LabelShapeYChange("10");
            presentationModel.LabelShapeWidthChange("200");
            presentationModel.LabelShapeHeightChange("100");
            Assert.IsTrue(presentationModel.IsBtnAddEnabled);

            presentationModel.LabelShapeYChange("0");
            Assert.IsFalse(presentationModel.IsBtnAddEnabled);
        }

        [TestMethod()]
        public void CanvasCousorTest()
        {
            presentationModel.SetToDrawState(Shape.Type.Start);
            Assert.AreEqual("Cross", presentationModel.CanvasCousor);

            presentationModel.SetToPointState();
            Assert.AreEqual("Default", presentationModel.CanvasCousor);
        }

        [TestMethod()]
        public void StateButtonCheckTest()
        {
            presentationModel.SetToDrawState(Shape.Type.Start);
            Assert.IsFalse(presentationModel.IsPointButtonnChecked);

            presentationModel.SetToPointState();
            Assert.IsTrue(presentationModel.IsPointButtonnChecked);

            presentationModel.SetToDrawLineState();
            Assert.IsTrue(presentationModel.IsDrawLineButtonChecked);
        }

        [TestMethod()]
        public void DrawStateShapeButtonCheckTest()
        {
            presentationModel.SetToDrawState(Shape.Type.Start);
            Assert.IsTrue(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);
            presentationModel.SetToPointState();
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);

            presentationModel.SetToDrawState(Shape.Type.Terminator);
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsTrue(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);
            presentationModel.SetToPointState();
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);

            presentationModel.SetToDrawState(Shape.Type.Process);
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsTrue(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);
            presentationModel.SetToPointState();
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);

            presentationModel.SetToDrawState(Shape.Type.Descision);
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsTrue(presentationModel.IsDrawDescisionButtonChecked);
            presentationModel.SetToPointState();
            Assert.IsFalse(presentationModel.IsDrawStartButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawTerminatorButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawProcessButtonChecked);
            Assert.IsFalse(presentationModel.IsDrawDescisionButtonChecked);
        }

        [TestMethod()]
        public void UndoRedoButtonCheckTest()
        {
            Assert.IsFalse(presentationModel.IsUndoButtonEnabled);
            Assert.IsFalse(presentationModel.IsRedoButtonEnabled);
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            Assert.IsTrue(presentationModel.IsUndoButtonEnabled);
            Assert.IsFalse(presentationModel.IsRedoButtonEnabled);
            presentationModel.Undo();
            Assert.IsTrue(presentationModel.IsUndoButtonEnabled);
            Assert.IsTrue(presentationModel.IsRedoButtonEnabled);
            presentationModel.Undo();
            Assert.IsFalse(presentationModel.IsUndoButtonEnabled);
            Assert.IsTrue(presentationModel.IsRedoButtonEnabled);
            presentationModel.Redo();
            presentationModel.AddShape(Shape.Type.Start, "Content", 0, 10, 200, 100);
            Assert.IsTrue(presentationModel.IsUndoButtonEnabled);
            Assert.IsFalse(presentationModel.IsRedoButtonEnabled);
        }

        [TestMethod()]
        public void NotifiyModelChangeTest()
        {
            bool flag = false;
            Assert.IsFalse(flag);

            presentationModel.NotifiyModelChange();
            Assert.IsFalse(flag);

            presentationModel.ModelChanged += () =>
            {
                flag = true;
            };
            presentationModel.NotifiyModelChange();
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void DataBindingNotifyTest()
        {
            ToolStripBindableButton button = new ToolStripBindableButton();
            button.DataBindings.Add("Checked", presentationModel, "IsDrawStartButtonChecked");
            Assert.IsFalse(button.Checked);
            presentationModel.SetToDrawState(Shape.Type.Start);
            Assert.IsTrue(button.Checked);
        }

        [TestMethod()]
        public void IsContentDoubleClickTest()
        {
            Assert.IsFalse(presentationModel.IsContentDoubleClick());
            presentationModel.SetToPointState();
            Assert.IsFalse(presentationModel.IsContentDoubleClick());
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            Assert.IsFalse(presentationModel.IsContentDoubleClick());
            presentationModel.pointState.MouseDown(50, 42);
            presentationModel.pointState.MouseDown(50, 42);
            presentationModel.pointState.MouseDown(50, 42);
            Assert.IsTrue(presentationModel.IsContentDoubleClick());
        }

        [TestMethod()]
        public void RemoveShapeAtTest()
        {
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            Assert.AreEqual(1, this.model.GetShapes().Count);
            Assert.AreEqual(1, this.presentationModel.commandManager.UndoCount);
            presentationModel.RemoveShapeAt(0);
            Assert.AreEqual(0, this.model.GetShapes().Count);
            Assert.AreEqual(2, this.presentationModel.commandManager.UndoCount);
        }
        [TestMethod]
        public void UndoTest()
        {
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            Assert.AreEqual(1, this.presentationModel.commandManager.UndoCount);
            Assert.AreEqual(0, this.presentationModel.commandManager.RedoCount);
            presentationModel.Undo();
            Assert.AreEqual(0, this.presentationModel.commandManager.UndoCount);
            Assert.AreEqual(1, this.presentationModel.commandManager.RedoCount);
        }

        [TestMethod]
        public void RedoTest()
        {
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            Assert.AreEqual(1, this.presentationModel.commandManager.UndoCount);
            Assert.AreEqual(0, this.presentationModel.commandManager.RedoCount);
            presentationModel.Undo();
            presentationModel.Redo();
            Assert.AreEqual(1, this.presentationModel.commandManager.UndoCount);
            Assert.AreEqual(0, this.presentationModel.commandManager.RedoCount);
        }

        [TestMethod()]
        public void ModitySelectedContentTest()
        {
            presentationModel.ModitySelectedContent("modify1");
            presentationModel.AddShape(Shape.Type.Start, "Start content", 0, 0, 100, 100);
            var selectShape = model.GetShapes()[0];
            model.SelectedShape = selectShape;
            Assert.AreEqual("Start content", selectShape.Content);
            presentationModel.ModitySelectedContent("modify2");
            Assert.AreEqual("modify2", selectShape.Content);
        }

        [TestMethod()]
        public void IsModifyContentConfirmButtonEnableTest()
        {
            presentationModel.OriginalContent = "Original";
            Assert.AreEqual("Original", presentationModel.OriginalContent);
            presentationModel.NewContent = "Original";
            Assert.AreEqual("Original", presentationModel.NewContent);
            Assert.IsFalse(presentationModel.IsModifyContentConfirmButtonEnable);
            presentationModel.NewContent = "test";
            Assert.AreEqual("test", presentationModel.NewContent);
            Assert.IsTrue(presentationModel.IsModifyContentConfirmButtonEnable);
        }
    }
}