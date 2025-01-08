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
        public void TestToolStripButtonStartChecked()
        {
            robor.ClickButton("toolStripButtonStart");
            robor.AssertChecked("toolStripButtonStart", true);
            robor.AssertChecked("toolStripButtonTerminator", false);
            robor.AssertChecked("toolStripButtonProcess", false);
            robor.AssertChecked("toolStripButtonDescision", false);
            robor.AssertChecked("toolStripButtonLine", false);

            robor.ClickButton("toolStripButtonStart");
            robor.MouseAction("MyCanvas", 10, 10, 110, 110);
            robor.ClickButton("toolStripButtonStart");
            robor.MouseAction("MyCanvas", 220, 10, 120, 110);
            robor.ClickButton("toolStripButtonStart");
            robor.MouseAction("MyCanvas", 10, 220, 110, 120);
            robor.ClickButton("toolStripButtonStart");
            robor.MouseAction("MyCanvas", 220, 220, 120, 120);
        }

        //[TestMethod]
        //public void TestToolStripButtonTerminatorChecked()
        //{
        //    robor.ClickButton("toolStripButtonTerminator");
        //    robor.AssertChecked("toolStripButtonStart", false);
        //    robor.AssertChecked("toolStripButtonTerminator", true);
        //    robor.AssertChecked("toolStripButtonProcess", false);
        //    robor.AssertChecked("toolStripButtonDescision", false);
        //    robor.AssertChecked("toolStripButtonLine", false);

        //    robor.ClickButton("toolStripButtonTerminator");
        //    robor.MouseAction("MyCanvas", new[] { 10, 60, 110 }, new[] { 10, 60, 110 });
        //    robor.ClickButton("toolStripButtonTerminator");
        //    robor.MouseAction("MyCanvas", new[] { 220, 60, 120 }, new[] { 10, 60, 110 });
        //    robor.ClickButton("toolStripButtonTerminator");
        //    robor.MouseAction("MyCanvas", new[] { 10, 60, 110 }, new[] { 220, 60, 120 });
        //    robor.ClickButton("toolStripButtonTerminator");
        //    robor.MouseAction("MyCanvas", new[] { 220, 60, 120 }, new[] { 220, 60, 120 });
        //}



        //robor.ClickButton("toolStripButtonTerminator");
        //    robor.AssertChecked("toolStripButtonStart", false);
        //    robor.AssertChecked("toolStripButtonTerminator", true);
        //    robor.AssertChecked("toolStripButtonProcess", false);
        //    robor.AssertChecked("toolStripButtonDescision", false);
        //    robor.AssertChecked("toolStripButtonLine", false);

        //    robor.ClickButton("toolStripButtonProcess");
        //    robor.AssertChecked("toolStripButtonStart", false);
        //    robor.AssertChecked("toolStripButtonTerminator", false);
        //    robor.AssertChecked("toolStripButtonProcess", true);
        //    robor.AssertChecked("toolStripButtonDescision", false);
        //    robor.AssertChecked("toolStripButtonLine", false);

        //    robor.ClickButton("toolStripButtonDescision");
        //    robor.AssertChecked("toolStripButtonStart", false);
        //    robor.AssertChecked("toolStripButtonTerminator", false);
        //    robor.AssertChecked("toolStripButtonProcess", false);
        //    robor.AssertChecked("toolStripButtonDescision", true);
        //    robor.AssertChecked("toolStripButtonLine", false);

        //    robor.ClickButton("toolStripButtonLine");
        //    robor.AssertChecked("toolStripButtonStart", false);
        //    robor.AssertChecked("toolStripButtonTerminator", false);
        //    robor.AssertChecked("toolStripButtonProcess", false);
        //    robor.AssertChecked("toolStripButtonDescision", false);
        //    robor.AssertChecked("toolStripButtonLine", true);

        [TestCleanup()]
        public void Cleanup()
        {
            robor.CleanUp();
        }
    }
}
