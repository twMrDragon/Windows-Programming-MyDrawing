using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class TextMoveCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Start start = new Start()
            {
                X = 0,
                Y = 0,
                Width = 200,
                Height = 100,
                ContentRelativelyX = 100,
                ContentRelativelyY = 50
            };
            TextMoveCommand textMoveCommand = new TextMoveCommand(start);
            textMoveCommand.SetStartPoint(0, 0);
            textMoveCommand.SetEndPoint(50, 50);
            textMoveCommand.Execute();
            Assert.AreEqual(100, start.ContentRelativelyX);
            Assert.AreEqual(50, start.ContentRelativelyY);
            textMoveCommand.Execute();
            Assert.AreEqual(150, start.ContentRelativelyX);
            Assert.AreEqual(100, start.ContentRelativelyY);
            textMoveCommand.UnExecute();
            Assert.AreEqual(100, start.ContentRelativelyX);
            Assert.AreEqual(50, start.ContentRelativelyY);
        }
    }
}