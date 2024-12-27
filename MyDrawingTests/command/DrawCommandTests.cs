using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            Assert.AreEqual(0, model.GetShapes().Count);
            Start start = new Start();
            DrawCommand command = new DrawCommand(model, start);
            command.Execute();
            Assert.AreEqual(1, model.GetShapes().Count);
            command.UnExecute();
            Assert.AreEqual(0, model.GetShapes().Count);
        }
    }
}