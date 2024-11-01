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
        private bool isDrawing = false;
        List<ToolStripButton> toolStripButtons = new List<ToolStripButton>();
        public Form1(Model model)
        {
            InitializeComponent();
            this.model = model;
            InitComboBox();
            InitToolScriptButtons();
            InitCanvas();
            this.model.modelChanged += HandleModelChange;
            Test();
        }

        private void Test()
        {
            this.model.CreateShape(ShapeFactory.ShapeType.Start, "Start text", 40, 50, 50, 50);
            this.model.CreateShape(ShapeFactory.ShapeType.Terminator, "Terminator text", 400, 400, 90, 180);
            this.model.CreateShape(ShapeFactory.ShapeType.Process, "Process text", 500, 150, 50, 100);
            this.model.CreateShape(ShapeFactory.ShapeType.Descision, "Descision text", 90, 200, 100, 100);
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

            ShapeFactory.ShapeType[] shapeTypes = { ShapeFactory.ShapeType.Start, ShapeFactory.ShapeType.Terminator, ShapeFactory.ShapeType.Process, ShapeFactory.ShapeType.Descision };



            for (int i = 0; i < this.toolStripButtons.Count; i++)
            {
                ShapeFactory.ShapeType shapeType = shapeTypes[i];
                this.toolStripButtons[i].Click += (s, e) =>
                {
                    model.DrawingShapeTypeSelect(shapeType);
                    ToolStripButton toolStripButton = (ToolStripButton)s;
                    ToolStripButtontClick(toolStripButton);
                };
            }
        }

        private void ToolStripButtontClick(ToolStripButton toolStripButton)
        {
            if (toolStripButton.Checked)
            {
                toolStripButton.Checked = false;
                isDrawing = false;
                return;
            }
            foreach (ToolStripButton item in toolStripButtons)
            {
                item.Checked = false;
            }
            toolStripButton.Checked = true;
            isDrawing = true;
        }

        private void InitCanvas()
        {

            this.Controls.Add(canvas);
            canvas.BringToFront();
            canvas.Dock = DockStyle.Fill;

            this.canvas.Paint += PanelCanvasPaint;
            this.canvas.Cursor = Cursors.Cross;
            this.canvas.MouseDown += PanelCanvasMouseDown;
            this.canvas.MouseUp += PanelCanvasMouseUp;
            this.canvas.MouseMove += PanelCanvasMouseMove;
        }

        private void PanelCanvasMouseMove(object sender, MouseEventArgs e)
        {
            model.MouseMoved(e.X, e.Y);
        }

        private void PanelCanvasMouseUp(object sender, MouseEventArgs e)
        {
            model.MouseReleases(e.X, e.Y);
        }

        private void PanelCanvasMouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;
            model.MousePressed(e.X, e.Y);
        }

        private void PanelCanvasPaint(object sender, PaintEventArgs e)
        {
            model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }


        private void btnAddShape_Click(object sender, EventArgs e)
        {
            try
            {
                model.TryCreateShape(comboBoxShapeType.Text, textBoxShapeContent.Text, textBoxShapeX.Text, textBoxShapeY.Text, textBoxShapeHeight.Text, textBoxShapeWidth.Text);
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
            List<Shape> shapes = model.GetShapes();
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                dataGridViewShapes.Rows.Add("刪除", i + 1, shape.ShapeName, shape.Content, shape.X, shape.Y, shape.Height, shape.Width);
            }
        }


        // dataGridView 內容被點擊
        private void dataGridViewShapes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 當刪除按鈕欄被點擊時
            if (e.ColumnIndex == 0)
            {
                model.RemoveShape(e.RowIndex);
            }
        }

        private void HandleModelChange()
        {
            this.canvas.Invalidate(true);
            UpdateDataGridView();
        }
    }
}
