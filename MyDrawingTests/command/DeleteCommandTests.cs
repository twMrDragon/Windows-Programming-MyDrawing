using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class DeleteCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            model.AddShape(new Start());
            Assert.AreEqual(1, model.GetShapes().Count);
            DeleteCommand command = new DeleteCommand(model, 0);
            command.Execute();
            Assert.AreEqual(0, model.GetShapes().Count);
            command.UnExecute();
            Assert.AreEqual(1, model.GetShapes().Count);
        }
    }
}