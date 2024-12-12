using MyDrawing.controls;
using MyDrawing.graphics;
using MyDrawing.presentationModel;
using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class Form1 : Form
    {
        readonly private Model model;
        private PresentationModel presentationModel;
        readonly DoubleBufferedPanel canvas = new DoubleBufferedPanel();
        private CursorConverter cursorConverter = new CursorConverter();

        public Form1(Model model)
        {
            this.model = model;
            this.model.ModelChanged += HandleModelChange;
            this.presentationModel = new PresentationModel(this.model);

            // origin init controls
            InitializeComponent();

            // init controls
            InitComboBox();
            InitToolScriptButtons();
            InitCanvas();
            InitTextBoox();

            // databinding
            InitDataBinding();

            presentationModel.SetToPointState();

            Test();
        }

        private void InitDataBinding()
        {
            // user input
            this.btnAddShape.DataBindings.Add("Enabled", presentationModel, "IsBtnAddEnabled");
            CreateBindingHexToColor(labelShapeContent.DataBindings, "ForeColor", presentationModel, "LabelShapeContentColor");
            CreateBindingHexToColor(labelShapeX.DataBindings, "ForeColor", presentationModel, "LabelShapeXColor");
            CreateBindingHexToColor(labelShapeY.DataBindings, "ForeColor", presentationModel, "LabelShapeYColor");
            CreateBindingHexToColor(labelShapeWidth.DataBindings, "ForeColor", presentationModel, "LabelShapeWidthColor");
            CreateBindingHexToColor(labelShapeHeight.DataBindings, "ForeColor", presentationModel, "LabelShapeHeightColor");

            // toolScript
            this.toolStripButtonStart.DataBindings.Add("Checked", presentationModel, "IsDrawStartButtonChecked");
            this.toolStripButtonTerminator.DataBindings.Add("Checked", presentationModel, "IsDrawTerminatorButtonChecked");
            this.toolStripButtonDescision.DataBindings.Add("Checked", presentationModel, "IsDrawDescisionButtonChecked");
            this.toolStripButtonProcess.DataBindings.Add("Checked", presentationModel, "IsDrawProcessButtonChecked");
            this.toolStripButtonLine.DataBindings.Add("Checked", presentationModel, "IsDrawLineButtonChecked");
            this.toolStripButtonPoint.DataBindings.Add("Checked", presentationModel, "IsPointButtonnChecked");
            this.toolStripButtonRedo.DataBindings.Add("Enabled", presentationModel, "IsRedoButtonEnabled");
            this.toolStripButtonUndo.DataBindings.Add("Enabled", presentationModel, "IsUndoButtonEnabled");

            // canvas
            Binding binding = new Binding("Cursor", presentationModel, "CanvasCousor");
            binding.Format += (s, e) =>
            {
                e.Value = (Cursor)cursorConverter.ConvertFromString(e.Value.ToString());
            };
            this.canvas.DataBindings.Add(binding);
        }

        private void CreateBindingHexToColor(ControlBindingsCollection dataBindings, string propertyName, object dataSource, string dataMember)
        {
            Binding binding = new Binding(propertyName, dataSource, dataMember);
            binding.Format += BindingFormat;
            dataBindings.Add(binding);
        }

        private void BindingFormat(object sender, ConvertEventArgs e)
        {
            e.Value = ColorTranslator.FromHtml(e.Value.ToString());
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
            this.presentationModel.CreateShape(Shape.Type.Start, "Start text", 40, 50, 50, 50);
            this.presentationModel.CreateShape(Shape.Type.Terminator, "Terminator text", 400, 400, 180, 90);
            this.presentationModel.CreateShape(Shape.Type.Process, "Process text", 500, 150, 100, 50);
            this.presentationModel.CreateShape(Shape.Type.Descision, "Descision text", 90, 200, 100, 100);
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
                this.presentationModel.SetToDrawState(Shape.Type.Start);
            };
            this.toolStripButtonTerminator.Click += (s, e) =>
            {
                this.presentationModel.SetToDrawState(Shape.Type.Terminator);
            };
            this.toolStripButtonProcess.Click += (s, e) =>
            {
                this.presentationModel.SetToDrawState(Shape.Type.Process);
            };
            this.toolStripButtonDescision.Click += (s, e) =>
            {
                this.presentationModel.SetToDrawState(Shape.Type.Descision);
            };
            this.toolStripButtonLine.Click += (s, e) =>
            {
                this.presentationModel.SetToDrawLineState();
            };
            this.toolStripButtonPoint.Click += (s, e) =>
            {
                this.presentationModel.SetToPointState();
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
            this.canvas.MouseDoubleClick += CanvasMouseDoubleClick;
        }

        private void CanvasMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (presentationModel.IsContentDoubleClick(e.X, e.Y))
            {
                EditContentForm form = new EditContentForm(model.selectedShape.Content);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    presentationModel.EditSelectedContent(form.TextBoxContent);
                }
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            this.presentationModel.HandleMouseMoved(e.X, e.Y);
        }

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            this.presentationModel.HandleMousePressed(e.X, e.Y);
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            this.presentationModel.HandleMouseReleases(e.X, e.Y);
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
            this.presentationModel.CreateShape(shapeType, textBoxShapeContent.Text, x, y, width, height);
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

        // 被告知要更新畫布和 dataGridView
        private void HandleModelChange()
        {
            // canvas
            this.canvas.Invalidate();
            // datagridview
            // 如果資料沒變就不更新 dataGridView

            UpdateDataGridView();
        }
    }
}
