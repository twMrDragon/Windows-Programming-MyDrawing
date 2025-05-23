﻿using MyDrawing.command;
using MyDrawing.shape;
using MyDrawing.state;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyDrawing.presentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        readonly private Model model;

        // command pattern
        public CommandManager commandManager = new CommandManager();

        // Observer pattern
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // DataBinding
        public event PropertyChangedEventHandler PropertyChanged;

        // memeber for control
        // btnAdd
        private bool isBtnAddEnabled = false;
        // label color
        private string labelShapeContentColor = "#FF0000";
        private string labelShapeXColor = "#FF0000";
        private string labelShapeYColor = "#FF0000";
        private string labelShapeWidthColor = "#FF0000";
        private string labelShapeHeightColor = "#FF0000";
        // modify content form
        private string originalContent;
        private string newContent;

        // state
        private IState currnetState;
        readonly public PointState pointState;
        readonly public DrawState drawState;
        readonly public DrawLineState drawLineState;

        // save
        private bool isSaveButtonEnabled = true;
        private System.Timers.Timer timer;
        private bool isAutoSaving = false;
        private bool isModelChangeForAutoSaving = true;
        private const string backupFolder = "drawing_backup";
        private const int maxBackupCount = 5;

        public PresentationModel(Model model)
        {
            this.model = model;
            this.pointState = new PointState(this.model, this);
            this.drawState = new DrawState(this.model, this);
            this.drawLineState = new DrawLineState(this.model, this);
            SetAutoSaveTimer();
            SetModelChangeForAutoSaving();
        }

        private void SetModelChangeForAutoSaving()
        {
            this.model.ModelChanged += () =>
            {
                this.isModelChangeForAutoSaving = true;
            };
        }

        public string OriginalContent
        {
            get { return this.originalContent; }
            set
            {
                this.originalContent = value;
                Notify(nameof(IsModifyContentConfirmButtonEnable));
            }
        }

        public string NewContent
        {
            get { return this.newContent; }
            set
            {
                this.newContent = value;
                Notify(nameof(IsModifyContentConfirmButtonEnable));
            }
        }

        public bool IsContentDoubleClick()
        {
            if (this.currnetState != pointState)
                return false;
            if (model.SelectedShape == null)
                return false;
            return this.pointState.IsContentDoubleClick();
        }

        public void AddShape(Shape.Type shapeType, string content, int x, int y, int width, int height)
        {
            Shape shape = ShapeFactory.CreateShape(shapeType);
            shape.Content = content;
            shape.ContentRelativelyX = width / 2;
            shape.ContentRelativelyY = height / 2;
            shape.X = x;
            shape.Y = y;
            shape.Width = width;
            shape.Height = height;
            this.commandManager.Execute(new AddCommand(this.model, shape));
            NotifyUndoRedoToolStripButton();
        }

        public void RemoveShapeAt(int index)
        {
            IList<Shape> shapes = model.GetShapes();
            Shape mainRemoveShape = shapes[index];
            List<int> removeIndexes = new List<int> { index };
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].ShapeType == Shape.Type.Line)
                {
                    Line line = shapes[i] as Line;
                    if (line.StartShape == mainRemoveShape || line.EndShape == mainRemoveShape)
                        removeIndexes.Add(i);
                }
            }

            this.commandManager.Execute(new DeleteCommand(this.model, removeIndexes.ToArray()));
            NotifyUndoRedoToolStripButton();
        }

        public void Execute(ICommand command)
        {
            commandManager.Execute(command);
            NotifyUndoRedoToolStripButton();
        }

        public void Undo()
        {
            this.commandManager.Undo();
            NotifyUndoRedoToolStripButton();
        }

        public void Redo()
        {
            this.commandManager.Redo();
            NotifyUndoRedoToolStripButton();
        }

        public void SetToDrawState(Shape.Type shapeType)
        {
            this.currnetState = this.drawState;
            this.drawState.notCompleteShapeType = shapeType;
            this.model.SelectedShape = null;
            NotifyToolStripButton();
            NotifyCanvasCursor();
        }

        public void SetToDrawLineState()
        {
            this.currnetState = this.drawLineState;
            this.model.SelectedShape = null;
            NotifyToolStripButton();
            NotifyCanvasCursor();
        }

        public void SetToPointState()
        {
            this.currnetState = this.pointState;
            NotifyToolStripButton();
            NotifyCanvasCursor();
        }

        private void NotifyCanvasCursor()
        {
            Notify("CanvasCousor");
        }

        private void NotifyUndoRedoToolStripButton()
        {
            Notify("IsUndoButtonEnabled");
            Notify("IsRedoButtonEnabled");
        }

        private void NotifyToolStripButton()
        {
            Notify("IsDrawStartButtonChecked");
            Notify("IsDrawTerminatorButtonChecked");
            Notify("IsDrawDescisionButtonChecked");
            Notify("IsDrawProcessButtonChecked");
            Notify("IsDrawLineButtonChecked");
            Notify("IsPointButtonnChecked");
        }

        public void HandleMousePressed(double x, double y)
        {
            currnetState.MouseDown(x, y);
        }

        public void HandleMouseReleases(double x, double y)
        {
            currnetState.MouseUp(x, y);
        }

        public void HandleMouseMoved(double x, double y)
        {
            currnetState.MouseMove(x, y);
        }

        public void ModitySelectedContent(string content)
        {
            if (this.model.SelectedShape == null)
                return;
            this.commandManager.Execute(new TextChangeCommand(this.model.SelectedShape, content));
            NotifyUndoRedoToolStripButton();
        }

        public void LabelShapeContentChange(string content)
        {
            if (string.Empty == content)
                this.labelShapeContentColor = "#FF0000";
            else
                this.labelShapeContentColor = "#000000";
            Notify("LabelShapeContentColor");
            UpdateBtnAddEnable();
        }

        public void LabelShapeXChange(string num)
        {
            try
            {
                int x = int.Parse(num);
                if (x < 1)
                    throw new ArgumentOutOfRangeException(num);
                this.labelShapeXColor = "#000000";
            }
            catch
            {
                this.labelShapeXColor = "#FF0000";
            }
            Notify("LabelShapeXColor");
            UpdateBtnAddEnable();
        }

        public void LabelShapeYChange(string num)
        {
            try
            {
                int Y = int.Parse(num);
                if (Y < 1)
                    throw new ArgumentOutOfRangeException(num);
                this.labelShapeYColor = "#000000";
            }
            catch
            {
                this.labelShapeYColor = "#FF0000";
            }
            Notify("LabelShapeYColor");
            UpdateBtnAddEnable();
        }

        public void LabelShapeWidthChange(string num)
        {
            try
            {
                int width = int.Parse(num);
                if (width < 1)
                    throw new ArgumentOutOfRangeException(num);
                this.labelShapeWidthColor = "#000000";
            }
            catch
            {
                this.labelShapeWidthColor = "#FF0000";
            }
            Notify("LabelShapeWdithColor");
            UpdateBtnAddEnable();
        }
        public void LabelShapeHeightChange(string num)
        {
            try
            {
                int height = int.Parse(num);
                if (height < 1)
                    throw new ArgumentOutOfRangeException(num);
                this.labelShapeHeightColor = "#000000";
            }
            catch
            {
                this.labelShapeHeightColor = "#FF0000";
            }
            Notify("LabelShapeHeightColor");
            UpdateBtnAddEnable();
        }

        private void UpdateBtnAddEnable()
        {
            this.isBtnAddEnabled = true;
            this.isBtnAddEnabled &= (labelShapeContentColor == "#000000");
            this.isBtnAddEnabled &= (labelShapeXColor == "#000000");
            this.isBtnAddEnabled &= (labelShapeYColor == "#000000");
            this.isBtnAddEnabled &= (labelShapeWidthColor == "#000000");
            this.isBtnAddEnabled &= (labelShapeHeightColor == "#000000");
            Notify("IsBtnAddEnabled");
        }

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task SaveShape(string filename)
        {
            this.isSaveButtonEnabled = false;
            NotifiyModelChange();

            string json = model.GenerateShapesDataOfJson();
            File.WriteAllText(filename, json);
            await Task.Delay(3000);

            this.isSaveButtonEnabled = true;
            NotifiyModelChange();
        }

        public void LoadShape(string fileName)
        {
            string json = File.ReadAllText(fileName);
            commandManager.Clear();
            model.ParseShapesDataFromJson(json);
            NotifyUndoRedoToolStripButton();
        }

        private void SetAutoSaveTimer()
        {
            timer = new System.Timers.Timer(30000);
            timer.Elapsed += (s, e) =>
            {
                if (!isModelChangeForAutoSaving)
                    return;
                isModelChangeForAutoSaving = false;
                string backupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, backupFolder);
                AutoSave(backupFolderPath);
            };
            timer.AutoReset = true;
            timer.Start();
        }

        public async Task AutoSave(string backupFolderPath)
        {
            // 是否正在保存的 flag
            this.isAutoSaving = true;
            NotifiyModelChange();
            try
            {
                // 檢查檔案夾是否存在
                if (!Directory.Exists(backupFolderPath))
                    Directory.CreateDirectory(backupFolderPath);
                // 產生檔案名稱和路徑
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string backupFileName = $"{timestamp}_bak.mydrawing";
                string backupFilePath = Path.Combine(backupFolderPath, backupFileName);
                // 保存
                string json = model.GenerateShapesDataOfJson();
                File.WriteAllText(backupFilePath, json);
                // 刪除最舊的檔案如果數量大於閥值
                var backupFiles = Directory.GetFiles(backupFolderPath)
                                        .OrderByDescending(f => new FileInfo(f).CreationTime)
                                        .ToList();
                if (backupFiles.Count > maxBackupCount)
                    foreach (var file in backupFiles.Skip(maxBackupCount))
                        File.Delete(file);
            }
            catch
            {
                // 保存失敗
            }
            await Task.Delay(3000);
            this.isAutoSaving = false;
            NotifiyModelChange();
        }
        /// <summary>
        /// 屬性
        /// </summary>

        // 確認修改文字按鈕
        public bool IsModifyContentConfirmButtonEnable
        {
            get { return this.originalContent != this.newContent; }
        }

        // 當前狀態 (用在 unit test)
        public IState CurrentState
        {
            get { return this.currnetState; }
        }

        // 鼠標圖案
        public string CanvasCousor
        {
            get { return this.currnetState == this.pointState ? "Default" : "Cross"; }
        }

        // point 按鈕相關
        public bool IsPointButtonnChecked
        {
            get { return this.currnetState == this.pointState; }
        }
        // 各種繪圖按鈕相關
        public bool IsDrawStartButtonChecked
        {
            get { return this.currnetState == this.drawState && this.drawState.notCompleteShapeType == Shape.Type.Start; }
        }
        public bool IsDrawTerminatorButtonChecked
        {
            get { return this.currnetState == this.drawState && this.drawState.notCompleteShapeType == Shape.Type.Terminator; }
        }
        public bool IsDrawDescisionButtonChecked
        {
            get { return this.currnetState == this.drawState && this.drawState.notCompleteShapeType == Shape.Type.Descision; }
        }
        public bool IsDrawProcessButtonChecked
        {
            get { return this.currnetState == this.drawState && this.drawState.notCompleteShapeType == Shape.Type.Process; }
        }
        public bool IsDrawLineButtonChecked
        {
            get { return this.currnetState == this.drawLineState; }
        }
        // redo undo 按鈕相關
        public bool IsRedoButtonEnabled
        {
            get { return this.commandManager.IsRedoEnabled; }
        }
        public bool IsUndoButtonEnabled
        {
            get { return this.commandManager.IsUndoEnabled; }
        }
        // save 按鈕相關
        public bool IsSaveButtonEnabled
        {
            get { return this.isSaveButtonEnabled; }
        }
        public bool IsAutoSaving
        {
            get { return isAutoSaving; }
        }

        // 使用者輸入資料相關
        public bool IsBtnAddEnabled
        {
            get { return this.isBtnAddEnabled; }
        }
        public string LabelShapeContentColor
        {
            get { return this.labelShapeContentColor; }
        }
        public string LabelShapeXColor
        {
            get { return this.labelShapeXColor; }
        }
        public string LabelShapeYColor
        {
            get { return this.labelShapeYColor; }
        }
        public string LabelShapeHeightColor
        {
            get { return this.labelShapeHeightColor; }
        }
        public string LabelShapeWidthColor
        {
            get { return this.labelShapeWidthColor; }
        }
    }
}
