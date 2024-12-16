using MyDrawing.command;
using MyDrawing.shape;
using MyDrawing.state;
using System;
using System.ComponentModel;

namespace MyDrawing.presentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        readonly private Model model;

        // command pattern
        private CommandManager commandManager = new CommandManager();

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

        // state
        private IState currnetState;
        readonly public IState pointState;
        readonly public IState drawState;
        readonly public IState drawLineState;

        public PresentationModel(Model model)
        {
            this.model = model;
            this.pointState = new PointState(this.model, this);
            this.drawState = new DrawState(this.model, this);
            this.drawLineState = new DrawLineState(this.model, this);
        }

        public bool IsContentDoubleClick(double x, double y)
        {
            if (this.currnetState != pointState)
                return false;
            if (model.SelectedShape == null)
                return false;
            return model.SelectedShape.IsPointInContentControlPoint(x, y);
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
            this.commandManager.Execute(new DeleteCommand(this.model, index));
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
            this.model.notCompleteShapeType = shapeType;
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
        /// <summary>
        /// 屬性
        /// </summary>

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
            get { return this.currnetState == this.drawState && this.model.notCompleteShapeType == Shape.Type.Start; }
        }
        public bool IsDrawTerminatorButtonChecked
        {
            get { return this.currnetState == this.drawState && this.model.notCompleteShapeType == Shape.Type.Terminator; }
        }
        public bool IsDrawDescisionButtonChecked
        {
            get { return this.currnetState == this.drawState && this.model.notCompleteShapeType == Shape.Type.Descision; }
        }
        public bool IsDrawProcessButtonChecked
        {
            get { return this.currnetState == this.drawState && this.model.notCompleteShapeType == Shape.Type.Process; }
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
