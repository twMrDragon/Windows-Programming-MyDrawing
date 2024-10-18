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
            comboBox_shape_type.Items.AddRange(model.GetShapeTypesName());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool isSuccessfullyCreate =  model.TryCreateShape(comboBox_shape_type.Text, textBox_shape_content.Text, textBox_shape_x.Text, textBox_shape_y.Text, textBox_shape_h.Text, textBox_shape_w.Text);
            if (isSuccessfullyCreate)
            {
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("欄位未輸入或有錯誤");
            }
        }

        // 重新刷新 dataGridView
        private void UpdateDataGridView()
        {
            dataGridView_shapes.Rows.Clear();
            List<Shape> shapes = model.GetShapes();
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                dataGridView_shapes.Rows.Add("刪除", i + 1, shape.ShapeName, shape.Content, shape.X, shape.Y, shape.Height, shape.Width);
            }
        }

        // dataGridView 內容被點擊
        private void dataGridView_shapes_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
