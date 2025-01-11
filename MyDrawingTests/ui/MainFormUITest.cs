using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingTests.ui.Tests;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

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
            string projectName = "MyDrawingTests";
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Start", 120, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Start", 10, 120, 100, 100, 1);

            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Start", 120, 120, 100, 100, 1);

            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Start", 10, 120, 100, 100, 1);
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Terminator", 10, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Terminator", 120, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Terminator", 10, 120, 100, 100, 1);

            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Terminator", 120, 120, 100, 100, 1);

            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Terminator", 10, 120, 100, 100, 1);
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Process", 10, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Process", 120, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Process", 10, 120, 100, 100, 1);

            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Process", 120, 120, 100, 100, 1);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Process", 10, 120, 100, 100, 1);
        }

        [TestMethod, TestProperty("ExecutionOrder", "4")]
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Descision", 10, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 220, 10, 120, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, "Descision", 120, 10, 100, 100, 1);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 10, 220, 110, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Descision", 10, 120, 100, 100, 1);

            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 220, 220, 120, 120);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, "Descision", 120, 120, 100, 100, 1);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, "Descision", 10, 120, 100, 100, 1);
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 4, "Line", 110, 60, 90, 0, 1);

            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 110, 60, 300, 170);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 5, "Line", 110, 60, 190, 110, 1);

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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 4, "Line", 110, 60, 90, 0, 1);
        }
        [TestMethod]
        public void TestDragShape()
        {
            // draw shape
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100, 1);
            // drag shape
            robot.MouseAction("MyCanvas", 60, 60, 100, 90);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 50, 40, 100, 100, 2);
            // undo redo
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 10, 10, 100, 100, 1);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Start", 50, 40, 100, 100, 2);
        }

        [TestMethod]
        public void TestDragContent()
        {
            // draw shape
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 50, 1);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 50, 1);
            // drag shape content
            robot.MouseAction("MyCanvas", 60, 55, 100, 100);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 90, 1);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 95, 1);
            // undo redo
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 50, 1);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 50, 1);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 8, 90, 1);
            robot.AssertDataGridViewCellDataNumber("dataGridViewShapes", 0, 9, 95, 1);
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
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Descision", 10, 10, 200, 100);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Process", 50, 50, 100, 50);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Terminator", 20, 30, 200, 100);
            robot.ClickButton("toolStripButtonRedo");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, "Process", 50, 50, 100, 50);
        }

        [TestMethod]
        public void TestSaveAndLoad()
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
            robot.MouseAction("MyCanvas", 110, 60, 200, 60);
            robot.ClickButton("toolStripButtonSave");
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"{timestamp}_bak.mydrawing";
            string filePath = Path.Combine(Path.GetDirectoryName(targetAppPath), fileName);
            robot.SendText("1001", filePath);
            robot.ClickButton("存檔(S)");
            robot.AssertEnable("toolStripButtonSave", false);
            robot.AssertChecked("toolStripButtonStart", false);
            robot.ClickButton("toolStripButtonStart");
            robot.AssertChecked("toolStripButtonStart", true);
            Thread.Sleep(3000);
            robot.AssertEnable("toolStripButtonSave", true);
            robot.ClickDataGridViewCellBy("dataGridViewShapes", 0, "刪除");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            robot.ClickButton("toolStripButtonLoad");
            Thread.Sleep(1000);
            robot.SendTextToEdit(filePath);
            robot.ClickButton("開啟(O)");
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 0, null, 10, 10, 100, 100, 1);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 1, null, 200, 20, 100, 80, 1);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 2, null, 300, 40, 200, 260, 1);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 3, null, 450, 450, 50, 50, 1);
            robot.AssertDataGridViewRowShape("dataGridViewShapes", 4, "Line", 110, 60, 90, 0, 1);
            File.Delete(filePath);
        }

        [TestMethod]
        public void TestAutoSave()
        {
            string timestamp = DateTime.Now.AddSeconds(30).ToString("yyyyMMddHHmmss");
            string fileName = $"{timestamp}_bak.mydrawing";
            string filePath = Path.Combine(Path.GetDirectoryName(targetAppPath), fileName);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string backupFolderPath = Path.Combine(Path.GetDirectoryName(targetAppPath), "drawing_backup");
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 10, 10, 110, 110);
            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 200, 20, 300, 100);
            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 300, 300, 500, 40);
            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 500, 500, 450, 450);
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 110, 60, 200, 60);
            stopwatch.Stop();
            Thread.Sleep((int)(31000 - stopwatch.ElapsedMilliseconds));
            robot.AssertName("Form1", "MyDrawing (Auto saving...)");
            robot.AssertChecked("toolStripButtonStart", false);
            robot.ClickButton("toolStripButtonStart");
            robot.AssertChecked("toolStripButtonStart", true);
            Thread.Sleep(3000);
            File.Exists(backupFolderPath);
        }

        [TestMethod]
        public void TestMix()
        {
            // start
            robot.ClickButton("toolStripButtonStart");
            robot.MouseAction("MyCanvas", 100, 10, 200, 60);
            // 修改文字
            robot.MouseDoubleClick("MyCanvas", 150, 30);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Start");
            robot.ClickButton("確認");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 1);
            // process 1
            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 100, 80, 200, 160);
            // 修改文字
            robot.MouseDoubleClick("MyCanvas", 150, 115);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Process 1");
            robot.ClickButton("確認");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 2);
            //
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 150, 60, 150, 80);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 3);
            // Descision
            robot.ClickButton("toolStripButtonDescision");
            robot.MouseAction("MyCanvas", 100, 180, 200, 240);
            // 修改文字
            robot.MouseDoubleClick("MyCanvas", 150, 205);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Descision");
            robot.ClickButton("確認");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 4);
            //
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 150, 160, 150, 180);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 5);
            // process 2
            robot.ClickButton("toolStripButtonProcess");
            robot.MouseAction("MyCanvas", 300, 180, 400, 240);
            // 修改文字
            robot.MouseDoubleClick("MyCanvas", 350, 205);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Process 2");
            robot.ClickButton("確認");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 6);
            //
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 200, 210, 300, 210);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 7);
            // Terminator
            robot.ClickButton("toolStripButtonTerminator");
            robot.MouseAction("MyCanvas", 100, 300, 200, 350);
            // 修改文字
            robot.MouseDoubleClick("MyCanvas", 150, 320);
            robot.SwitchTo("EditContentForm");
            robot.SendText("textContent", "Terminator");
            robot.ClickButton("確認");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 8);
            //
            robot.ClickButton("toolStripButtonLine");
            robot.MouseAction("MyCanvas", 150, 240, 150, 300);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 9);
            //
            robot.MouseAction("MyCanvas", 350, 240, 150, 300);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 10);
            // 存檔
            robot.ClickButton("toolStripButtonSave");
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"{timestamp}_bak.mydrawing";
            string filePath = Path.Combine(Path.GetDirectoryName(targetAppPath), fileName);
            robot.SendText("1001", filePath);
            robot.ClickButton("存檔(S)");
            Thread.Sleep(3000);
            // 移動
            robot.ClickButton("toolStripButtonPoint");
            robot.MouseAction("MyCanvas", 310, 190, 510, 190);
            // 刪除
            robot.ClickDataGridViewCellBy("dataGridViewShapes", 3, "刪除");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 6);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 10);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 10);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 9);
            robot.ClickButton("toolStripButtonUndo");
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 8);
            // 開檔
            robot.ClickButton("toolStripButtonLoad");
            Thread.Sleep(1000);
            robot.SendTextToEdit(filePath);
            robot.ClickButton("開啟(O)");
            Thread.Sleep(3000);
            robot.AssertDataGridViewRowCountBy("dataGridViewShapes", 10);
            File.Delete(filePath);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            robot.CleanUp();
        }
    }
}
