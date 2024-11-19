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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.groupBoxDataDisplay = new System.Windows.Forms.GroupBox();
            this.dataGridViewShapes = new System.Windows.Forms.DataGridView();
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
            this.textBoxShapeWidth = new System.Windows.Forms.TextBox();
            this.textBoxShapeHeight = new System.Windows.Forms.TextBox();
            this.textBoxShapeY = new System.Windows.Forms.TextBox();
            this.textBoxShapeX = new System.Windows.Forms.TextBox();
            this.textBoxShapeContent = new System.Windows.Forms.TextBox();
            this.labelShapeWidth = new System.Windows.Forms.Label();
            this.labelShapeHeight = new System.Windows.Forms.Label();
            this.labelShapeY = new System.Windows.Forms.Label();
            this.labelShapeX = new System.Windows.Forms.Label();
            this.comboBoxShapeType = new System.Windows.Forms.ComboBox();
            this.labelShapeContent = new System.Windows.Forms.Label();
            this.btnAddShape = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTerminator = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProcess = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecision = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxDataDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1316, 24);
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
            this.panel1.Controls.Add(this.btnPage2);
            this.panel1.Controls.Add(this.btnPage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 599);
            this.panel1.TabIndex = 2;
            // 
            // btnPage2
            // 
            this.btnPage2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPage2.Location = new System.Drawing.Point(0, 88);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(113, 88);
            this.btnPage2.TabIndex = 1;
            this.btnPage2.UseVisualStyleBackColor = true;
            // 
            // btnPage1
            // 
            this.btnPage1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPage1.Location = new System.Drawing.Point(0, 0);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(113, 88);
            this.btnPage1.TabIndex = 0;
            this.btnPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxDataDisplay
            // 
            this.groupBoxDataDisplay.Controls.Add(this.dataGridViewShapes);
            this.groupBoxDataDisplay.Controls.Add(this.panel2);
            this.groupBoxDataDisplay.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxDataDisplay.Location = new System.Drawing.Point(895, 49);
            this.groupBoxDataDisplay.Name = "groupBoxDataDisplay";
            this.groupBoxDataDisplay.Size = new System.Drawing.Size(421, 599);
            this.groupBoxDataDisplay.TabIndex = 2;
            this.groupBoxDataDisplay.TabStop = false;
            this.groupBoxDataDisplay.Text = "資料顯示";
            // 
            // dataGridViewShapes
            // 
            this.dataGridViewShapes.AllowUserToAddRows = false;
            this.dataGridViewShapes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridViewShapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShapes.Location = new System.Drawing.Point(3, 69);
            this.dataGridViewShapes.Name = "dataGridViewShapes";
            this.dataGridViewShapes.ReadOnly = true;
            this.dataGridViewShapes.RowHeadersVisible = false;
            this.dataGridViewShapes.RowTemplate.Height = 24;
            this.dataGridViewShapes.Size = new System.Drawing.Size(415, 527);
            this.dataGridViewShapes.TabIndex = 1;
            this.dataGridViewShapes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewShapesCellContentClick);
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
            this.panel2.Controls.Add(this.btnAddShape);
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
            this.tableLayoutPanel1.Controls.Add(this.textBoxShapeWidth, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxShapeHeight, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxShapeY, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxShapeX, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxShapeContent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelShapeWidth, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShapeHeight, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShapeY, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShapeX, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxShapeType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelShapeContent, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(80, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 51);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBoxShapeWidth
            // 
            this.textBoxShapeWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxShapeWidth.Location = new System.Drawing.Point(293, 28);
            this.textBoxShapeWidth.Name = "textBoxShapeWidth";
            this.textBoxShapeWidth.Size = new System.Drawing.Size(39, 22);
            this.textBoxShapeWidth.TabIndex = 10;
            // 
            // textBoxShapeHeight
            // 
            this.textBoxShapeHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxShapeHeight.Location = new System.Drawing.Point(252, 28);
            this.textBoxShapeHeight.Name = "textBoxShapeHeight";
            this.textBoxShapeHeight.Size = new System.Drawing.Size(35, 22);
            this.textBoxShapeHeight.TabIndex = 9;
            // 
            // textBoxShapeY
            // 
            this.textBoxShapeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxShapeY.Location = new System.Drawing.Point(211, 28);
            this.textBoxShapeY.Name = "textBoxShapeY";
            this.textBoxShapeY.Size = new System.Drawing.Size(35, 22);
            this.textBoxShapeY.TabIndex = 8;
            // 
            // textBoxShapeX
            // 
            this.textBoxShapeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxShapeX.Location = new System.Drawing.Point(170, 28);
            this.textBoxShapeX.Name = "textBoxShapeX";
            this.textBoxShapeX.Size = new System.Drawing.Size(35, 22);
            this.textBoxShapeX.TabIndex = 7;
            // 
            // textBoxShapeContent
            // 
            this.textBoxShapeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxShapeContent.Location = new System.Drawing.Point(70, 28);
            this.textBoxShapeContent.Name = "textBoxShapeContent";
            this.textBoxShapeContent.Size = new System.Drawing.Size(94, 22);
            this.textBoxShapeContent.TabIndex = 3;
            // 
            // labelShapeWidth
            // 
            this.labelShapeWidth.AutoSize = true;
            this.labelShapeWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShapeWidth.Location = new System.Drawing.Point(293, 0);
            this.labelShapeWidth.Name = "labelShapeWidth";
            this.labelShapeWidth.Size = new System.Drawing.Size(39, 25);
            this.labelShapeWidth.TabIndex = 6;
            this.labelShapeWidth.Text = "W";
            this.labelShapeWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShapeHeight
            // 
            this.labelShapeHeight.AutoSize = true;
            this.labelShapeHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShapeHeight.Location = new System.Drawing.Point(252, 0);
            this.labelShapeHeight.Name = "labelShapeHeight";
            this.labelShapeHeight.Size = new System.Drawing.Size(35, 25);
            this.labelShapeHeight.TabIndex = 5;
            this.labelShapeHeight.Text = "H";
            this.labelShapeHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShapeY
            // 
            this.labelShapeY.AutoSize = true;
            this.labelShapeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShapeY.Location = new System.Drawing.Point(211, 0);
            this.labelShapeY.Name = "labelShapeY";
            this.labelShapeY.Size = new System.Drawing.Size(35, 25);
            this.labelShapeY.TabIndex = 4;
            this.labelShapeY.Text = "Y";
            this.labelShapeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShapeX
            // 
            this.labelShapeX.AutoSize = true;
            this.labelShapeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShapeX.Location = new System.Drawing.Point(170, 0);
            this.labelShapeX.Name = "labelShapeX";
            this.labelShapeX.Size = new System.Drawing.Size(35, 25);
            this.labelShapeX.TabIndex = 3;
            this.labelShapeX.Text = "X";
            this.labelShapeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxShapeType
            // 
            this.comboBoxShapeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxShapeType.FormattingEnabled = true;
            this.comboBoxShapeType.Location = new System.Drawing.Point(3, 28);
            this.comboBoxShapeType.Name = "comboBoxShapeType";
            this.comboBoxShapeType.Size = new System.Drawing.Size(61, 20);
            this.comboBoxShapeType.TabIndex = 0;
            // 
            // labelShapeContent
            // 
            this.labelShapeContent.AutoSize = true;
            this.labelShapeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShapeContent.Location = new System.Drawing.Point(70, 0);
            this.labelShapeContent.Name = "labelShapeContent";
            this.labelShapeContent.Size = new System.Drawing.Size(94, 25);
            this.labelShapeContent.TabIndex = 1;
            this.labelShapeContent.Text = "文字";
            this.labelShapeContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddShape
            // 
            this.btnAddShape.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddShape.Location = new System.Drawing.Point(0, 0);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(80, 51);
            this.btnAddShape.TabIndex = 0;
            this.btnAddShape.Text = "新增";
            this.btnAddShape.UseVisualStyleBackColor = true;
            this.btnAddShape.Click += new System.EventHandler(this.BtnAddShapeClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonTerminator,
            this.toolStripButtonProcess,
            this.toolStripButtonDecision});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1316, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStart.Text = "toolStripButton1";
            this.toolStripButtonStart.ToolTipText = "Start";
            // 
            // toolStripButtonTerminator
            // 
            this.toolStripButtonTerminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTerminator.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTerminator.Image")));
            this.toolStripButtonTerminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTerminator.Name = "toolStripButtonTerminator";
            this.toolStripButtonTerminator.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTerminator.Text = "toolStripButton2";
            this.toolStripButtonTerminator.ToolTipText = "Terminator";
            // 
            // toolStripButtonProcess
            // 
            this.toolStripButtonProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProcess.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonProcess.Image")));
            this.toolStripButtonProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProcess.Name = "toolStripButtonProcess";
            this.toolStripButtonProcess.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonProcess.Text = "toolStripButton3";
            this.toolStripButtonProcess.ToolTipText = "Process";
            // 
            // toolStripButtonDecision
            // 
            this.toolStripButtonDecision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecision.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecision.Image")));
            this.toolStripButtonDecision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecision.Name = "toolStripButtonDecision";
            this.toolStripButtonDecision.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDecision.Text = "toolStripButton4";
            this.toolStripButtonDecision.ToolTipText = "Decision";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 648);
            this.Controls.Add(this.groupBoxDataDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxDataDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.GroupBox groupBoxDataDisplay;
        private System.Windows.Forms.DataGridView dataGridViewShapes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.ComboBox comboBoxShapeType;
        private System.Windows.Forms.Label labelShapeContent;
        private System.Windows.Forms.TextBox textBoxShapeWidth;
        private System.Windows.Forms.TextBox textBoxShapeHeight;
        private System.Windows.Forms.TextBox textBoxShapeY;
        private System.Windows.Forms.TextBox textBoxShapeX;
        private System.Windows.Forms.TextBox textBoxShapeContent;
        private System.Windows.Forms.Label labelShapeWidth;
        private System.Windows.Forms.Label labelShapeHeight;
        private System.Windows.Forms.Label labelShapeY;
        private System.Windows.Forms.Label labelShapeX;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonTerminator;
        private System.Windows.Forms.ToolStripButton toolStripButtonProcess;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecision;
    }
}

