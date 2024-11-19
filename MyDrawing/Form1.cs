using MyDrawing.graphics;
using MyDrawing.presentationModel;
using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class Form1 : Form
    {
        readonly private Model model;
        private PresentationModel presentationModel;
        readonly DoubleBufferedPanel canvas = new DoubleBufferedPanel();

        public Form1(Model model)
        {
            this.model = model;
            this.model.ModelChanged += HandleModelChange;
            this.presentationModel = new PresentationModel(this.model);
            this.presentationModel.ModelChanged += HandlePresentationModelChange;

            // origin init controls
            InitializeComponent();

            // init controls
            InitComboBox();
            InitToolScriptButtons();
            InitCanvas();
            InitTextBoox();

            // databinding
            InitDataBinding();

            this.presentationModel.NotifiyModelChange();

            Test();
        }

        private void InitDataBinding()
        {
            // user input
            this.btnAddShape.DataBindings.Add("Enabled", presentationModel, "isBtnAddEnabled");
            this.labelShapeContent.DataBindings.Add("ForeColor", presentationModel, "labelShapeContentColor");
            this.labelShapeX.DataBindings.Add("ForeColor", presentationModel, "labelShapeXColor");
            this.labelShapeY.DataBindings.Add("ForeColor", presentationModel, "labelShapeYColor");
            this.labelShapeWidth.DataBindings.Add("ForeColor", presentationModel, "labelShapeWidthColor");
            this.labelShapeHeight.DataBindings.Add("ForeColor", presentationModel, "labelShapeHeightColor");

            // toolScript
        }

        private void InitTextBoox()
        {
            this.textBoxShapeContent.TextChanged += (s, e) =>
            {
                presentationModel.LabelShapeContentChange(this.textBoxShapeContent.Text);
            };
            this.textBoxShapeX.TextChanged += (s, e) =>
            {
                presentationModel.LabelShapeXChange(this.textBoxShapeX.Text);
            };
            this.textBoxShapeY.TextChanged += (s, e) =>
            {
                presentationModel.LabelShapeYChange(this.textBoxShapeY.Text);
            };
            this.textBoxShapeWidth.TextChanged += (s, e) =>
            {
                presentationModel.LabelShapeWidthChange(this.textBoxShapeWidth.Text);
            };
            this.textBoxShapeHeight.TextChanged += (s, e) =>
            {
                presentationModel.LabelShapeHeightChange(this.textBoxShapeHeight.Text);
            };
        }

        private void Test()
        {
            this.model.CreateShape(Shape.Type.Start, "Start text", 40, 50, 50, 50);
            this.model.CreateShape(Shape.Type.Terminator, "Terminator text", 400, 400, 180, 90);
            this.model.CreateShape(Shape.Type.Process, "Process text", 500, 150, 100, 50);
            this.model.CreateShape(Shape.Type.Descision, "Descision text", 90, 200, 100, 100);
        }

        private void InitComboBox()
        {
            // 所有圖形元素名稱
            comboBoxShapeType.Items.AddRange(Model.GetShapeTypesName());
            comboBoxShapeType.SelectedIndex = 0;
        }

        private void InitToolScriptButtons()
        {
            this.toolStripButtonStart.Click += (s, e) =>
            {
                this.model.SetToDrawState(Shape.Type.Start);
                this.presentationModel.NotifiyModelChange();
            };
            this.toolStripButtonTerminator.Click += (s, e) =>
            {
                this.model.SetToDrawState(Shape.Type.Terminator);
                this.presentationModel.NotifiyModelChange();
            };
            this.toolStripButtonProcess.Click += (s, e) =>
            {
                this.model.SetToDrawState(Shape.Type.Process);
                this.presentationModel.NotifiyModelChange();
            };
            this.toolStripButtonDescision.Click += (s, e) =>
            {
                this.model.SetToDrawState(Shape.Type.Descision);
                this.presentationModel.NotifiyModelChange();
            };
            this.toolStripButtonPoint.Click += (s, e) =>
            {
                this.model.SetToPointState();
                this.presentationModel.NotifiyModelChange();
            };
        }

        private void InitCanvas()
        {
            this.Controls.Add(canvas);
            canvas.BringToFront();
            canvas.Dock = DockStyle.Fill;

            this.canvas.Paint += CanvasPaint;
            this.canvas.MouseDown += CanvasMouseDown;
            this.canvas.MouseUp += CanvasMouseUp;
            this.canvas.MouseMove += CanvasMouseMove;
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            model.HandleMouseMoved(e.X, e.Y);
        }

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            model.HandleMousePressed(e.X, e.Y);
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            model.HandleMouseReleases(e.X, e.Y);
            this.presentationModel.NotifiyModelChange();
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            model.Draw(new FormGraphicAdapter(e.Graphics));
        }

        private void BtnAddShapeClick(object sender, EventArgs e)
        {
            Shape.Type shapeType = (Shape.Type)Enum.Parse(typeof(Shape.Type), comboBoxShapeType.Text);
            int x = int.Parse(textBoxShapeX.Text);
            int y = int.Parse(textBoxShapeY.Text);
            int width = int.Parse(textBoxShapeWidth.Text);
            int height = int.Parse(textBoxShapeHeight.Text);
            model.CreateShape(shapeType, textBoxShapeContent.Text, x, y, width, height);
        }

        // 重新刷新 dataGridView
        private void UpdateDataGridView()
        {
            // 用改資料的方式增加效能
            IList<Shape> shapes = model.GetShapes();
            int diff = Math.Abs(dataGridViewShapes.Rows.Count - shapes.Count);
            if (dataGridViewShapes.Rows.Count < shapes.Count)
                for (int i = 0; i < diff; i++)
                    dataGridViewShapes.Rows.Add();
            else if (dataGridViewShapes.Rows.Count > shapes.Count)
                for (int i = 0; i < diff; i++)
                    dataGridViewShapes.Rows.RemoveAt(0);
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                dataGridViewShapes.Rows[i].Cells[1].Value = "刪除";
                dataGridViewShapes.Rows[i].Cells[1].Value = i + 1;
                dataGridViewShapes.Rows[i].Cells[2].Value = shape.ShapeName;
                dataGridViewShapes.Rows[i].Cells[3].Value = shape.Content;
                dataGridViewShapes.Rows[i].Cells[4].Value = shape.X;
                dataGridViewShapes.Rows[i].Cells[5].Value = shape.Y;
                dataGridViewShapes.Rows[i].Cells[6].Value = shape.Height;
                dataGridViewShapes.Rows[i].Cells[7].Value = shape.Width;
            }
        }

        // dataGridView 內容被點擊
        private void DataGridViewShapesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 當刪除按鈕欄被點擊時
            if (e.ColumnIndex == 0)
                model.RemoveShapeAt(e.RowIndex);
        }

        // 更新畫布和 dataGridView
        private void HandleModelChange()
        {
            // canvas
            this.canvas.Invalidate();
            // datagridview
            // 如過正在畫圖就不更新 dataGridView，因為資料沒變
            if (presentationModel.IsDrawButtonChecked)
                return;
            UpdateDataGridView();
        }

        private void HandlePresentationModelChange()
        {
            // toolStript button
            this.toolStripButtonStart.Checked = presentationModel.IsDrawStartButtonChecked;
            this.toolStripButtonTerminator.Checked = presentationModel.IsDrawTerminatorButtonChecked;
            this.toolStripButtonDescision.Checked = presentationModel.IsDrawDescisionButtonChecked;
            this.toolStripButtonProcess.Checked = presentationModel.IsDrawProcessButtonChecked;
            this.toolStripButtonPoint.Checked = presentationModel.IsPointButtonnChecked;

            // canvas cursor
            this.canvas.Cursor = presentationModel.CanvasCousor;
        }
    }
}
