using MyDrawing.shape;
using System;
using System.ComponentModel;

namespace MyDrawing.presentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        readonly private Model model;

        // Observer pattern
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler ModelChanged;

        // DataBinding
        public event PropertyChangedEventHandler PropertyChanged;

        // btnAdd
        private bool isBtnAddEnabled = false;

        // label color
        private string labelShapeContentColor = "#FF0000";
        private string labelShapeXColor = "#FF0000";
        private string labelShapeYColor = "#FF0000";
        private string labelShapeWidthColor = "#FF0000";
        private string labelShapeHeightColor = "#FF0000";


        public PresentationModel(Model model)
        {
            this.model = model;
        }

        public void LabelShapeContentChange(string content)
        {
            if (string.Empty == content)
                this.labelShapeContentColor = "#FF0000";
            else
                this.labelShapeContentColor = "#000000";
            notify("labelShapeContentColor");
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
            notify("labelShapeXColor");
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
            notify("labelShapeYColor");
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
            notify("labelShapeWdithColor");
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
            notify("labelShapeHeightColor");
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
            notify("isBtnAddEnabled");
        }

        public void NotifiyModelChange()
        {
            ModelChanged?.Invoke();
        }

        private void notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string CanvasCousor
        {
            get { return this.model.currnetState == this.model.drawState ? "Cross" : "Default"; }
        }

        // state
        public bool IsPointButtonnChecked
        {
            get { return this.model.currnetState == this.model.pointState; }
        }
        public bool IsDrawButtonChecked
        {
            get { return this.model.currnetState == this.model.drawState; }
        }

        // draw shape
        public bool IsDrawStartButtonChecked
        {
            get { return this.model.currnetState == this.model.drawState && this.model.notCompleteShapeType == Shape.Type.Start; }
        }
        public bool IsDrawTerminatorButtonChecked
        {
            get { return this.model.currnetState == this.model.drawState && this.model.notCompleteShapeType == Shape.Type.Terminator; }
        }
        public bool IsDrawDescisionButtonChecked
        {
            get { return this.model.currnetState == this.model.drawState && this.model.notCompleteShapeType == Shape.Type.Descision; }
        }
        public bool IsDrawProcessButtonChecked
        {
            get { return this.model.currnetState == this.model.drawState && this.model.notCompleteShapeType == Shape.Type.Process; }
        }

        // data input
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
