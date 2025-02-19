using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        [TestMethod()]
        public void CreateShapeTestInEnumRange()
        {
            Start start = new Start();
            Terminator terminator = new Terminator();
            Process process = new Process();
            Descision descision = new Descision();

            Shape shape = ShapeFactory.CreateShape(Shape.Type.Start);
            Assert.AreEqual(start.GetType(), shape.GetType());

            shape = ShapeFactory.CreateShape(Shape.Type.Terminator);
            Assert.AreEqual(terminator.GetType(), shape.GetType());

            shape = ShapeFactory.CreateShape(Shape.Type.Process);
            Assert.AreEqual(process.GetType(), shape.GetType());

            shape = ShapeFactory.CreateShape(Shape.Type.Descision);
            Assert.AreEqual(descision.GetType(), shape.GetType());
        }

        [TestMethod()]
        public void CreateShapeTestOutEnumRange()
        {
            Start start = new Start();

            Shape shape = ShapeFactory.CreateShape((Shape.Type)4);
            Assert.AreEqual(start.GetType(), shape.GetType());

            shape = ShapeFactory.CreateShape((Shape.Type)100);
            Assert.AreEqual(start.GetType(), shape.GetType());
        }
    }
}