using MyDrawing.shape;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
        private Color labelShapeContentColor = Color.Red;
        private Color labelShapeXColor = Color.Red;
        private Color labelShapeYColor = Color.Red;
        private Color labelShapeWidthColor = Color.Red;
        private Color labelShapeHeightColor = Color.Red;


        public PresentationModel(Model model)
        {
            this.model = model;
        }

        public void LabelShapeContentChange(string content)
        {
            if (string.Empty == content)
                this.labelShapeContentColor = Color.Red;
            else
                this.labelShapeContentColor = Color.Black;
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
                this.labelShapeXColor = Color.Black;
            }
            catch
            {
                this.labelShapeXColor = Color.Red;
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
                this.labelShapeYColor = Color.Black;
            }
            catch
            {
                this.labelShapeYColor = Color.Red;
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
                this.labelShapeWidthColor = Color.Black;
            }
            catch
            {
                this.labelShapeWidthColor = Color.Red;
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
                this.labelShapeHeightColor = Color.Black;
            }
            catch
            {
                this.labelShapeHeightColor = Color.Red;
            }
            notify("labelShapeHeightColor");
            UpdateBtnAddEnable();
        }

        private void UpdateBtnAddEnable()
        {
            this.isBtnAddEnabled = true;
            this.isBtnAddEnabled &= (labelShapeContentColor == Color.Black);
            this.isBtnAddEnabled &= (labelShapeXColor == Color.Black);
            this.isBtnAddEnabled &= (labelShapeYColor == Color.Black);
            this.isBtnAddEnabled &= (labelShapeWidthColor == Color.Black);
            this.isBtnAddEnabled &= (labelShapeHeightColor == Color.Black);
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

        public Cursor CanvasCousor
        {
            get { return this.model.currnetState == this.model.drawState ? Cursors.Cross : Cursors.Default; }
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
        public Color LabelShapeContentColor
        {
            get { return this.labelShapeContentColor; }
        }
        public Color LabelShapeXColor
        {
            get { return this.labelShapeXColor; }
        }
        public Color LabelShapeYColor
        {
            get { return this.labelShapeYColor; }
        }
        public Color LabelShapeHeightColor
        {
            get { return this.labelShapeHeightColor; }
        }
        public Color LabelShapeWidthColor
        {
            get { return this.labelShapeWidthColor; }
        }
    }
}
