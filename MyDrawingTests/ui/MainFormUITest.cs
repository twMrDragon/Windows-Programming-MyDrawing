using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingTests.ui.Tests;
using System;
using System.IO;

namespace MyDrawing.ui.Tests
{
    [TestClass]
    public class MainFormUITest
    {
        private Robot robot;
        private string targetAppPath;
        private const string APP_TITLE = "MyDrawing";

        [TestInitialize]
        public void SetUp()
        {
            var projectName = "MyDrawing";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawing.exe");
            robot = new Robot(targetAppPath, APP_TITLE);
        }

        [TestMethod]
        public void TestStartDraw()
        {
            robot.ClickButton("toolStripButtonStart");
            robot.AssertChecked("toolStripButtonStart", true);
            robot.AssertChecked("toolStripButtonTerminator", false);
            robot.AssertChecked("toolStripButtonProcess", false);
            robot.AssertChecked("toolStripButtonDescision", false);
            robot.AssertChecked("toolStripButtonLine", false);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Start", 120, 10, 100, 100);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Start", 10, 120, 100, 100);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Start", 120, 120, 100, 100);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
        }

        [TestMethod]
        public void TestTerminatorDraw()
        {
            robot.ClickButton("toolStripButtonTerminator");
            robot.AssertChecked("toolStripButtonStart", false);
            robot.AssertChecked("toolStripButtonTerminator", true);
            robot.AssertChecked("toolStripButtonProcess", false);
            robot.AssertChecked("toolStripButtonDescision", false);
            robot.AssertChecked("toolStripButtonLine", false);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Terminator", 10, 10, 100, 100);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Terminator", 120, 10, 100, 100);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Terminator", 10, 120, 100, 100);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Terminator", 120, 120, 100, 100);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
        }

        [TestMethod]
        public void TestProcessDraw()
        {
            robot.ClickButton("toolStripButtonProcess");
            robot.AssertChecked("toolStripButtonStart", false);
            robot.AssertChecked("toolStripButtonTerminator", false);
            robot.AssertChecked("toolStripButtonProcess", true);
            robot.AssertChecked("toolStripButtonDescision", false);
            robot.AssertChecked("toolStripButtonLine", false);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Process", 10, 10, 100, 100);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Process", 120, 10, 100, 100);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Process", 10, 120, 100, 100);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Process", 120, 120, 100, 100);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
        }

        [TestMethod]
        public void TestDescisionDraw()
        {
            robot.ClickButton("toolStripButtonDescision");
            robot.AssertChecked("toolStripButtonStart", false);
            robot.AssertChecked("toolStripButtonTerminator", false);
            robot.AssertChecked("toolStripButtonProcess", false);
            robot.AssertChecked("toolStripButtonDescision", true);
            robot.AssertChecked("toolStripButtonLine", false);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Descision", 10, 10, 100, 100);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Descision", 120, 10, 100, 100);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Descision", 10, 120, 100, 100);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Descision", 120, 120, 100, 100);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
        }

        [TestMethod]
        public void TestLineDraw()
        {
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 200, 20, 300, 100);
            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 300, 300, 500, 40);
            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 500, 500, 450, 450);

            robot.ClickButton("toolStripButtonLine");
            robot.AssertChecked("toolStripButtonStart", false);
            robot.AssertChecked("toolStripButtonTerminator", false);
            robot.AssertChecked("toolStripButtonProcess", false);
            robot.AssertChecked("toolStripButtonDescision", false);
            robot.AssertChecked("toolStripButtonLine", true);

            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 110, 60, 200, 60);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 4, "Line", 110, 60, 90, 0);

            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 110, 60, 300, 170);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 5, "Line", 110, 60, 190, 110);

            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 6);
            // draw line fail
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 110, 60, 200, 100);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 6);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 5);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 5);
        }
        [TestMethod]
        public void TestDragShape()
        {
            // draw shape
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100);
            // drag shape
            robot.MouseAction("MyCanvas", 60, 60, 100, 90);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 50, 40, 100, 100);
            // undo redo
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 50, 40, 100, 100);
        }

        [TestMethod]
        public void TestDragContent()
        {
            // draw shape
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 50);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 50);
            // drag shape content
            robot.MouseAction("MyCanvas", 60, 55, 100, 100);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 90);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 95);
            // undo redo
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 50);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 50);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 90);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 95);
        }

        [TestMethod]
        public void TestEditContent()
        {
            // draw shape
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            // edit text (confirm)
            robot.MouseDoubleClick("MyCanvas", 60, 55);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Hello");
            robot.ClickButton("確認");
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Hello");
            // cancel
            robot.MouseDoubleClick("MyCanvas", 60, 55);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Hello world");
            robot.ClickButton("取消");
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Hello");
            // undo redo
            robot.MouseDoubleClick("MyCanvas", 60, 55);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Hello world");
            robot.ClickButton("確認");
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Hello world");
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Hello");
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Hello world");
        }

        [TestMethod]
        public void TestAddShapeFromButton()
        {
            robot.ComboBoxSelect("comboBoxShapeType", "Start");
            robot.SendText("textBoxShapeContent", "Start text");
            robot.SendText("textBoxShapeX", "10");
            robot.SendText("textBoxShapeY", "10");
            robot.SendText("textBoxShapeHeight", "50");
            robot.SendText("textBoxShapeWidth", "100");
            robot.ClickButton("新增");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 50);
            robot.AssertDataGridViewCellData("dataGridViewShapes", 0, 3, "Start text");

            robot.ComboBoxSelect("comboBoxShapeType", "Terminator");
            robot.SendText("textBoxShapeContent", "Terminator text");
            robot.SendText("textBoxShapeX", "20");
            robot.SendText("textBoxShapeY", "30");
            robot.SendText("textBoxShapeHeight", "100");
            robot.SendText("textBoxShapeWidth", "200");
            robot.ClickButton("新增");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Terminator", 20, 30, 200, 100);
            robot.AssertDataGridViewCellData("dataGridViewShapes", 1, 3, "Terminator text");

            robot.ComboBoxSelect("comboBoxShapeType", "Process");
            robot.SendText("textBoxShapeContent", "Process text");
            robot.SendText("textBoxShapeX", "50");
            robot.SendText("textBoxShapeY", "50");
            robot.SendText("textBoxShapeHeight", "50");
            robot.SendText("textBoxShapeWidth", "100");
            robot.ClickButton("新增");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Process", 50, 50, 100, 50);
            robot.AssertDataGridViewCellData("dataGridViewShapes", 2, 3, "Process text");

            robot.ComboBoxSelect("comboBoxShapeType", "Descision");
            robot.SendText("textBoxShapeContent", "Descision text");
            robot.SendText("textBoxShapeX", "10");
            robot.SendText("textBoxShapeY", "10");
            robot.SendText("textBoxShapeHeight", "100");
            robot.SendText("textBoxShapeWidth", "200");
            robot.ClickButton("新增");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Descision", 10, 10, 200, 100);
            robot.AssertDataGridViewCellData("dataGridViewShapes", 3, 3, "Descision text");

            robot.ClickDataGridViewCellBy("dataGridViewShapes", 0, "刪除");
            robot.ClickDataGridViewCellBy("dataGridViewShapes", 0, "刪除");
            robot.ClickDataGridViewCellBy("dataGridViewShapes", 0, "刪除");
            robot.ClickDataGridViewCellBy("dataGridViewShapes", 0, "刪除");
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 1);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            robot.CleanUp();
        }
    }
}
