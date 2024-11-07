using MyDrawing.graphics;
using MyDrawing.shape;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class Form1 : Form
    {
        private Model model;
        DoubleBufferedPanel canvas = new DoubleBufferedPanel();
        List<ToolStripButton> toolStripButtons = new List<ToolStripButton>();
        private bool isUpdateDataGridView = true;

        public Form1(Model model)
        {
            this.model = model;
            this.model.modelChanged += HandleModelChange;
            InitializeComponent();
            InitComboBox();
            InitToolScriptButtons();
            InitCanvas();
            Test();
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
            comboBoxShapeType.Items.AddRange(model.GetShapeTypesName());
        }

        private void InitToolScriptButtons()
        {
            this.toolStripButtons.Add(this.toolStripButtonStart);
            this.toolStripButtons.Add(this.toolStripButtonTerminator);
            this.toolStripButtons.Add(this.toolStripButtonProcess);
            this.toolStripButtons.Add(this.toolStripButtonDecision);

            Shape.Type[] shapeTypes = { Shape.Type.Start, Shape.Type.Terminator, Shape.Type.Process, Shape.Type.Descision };

            for (int i = 0; i < this.toolStripButtons.Count; i++)
            {
                Shape.Type shapeType = shapeTypes[i];
                this.toolStripButtons[i].Click += (s, e) =>
                {
                    model.SelectNotCompleteShapeType(shapeType);
                    ToolStripButton toolStripButton = (ToolStripButton)s;
                    ToolStripButtontClick(toolStripButton);
                };
            }
        }
        private void ToolStripButtontClick(ToolStripButton toolStripButton)
        {
            // 如果點選的是已經選過的項目
            if (toolStripButton.Checked)
            {
                this.canvas.Cursor = Cursors.Default;
                toolStripButton.Checked = false;
                return;
            }
            SetAllToolScriptButtonCheckedFalse();
            this.canvas.Cursor = Cursors.Cross;
            toolStripButton.Checked = true;
        }

        private void SetAllToolScriptButtonCheckedFalse()
        {
            foreach (ToolStripButton item in toolStripButtons)
                item.Checked = false;
        }

        private bool IsAnyToolStripButtonChecked()
        {
            foreach (ToolStripButton item in toolStripButtons)
                if (item.Checked)
                    return true;
            return false;
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
            if (!IsAnyToolStripButtonChecked())
                return;
            // 開始繪製
            isUpdateDataGridView = false;
            model.HandleMousePressed(e.X, e.Y);
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            if (!IsAnyToolStripButtonChecked())
                return;
            // 完成繪製
            isUpdateDataGridView = true;
            model.HandleMouseReleases(e.X, e.Y);
            SetAllToolScriptButtonCheckedFalse();
            this.canvas.Cursor = Cursors.Default;
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            model.Draw(new FormGraphicAdapter(e.Graphics));
        }

        private void BtnAddShapeClick(object sender, EventArgs e)
        {
            // 檢查合法輸入
            try
            {
                Shape.Type shapeType = (Shape.Type)Enum.Parse(typeof(Shape.Type), comboBoxShapeType.Text);
                // 內容為空也不被認可
                if (textBoxShapeContent.Text == string.Empty)
                    throw new ArgumentNullException("textBoxShapeContent.text is empty");
                int x = int.Parse(textBoxShapeX.Text);
                int y = int.Parse(textBoxShapeY.Text);
                int width = int.Parse(textBoxShapeWidth.Text);
                int height = int.Parse(textBoxShapeHeight.Text);
                model.CreateShape(shapeType, textBoxShapeContent.Text, x, y, width, height);
            }
            catch
            {
                MessageBox.Show("欄位未輸入或有錯誤");
            }
        }

        // 重新刷新 dataGridView
        private void UpdateDataGridView()
        {
            dataGridViewShapes.Rows.Clear();
            IList<Shape> shapes = model.GetShapes();
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                dataGridViewShapes.Rows.Add("刪除", i + 1, shape.ShapeName, shape.Content, shape.X, shape.Y, shape.Height, shape.Width);
            }
        }

        // dataGridView 內容被點擊
        private void DataGridViewShapesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 當刪除按鈕欄被點擊時
            if (e.ColumnIndex == 0)
                model.RemoveShape(e.RowIndex);
        }

        // 更新畫布和 dataGridView
        private void HandleModelChange()
        {
            this.canvas.Invalidate(true);
            // 如過正在畫圖就不更新 dataGridView，因為資料沒變而且一直更新 dataGridView 很吃資源
            if (isUpdateDataGridView)
                UpdateDataGridView();
        }
    }
}
