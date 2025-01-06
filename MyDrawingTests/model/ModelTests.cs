using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.graphics;
using MyDrawing.shape;
using System.Linq;

namespace MyDrawing.model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;

        [TestInitialize]
        public void SetUp()
        {
            this.model = new Model();
        }

        [TestMethod()]
        public void GetShapeTypesNameTest()
        {
            string[] names = Model.GetShapeTypesName();
            Assert.AreEqual("Start", names[0]);
            Assert.AreEqual("Terminator", names[1]);
            Assert.AreEqual("Process", names[2]);
            Assert.AreEqual("Descision", names[3]);
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            Start start = new Start();
            Terminator terminator = new Terminator();

            Assert.AreEqual(0, model.GetShapes().Count);

            model.AddShape(start);
            Assert.AreEqual(1, model.GetShapes().Count);
            Assert.AreEqual(start, model.GetShapes()[0]);

            model.AddShape(terminator);
            Assert.AreEqual(2, model.GetShapes().Count);
            Assert.AreEqual(terminator, model.GetShapes()[1]);
        }

        [TestMethod()]
        public void RemoveShapeAtTest()
        {
            Start start = new Start();
            Terminator terminator = new Terminator();
            Process process = new Process();
            Descision descision = new Descision();

            model.AddShape(start);
            model.AddShape(terminator);
            model.AddShape(process);
            model.AddShape(descision);

            model.SelectedShape = terminator;

            Assert.AreEqual(terminator, model.GetShapes()[1]);
            model.RemoveShapeAt(1);
            Assert.AreEqual(null, model.SelectedShape);
            Assert.AreEqual(process, model.GetShapes()[1]);
            model.RemoveShapeAt(1);
            Assert.AreEqual(descision, model.GetShapes()[1]);
        }

        [TestMethod()]
        public void DrawTest()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            model.Draw(adapter);
            Assert.AreEqual(0, adapter.Command.Count);

            adapter.ClearAll();
            model.AddShape(new Start());
            model.Draw(adapter);
            Assert.AreNotEqual(0, adapter.Command.Count);
        }

        [TestMethod()]
        public void DrawTestWithNotCompleteShape()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            model.Draw(adapter);
            Assert.AreEqual(0, adapter.Command.Count);

            adapter.ClearAll();
            model.NotCompleteShape = new Start();
            model.Draw(adapter);
            Assert.AreNotEqual(0, adapter.Command.Count);
        }

        [TestMethod()]
        public void DrawTestWithSelectedShape()
        {
            MockGraphicAdapter adapter = new MockGraphicAdapter();
            model.Draw(adapter);
            Assert.AreEqual(0, adapter.Command.Count);

            adapter.ClearAll();
            // 這不可能發生，因為 model 中的 shapes 是空的，但是 selectedShpae 不為 null
            model.SelectedShape = new Start();
            model.Draw(adapter);
            Assert.AreNotEqual(0, adapter.Command.Count);
        }

        [TestMethod()]
        public void AddShapeFromNotCompleteTest()
        {
            Start start = new Start();
            Assert.AreEqual(null, model.NotCompleteShape);
            model.AddShape(model.NotCompleteShape);
            Assert.AreEqual(0, model.GetShapes().Count);

            model.NotCompleteShape = start;
            model.AddShape(model.NotCompleteShape);
            Assert.AreEqual(1, model.GetShapes().Count);
            Assert.AreEqual(start, model.GetShapes().Last());
        }

        bool flag = false;

        [TestMethod()]
        public void NotifiyModelChangeTest()
        {
            Assert.IsFalse(flag);

            model.NotifiyModelChange();
            Assert.IsFalse(flag);

            model.ModelChanged += () =>
            {
                flag = true;
            };
            model.NotifiyModelChange();
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void InsertShapeTest()
        {
            Start start = new Start();
            Terminator terminator = new Terminator();
            Process process = new Process();

            model.AddShape(start);
            Assert.AreEqual(start, model.GetShapes()[0]);
            model.InsertShape(0, terminator);
            Assert.AreEqual(terminator, model.GetShapes()[0]);
            model.InsertShape(2, process);
            Assert.AreEqual(process, model.GetShapes()[2]);
        }
    }
}