using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.command.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager commandManager;
        Model model;

        [TestInitialize]
        public void SetUp()
        {
            commandManager = new CommandManager();
            model = new Model();
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            commandManager.Execute(new AddCommand(model, new Start()));
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.ThrowsException<System.Exception>(() => commandManager.Undo());
            commandManager.Execute(new AddCommand(model, new Start()));
            commandManager.Undo();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Assert.ThrowsException<System.Exception>(() => commandManager.Redo());
            commandManager.Execute(new AddCommand(model, new Start()));
            commandManager.Undo();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Redo();
            Assert.IsTrue(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }
    }
}