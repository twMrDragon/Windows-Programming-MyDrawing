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
        public Form1(Model model)
        {
            InitializeComponent();
            this.model = model;
            InitComboBox();
        }

        private void InitComboBox()
        {
            // 所有圖形元素名稱
            comboBoxShapeType.Items.AddRange(model.GetShapeTypesName());
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            bool isSuccessfullyCreate = model.TryCreateShape(comboBoxShapeType.Text, textBoxShapeContent.Text, textBoxShapeX.Text, textBoxShapeY.Text, textBoxShapeHeight.Text, textBoxShapeWidth.Text);
            if (isSuccessfullyCreate)
            {
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("欄位未輸入或有錯誤");
            }
        }

        // 重    新刷新 dataGridView
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
            UpdateDataGridView();
        }
    }
}
