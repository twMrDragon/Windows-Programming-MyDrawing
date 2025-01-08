using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;

namespace MyDrawingTests.ui.Tests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        public void ComboBoxSelect(string name, string itemName)
        {
            WindowsElement comboBox = _driver.FindElementByAccessibilityId(name);
            comboBox.Click();
            WindowsElement item = _driver.FindElementByName(itemName);
            item.Click();
        }

        public void SendText(string name, string value)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Clipboard.SetText(value);
            element.Click();
            element.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            element.SendKeys(OpenQA.Selenium.Keys.Control + "v");
        }

        // test
        public void MouseDoubleClick(string name, int x, int y)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(element, x, y)
                .DoubleClick()
                .Perform();
        }

        //test
        public void MouseAction(string name, int startX, int startY, int endX, int endY)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(element, startX, startY)
                .ClickAndHold()
                .MoveByOffset(endX - startX, endY - startY);
            Thread.Sleep(100);
            action.Release()
             .Perform();
        }

        // test
        public void AssertChecked(string name, bool expected)
        {
            WindowsElement element = _driver.FindElementByName(name);
            string stateValue = element.GetAttribute("LegacyState");
            int state = int.Parse(stateValue);
            const int STATE_CHECKED = 0x4;
            Assert.AreEqual(expected, (state & STATE_CHECKED) == STATE_CHECKED);
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowShape(string name, int rowIndex, string shapeName, int x, int y, int width, int height)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            Assert.AreEqual(shapeName, rowDatas[3].Text);
            int value = int.Parse(rowDatas[5].Text);
            Assert.IsTrue(x >= value - 1 && x <= value + 1);
            value = int.Parse(rowDatas[6].Text);
            Assert.IsTrue(y >= value - 1 && y <= value + 1);
            value = int.Parse(rowDatas[7].Text);
            Assert.IsTrue(height >= value - 1 && height <= value + 1);
            value = int.Parse(rowDatas[8].Text);
            Assert.IsTrue(width >= value - 1 && width <= value + 1);
        }

        // test
        public void AssertDataGridViewCellData(string name, int rowIndex, int columnIndex, string data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            Assert.AreEqual(data, rowDatas[columnIndex + 1].Text);
        }

        public void AssertDataGridViewCellDataNumber(string name, int rowIndex, int columnIndex, int data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            int value = int.Parse(rowDatas[columnIndex + 1].Text);
            int expected = int.Parse(data.ToString());
            Assert.IsTrue(expected >= value - 1 && expected <= value + 1);
        }
        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}
