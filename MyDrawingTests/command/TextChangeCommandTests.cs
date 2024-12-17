using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class TextChangeCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Start start = new Start()
            {
                Content = "first"
            };
            TextChangeCommand command = new TextChangeCommand(start, "second");
            Assert.AreEqual("first", start.Content);
            command.Execute();
            Assert.AreEqual("second", start.Content);
            command.UnExecute();
            Assert.AreEqual("first", start.Content);
        }
    }
}