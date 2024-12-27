using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDrawing.controls.Tests
{
    [TestClass()]
    public class DoubleBufferedPanelTests
    {
        [TestMethod()]
        public void DoubleBufferedPanelTest()
        {
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            Assert.IsTrue(panel.IsDoubleBufferedEnabled);
        }
    }
}