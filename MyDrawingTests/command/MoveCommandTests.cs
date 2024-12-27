using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Start start = new Start()
            {
                X = 0,
                Y = 0,
                Width = 200,
                Height = 100
            };
            MoveCommand moveCommand = new MoveCommand(start);
            moveCommand.SetStartPoint(0, 0);
            moveCommand.SetEndPoint(50, 50);
            moveCommand.Execute();
            Assert.AreEqual(0, start.X);
            Assert.AreEqual(0, start.Y);
            moveCommand.Execute();
            Assert.AreEqual(50, start.X);
            Assert.AreEqual(50, start.Y);
            moveCommand.UnExecute();
            Assert.AreEqual(0, start.X);
            Assert.AreEqual(0, start.Y);
        }
    }
}