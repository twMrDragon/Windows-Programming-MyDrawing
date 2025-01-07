using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingTests.ui.Tests;
using System;
using System.IO;

namespace MyDrawing.ui.Tests
{
    [TestClass]
    public class MainFormUITest
    {
        private Robot robor;
        private string targetAppPath;
        private const string APP_TITLE = "MyDrawing";

        [TestInitialize]
        public void SetUp()
        {
            var projectName = "MyDrawing";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawing.exe");
            robor = new Robot(targetAppPath, APP_TITLE);
        }

        [TestMethod]
        public void TestStriptButtonClick()
        {
            robor.ClickButton("toolStripButton1");
            robor.AssertEnable("toolStripButton1", true);
            //robor.ClickButton("toolStripButtonTerminator");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            robor.CleanUp();
        }
    }
}
