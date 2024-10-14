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
            this.model = model;
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {
            // 從 enum 抓所有圖形元素名稱
            comboBox_shape_type.Items.AddRange(Enum.GetNames(typeof(ShapeFactory.ShapeType)));
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // 檢查資料是否都有填寫
            try
            {
                ShapeFactory.ShapeType shapeType = (ShapeFactory.ShapeType)Enum.Parse(typeof(ShapeFactory.ShapeType), comboBox_shape_type.Text);
                // 內容為空也不被認可
                if (textBox_shape_content.Text == string.Empty)
                    throw new ArgumentNullException("textBox_shape_content.Text is empty");
                int x = int.Parse(textBox_shape_x.Text);
                int y = int.Parse(textBox_shape_y.Text);
                int height = int.Parse(textBox_shape_h.Text);
                int width = int.Parse(textBox_shape_w.Text);
                model.CreateShape(shapeType, textBox_shape_content.Text, x, y, height, width);
                UpdateDataGridView();
            }
            catch
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
