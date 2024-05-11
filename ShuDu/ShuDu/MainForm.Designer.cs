
namespace ShuDu
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            SuduCacalate = new Button();
            SudukuNumbers = new Button();
            CurDirectionLabel = new Label();
            pictureBoxRight = new PictureBox();
            pictureBoxLeft = new PictureBox();
            pictureBoxTop = new PictureBox();
            pictureBoxBottom = new PictureBox();
            pictureBoxRightTop = new PictureBox();
            pictureBoxLeftBottom = new PictureBox();
            pictureBoxRightBottom = new PictureBox();
            pictureBoxLeftTop = new PictureBox();
            BottomNumbers = new Button();
            Column9 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridView = new DataGridView();
            CurStatusLabel = new Label();
            BottomBtnsReadyLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeftBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeftTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // SuduCacalate
            // 
            SuduCacalate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            SuduCacalate.Location = new Point(348, 554);
            SuduCacalate.Name = "SuduCacalate";
            SuduCacalate.Size = new Size(132, 70);
            SuduCacalate.TabIndex = 15;
            SuduCacalate.Text = "Sudu Cacalate";
            SuduCacalate.UseVisualStyleBackColor = true;
            SuduCacalate.Click += SuduCaculate_Click;
            // 
            // SudukuNumbers
            // 
            SudukuNumbers.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            SudukuNumbers.Location = new Point(178, 550);
            SudukuNumbers.Name = "SudukuNumbers";
            SudukuNumbers.Size = new Size(140, 74);
            SudukuNumbers.TabIndex = 14;
            SudukuNumbers.Text = "Suduku Numbers";
            SudukuNumbers.UseVisualStyleBackColor = true;
            SudukuNumbers.Click += SudukuNumbers_Click;
            // 
            // CurDirectionLabel
            // 
            CurDirectionLabel.AutoSize = true;
            CurDirectionLabel.BackColor = SystemColors.ControlDark;
            CurDirectionLabel.BorderStyle = BorderStyle.FixedSingle;
            CurDirectionLabel.Location = new Point(178, 507);
            CurDirectionLabel.Name = "CurDirectionLabel";
            CurDirectionLabel.Size = new Size(130, 22);
            CurDirectionLabel.TabIndex = 13;
            CurDirectionLabel.Text = "CurDirectionLabel";
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.BackColor = Color.Transparent;
            pictureBoxRight.BackgroundImageLayout = ImageLayout.None;
            pictureBoxRight.Cursor = Cursors.SizeWE;
            pictureBoxRight.Location = new Point(834, 175);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(32, 224);
            pictureBoxRight.TabIndex = 11;
            pictureBoxRight.TabStop = false;
            pictureBoxRight.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxRight.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxRight.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.BackColor = Color.Transparent;
            pictureBoxLeft.BackgroundImageLayout = ImageLayout.None;
            pictureBoxLeft.Cursor = Cursors.SizeWE;
            pictureBoxLeft.Location = new Point(551, 175);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(32, 224);
            pictureBoxLeft.TabIndex = 10;
            pictureBoxLeft.TabStop = false;
            pictureBoxLeft.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxLeft.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxLeft.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxTop
            // 
            pictureBoxTop.BackColor = Color.Transparent;
            pictureBoxTop.BackgroundImageLayout = ImageLayout.None;
            pictureBoxTop.Cursor = Cursors.SizeNS;
            pictureBoxTop.ErrorImage = null;
            pictureBoxTop.InitialImage = null;
            pictureBoxTop.Location = new Point(589, 137);
            pictureBoxTop.Name = "pictureBoxTop";
            pictureBoxTop.Size = new Size(239, 32);
            pictureBoxTop.TabIndex = 9;
            pictureBoxTop.TabStop = false;
            pictureBoxTop.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxTop.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxTop.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxBottom
            // 
            pictureBoxBottom.BackColor = Color.Transparent;
            pictureBoxBottom.BackgroundImageLayout = ImageLayout.None;
            pictureBoxBottom.Cursor = Cursors.SizeNS;
            pictureBoxBottom.Location = new Point(589, 405);
            pictureBoxBottom.Name = "pictureBoxBottom";
            pictureBoxBottom.Size = new Size(239, 32);
            pictureBoxBottom.TabIndex = 8;
            pictureBoxBottom.TabStop = false;
            pictureBoxBottom.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxBottom.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxBottom.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxRightTop
            // 
            pictureBoxRightTop.BackColor = Color.Transparent;
            pictureBoxRightTop.BackgroundImageLayout = ImageLayout.None;
            pictureBoxRightTop.Cursor = Cursors.SizeNESW;
            pictureBoxRightTop.Location = new Point(834, 137);
            pictureBoxRightTop.Name = "pictureBoxRightTop";
            pictureBoxRightTop.Size = new Size(32, 32);
            pictureBoxRightTop.TabIndex = 7;
            pictureBoxRightTop.TabStop = false;
            pictureBoxRightTop.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxRightTop.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxRightTop.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxLeftBottom
            // 
            pictureBoxLeftBottom.BackColor = Color.Transparent;
            pictureBoxLeftBottom.BackgroundImageLayout = ImageLayout.None;
            pictureBoxLeftBottom.Cursor = Cursors.SizeNESW;
            pictureBoxLeftBottom.Location = new Point(551, 405);
            pictureBoxLeftBottom.Name = "pictureBoxLeftBottom";
            pictureBoxLeftBottom.Size = new Size(32, 32);
            pictureBoxLeftBottom.TabIndex = 6;
            pictureBoxLeftBottom.TabStop = false;
            pictureBoxLeftBottom.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxLeftBottom.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxLeftBottom.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxRightBottom
            // 
            pictureBoxRightBottom.BackColor = Color.Transparent;
            pictureBoxRightBottom.BackgroundImageLayout = ImageLayout.None;
            pictureBoxRightBottom.Cursor = Cursors.SizeNWSE;
            pictureBoxRightBottom.Location = new Point(834, 405);
            pictureBoxRightBottom.Name = "pictureBoxRightBottom";
            pictureBoxRightBottom.Size = new Size(32, 32);
            pictureBoxRightBottom.TabIndex = 5;
            pictureBoxRightBottom.TabStop = false;
            pictureBoxRightBottom.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxRightBottom.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxRightBottom.MouseUp += pictureBoxScale_MouseUp;
            // 
            // pictureBoxLeftTop
            // 
            pictureBoxLeftTop.BackColor = Color.Transparent;
            pictureBoxLeftTop.BackgroundImageLayout = ImageLayout.None;
            pictureBoxLeftTop.Cursor = Cursors.SizeNWSE;
            pictureBoxLeftTop.Location = new Point(551, 137);
            pictureBoxLeftTop.Name = "pictureBoxLeftTop";
            pictureBoxLeftTop.Size = new Size(32, 32);
            pictureBoxLeftTop.TabIndex = 4;
            pictureBoxLeftTop.TabStop = false;
            pictureBoxLeftTop.MouseDown += pictureBoxScale_MouseDown;
            pictureBoxLeftTop.MouseMove += pictureBoxScale_MouseMove;
            pictureBoxLeftTop.MouseUp += pictureBoxScale_MouseUp;
            // 
            // BottomNumbers
            // 
            BottomNumbers.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            BottomNumbers.Location = new Point(12, 550);
            BottomNumbers.Name = "BottomNumbers";
            BottomNumbers.Size = new Size(144, 74);
            BottomNumbers.TabIndex = 1;
            BottomNumbers.Text = "Bottom\r\nNumbers";
            BottomNumbers.UseVisualStyleBackColor = true;
            BottomNumbers.Click += BottomNumbers_Click;
            // 
            // Column9
            // 
            Column9.HeaderText = "Column9";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 125;
            // 
            // Column8
            // 
            Column8.HeaderText = "Column8";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 125;
            // 
            // Column7
            // 
            Column7.HeaderText = "Column7";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "Column6";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.CausesValidation = false;
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 });
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView.Location = new Point(12, 12);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 10;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridView.RowTemplate.Height = 29;
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowCellToolTips = false;
            dataGridView.ShowEditingIcon = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(468, 468);
            dataGridView.TabIndex = 0;
            dataGridView.TabStop = false;
            // 
            // CurStatusLabel
            // 
            CurStatusLabel.AutoSize = true;
            CurStatusLabel.BackColor = SystemColors.ControlDark;
            CurStatusLabel.BorderStyle = BorderStyle.FixedSingle;
            CurStatusLabel.Location = new Point(348, 507);
            CurStatusLabel.Name = "CurStatusLabel";
            CurStatusLabel.Size = new Size(109, 22);
            CurStatusLabel.TabIndex = 16;
            CurStatusLabel.Text = "CurStatusLabel";
            // 
            // BottomBtnsReadyLabel
            // 
            BottomBtnsReadyLabel.AutoSize = true;
            BottomBtnsReadyLabel.BackColor = SystemColors.ControlDark;
            BottomBtnsReadyLabel.BorderStyle = BorderStyle.FixedSingle;
            BottomBtnsReadyLabel.Location = new Point(12, 507);
            BottomBtnsReadyLabel.Name = "BottomBtnsReadyLabel";
            BottomBtnsReadyLabel.Size = new Size(130, 22);
            BottomBtnsReadyLabel.TabIndex = 17;
            BottomBtnsReadyLabel.Text = "BottomBtnsReady";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 649);
            Controls.Add(BottomBtnsReadyLabel);
            Controls.Add(CurStatusLabel);
            Controls.Add(SuduCacalate);
            Controls.Add(SudukuNumbers);
            Controls.Add(CurDirectionLabel);
            Controls.Add(pictureBoxRight);
            Controls.Add(pictureBoxLeft);
            Controls.Add(pictureBoxTop);
            Controls.Add(pictureBoxBottom);
            Controls.Add(pictureBoxRightTop);
            Controls.Add(pictureBoxLeftBottom);
            Controls.Add(pictureBoxRightBottom);
            Controls.Add(pictureBoxLeftTop);
            Controls.Add(BottomNumbers);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            Paint += MainForm_Paint;
            MouseClick += MainForm_MouseClick;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeftBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeftTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SuduCacalate;
        private Button SudukuNumbers;
        private Label CurDirectionLabel;
        private PictureBox pictureBoxRight;
        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxTop;
        private PictureBox pictureBoxBottom;
        private PictureBox pictureBoxRightTop;
        private PictureBox pictureBoxLeftBottom;
        private PictureBox pictureBoxRightBottom;
        private PictureBox pictureBoxLeftTop;
        private Button BottomNumbers;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dataGridView;
        private Label CurStatusLabel;
        private Label BottomBtnsReadyLabel;
    }
}
