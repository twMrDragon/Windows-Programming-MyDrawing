namespace MyDrawing
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_page2 = new System.Windows.Forms.Button();
            this.btn_page1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_shapes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_shape_w = new System.Windows.Forms.TextBox();
            this.textBox_shape_h = new System.Windows.Forms.TextBox();
            this.textBox_shape_y = new System.Windows.Forms.TextBox();
            this.textBox_shape_x = new System.Windows.Forms.TextBox();
            this.textBox_shape_content = new System.Windows.Forms.TextBox();
            this.label_shape_w = new System.Windows.Forms.Label();
            this.label_shape_h = new System.Windows.Forms.Label();
            this.label_shape_y = new System.Windows.Forms.Label();
            this.label_shape_x = new System.Windows.Forms.Label();
            this.comboBox_shape_type = new System.Windows.Forms.ComboBox();
            this.label_shape_content = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel_paint = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shapes)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1123, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btn_page2);
            this.panel1.Controls.Add(this.btn_page1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 562);
            this.panel1.TabIndex = 1;
            // 
            // btn_page2
            // 
            this.btn_page2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_page2.Location = new System.Drawing.Point(0, 88);
            this.btn_page2.Name = "btn_page2";
            this.btn_page2.Size = new System.Drawing.Size(113, 88);
            this.btn_page2.TabIndex = 1;
            this.btn_page2.UseVisualStyleBackColor = true;
            // 
            // btn_page1
            // 
            this.btn_page1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_page1.Location = new System.Drawing.Point(0, 0);
            this.btn_page1.Name = "btn_page1";
            this.btn_page1.Size = new System.Drawing.Size(113, 88);
            this.btn_page1.TabIndex = 0;
            this.btn_page1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_shapes);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(702, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 562);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // dataGridView_shapes
            // 
            this.dataGridView_shapes.AllowUserToAddRows = false;
            this.dataGridView_shapes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_shapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_shapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView_shapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_shapes.Location = new System.Drawing.Point(3, 69);
            this.dataGridView_shapes.Name = "dataGridView_shapes";
            this.dataGridView_shapes.ReadOnly = true;
            this.dataGridView_shapes.RowHeadersVisible = false;
            this.dataGridView_shapes.RowTemplate.Height = 24;
            this.dataGridView_shapes.Size = new System.Drawing.Size(415, 490);
            this.dataGridView_shapes.TabIndex = 1;
            this.dataGridView_shapes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_shapes_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "刪除";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "形狀";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "文字";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "X";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Y";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "H";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "W";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 51);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_shape_w, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_shape_h, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_shape_y, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_shape_x, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_shape_content, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_shape_w, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_shape_h, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_shape_y, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_shape_x, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_shape_type, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_shape_content, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(80, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 51);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBox_shape_w
            // 
            this.textBox_shape_w.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_shape_w.Location = new System.Drawing.Point(293, 28);
            this.textBox_shape_w.Name = "textBox_shape_w";
            this.textBox_shape_w.Size = new System.Drawing.Size(39, 22);
            this.textBox_shape_w.TabIndex = 10;
            // 
            // textBox_shape_h
            // 
            this.textBox_shape_h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_shape_h.Location = new System.Drawing.Point(252, 28);
            this.textBox_shape_h.Name = "textBox_shape_h";
            this.textBox_shape_h.Size = new System.Drawing.Size(35, 22);
            this.textBox_shape_h.TabIndex = 9;
            // 
            // textBox_shape_y
            // 
            this.textBox_shape_y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_shape_y.Location = new System.Drawing.Point(211, 28);
            this.textBox_shape_y.Name = "textBox_shape_y";
            this.textBox_shape_y.Size = new System.Drawing.Size(35, 22);
            this.textBox_shape_y.TabIndex = 8;
            // 
            // textBox_shape_x
            // 
            this.textBox_shape_x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_shape_x.Location = new System.Drawing.Point(170, 28);
            this.textBox_shape_x.Name = "textBox_shape_x";
            this.textBox_shape_x.Size = new System.Drawing.Size(35, 22);
            this.textBox_shape_x.TabIndex = 7;
            // 
            // textBox_shape_content
            // 
            this.textBox_shape_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_shape_content.Location = new System.Drawing.Point(70, 28);
            this.textBox_shape_content.Name = "textBox_shape_content";
            this.textBox_shape_content.Size = new System.Drawing.Size(94, 22);
            this.textBox_shape_content.TabIndex = 3;
            // 
            // label_shape_w
            // 
            this.label_shape_w.AutoSize = true;
            this.label_shape_w.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_shape_w.Location = new System.Drawing.Point(293, 0);
            this.label_shape_w.Name = "label_shape_w";
            this.label_shape_w.Size = new System.Drawing.Size(39, 25);
            this.label_shape_w.TabIndex = 6;
            this.label_shape_w.Text = "W";
            this.label_shape_w.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_shape_h
            // 
            this.label_shape_h.AutoSize = true;
            this.label_shape_h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_shape_h.Location = new System.Drawing.Point(252, 0);
            this.label_shape_h.Name = "label_shape_h";
            this.label_shape_h.Size = new System.Drawing.Size(35, 25);
            this.label_shape_h.TabIndex = 5;
            this.label_shape_h.Text = "H";
            this.label_shape_h.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_shape_y
            // 
            this.label_shape_y.AutoSize = true;
            this.label_shape_y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_shape_y.Location = new System.Drawing.Point(211, 0);
            this.label_shape_y.Name = "label_shape_y";
            this.label_shape_y.Size = new System.Drawing.Size(35, 25);
            this.label_shape_y.TabIndex = 4;
            this.label_shape_y.Text = "Y";
            this.label_shape_y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_shape_x
            // 
            this.label_shape_x.AutoSize = true;
            this.label_shape_x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_shape_x.Location = new System.Drawing.Point(170, 0);
            this.label_shape_x.Name = "label_shape_x";
            this.label_shape_x.Size = new System.Drawing.Size(35, 25);
            this.label_shape_x.TabIndex = 3;
            this.label_shape_x.Text = "X";
            this.label_shape_x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_shape_type
            // 
            this.comboBox_shape_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_shape_type.FormattingEnabled = true;
            this.comboBox_shape_type.Location = new System.Drawing.Point(3, 28);
            this.comboBox_shape_type.Name = "comboBox_shape_type";
            this.comboBox_shape_type.Size = new System.Drawing.Size(61, 20);
            this.comboBox_shape_type.TabIndex = 0;
            // 
            // label_shape_content
            // 
            this.label_shape_content.AutoSize = true;
            this.label_shape_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_shape_content.Location = new System.Drawing.Point(70, 0);
            this.label_shape_content.Name = "label_shape_content";
            this.label_shape_content.Size = new System.Drawing.Size(94, 25);
            this.label_shape_content.TabIndex = 1;
            this.label_shape_content.Text = "文字";
            this.label_shape_content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_add.Location = new System.Drawing.Point(0, 0);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(80, 51);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "新增";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel_paint
            // 
            this.panel_paint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_paint.Location = new System.Drawing.Point(113, 24);
            this.panel_paint.Name = "panel_paint";
            this.panel_paint.Size = new System.Drawing.Size(589, 562);
            this.panel_paint.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 586);
            this.Controls.Add(this.panel_paint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shapes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_page2;
        private System.Windows.Forms.Button btn_page1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_shapes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox comboBox_shape_type;
        private System.Windows.Forms.Label label_shape_content;
        private System.Windows.Forms.TextBox textBox_shape_w;
        private System.Windows.Forms.TextBox textBox_shape_h;
        private System.Windows.Forms.TextBox textBox_shape_y;
        private System.Windows.Forms.TextBox textBox_shape_x;
        private System.Windows.Forms.TextBox textBox_shape_content;
        private System.Windows.Forms.Label label_shape_w;
        private System.Windows.Forms.Label label_shape_h;
        private System.Windows.Forms.Label label_shape_y;
        private System.Windows.Forms.Label label_shape_x;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel panel_paint;
    }
}

