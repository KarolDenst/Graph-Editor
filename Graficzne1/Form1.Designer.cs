namespace Graficzne1
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.placeButton = new System.Windows.Forms.RadioButton();
            this.moveButton = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parrellarConstraintButton = new System.Windows.Forms.RadioButton();
            this.LengthConstraintButton = new System.Windows.Forms.RadioButton();
            this.AddVertexButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.libraryButton = new System.Windows.Forms.RadioButton();
            this.bresenhamButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(757, 509);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // placeButton
            // 
            this.placeButton.AutoSize = true;
            this.placeButton.Checked = true;
            this.placeButton.Location = new System.Drawing.Point(3, 26);
            this.placeButton.Name = "placeButton";
            this.placeButton.Size = new System.Drawing.Size(65, 24);
            this.placeButton.TabIndex = 1;
            this.placeButton.TabStop = true;
            this.placeButton.Text = "Place";
            this.placeButton.UseVisualStyleBackColor = true;
            this.placeButton.CheckedChanged += new System.EventHandler(this.placeButton_CheckedChanged);
            // 
            // moveButton
            // 
            this.moveButton.AutoSize = true;
            this.moveButton.Location = new System.Drawing.Point(3, 56);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(67, 24);
            this.moveButton.TabIndex = 2;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.CheckedChanged += new System.EventHandler(this.moveButton_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.Location = new System.Drawing.Point(4, 86);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(74, 24);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.CheckedChanged += new System.EventHandler(this.deleteButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parrellarConstraintButton);
            this.groupBox1.Controls.Add(this.LengthConstraintButton);
            this.groupBox1.Controls.Add(this.AddVertexButton);
            this.groupBox1.Controls.Add(this.placeButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.moveButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 248);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // parrellarConstraintButton
            // 
            this.parrellarConstraintButton.AutoSize = true;
            this.parrellarConstraintButton.Location = new System.Drawing.Point(0, 219);
            this.parrellarConstraintButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.parrellarConstraintButton.Name = "parrellarConstraintButton";
            this.parrellarConstraintButton.Size = new System.Drawing.Size(181, 24);
            this.parrellarConstraintButton.TabIndex = 6;
            this.parrellarConstraintButton.TabStop = true;
            this.parrellarConstraintButton.Text = "Add Parallel Constraint";
            this.parrellarConstraintButton.UseVisualStyleBackColor = true;
            this.parrellarConstraintButton.CheckedChanged += new System.EventHandler(this.parrellarConstraintButton_CheckedChanged);
            // 
            // LengthConstraintButton
            // 
            this.LengthConstraintButton.AutoSize = true;
            this.LengthConstraintButton.Location = new System.Drawing.Point(0, 185);
            this.LengthConstraintButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LengthConstraintButton.Name = "LengthConstraintButton";
            this.LengthConstraintButton.Size = new System.Drawing.Size(178, 24);
            this.LengthConstraintButton.TabIndex = 5;
            this.LengthConstraintButton.TabStop = true;
            this.LengthConstraintButton.Text = "Add Length Constraint";
            this.LengthConstraintButton.UseVisualStyleBackColor = true;
            this.LengthConstraintButton.CheckedChanged += new System.EventHandler(this.LengthConstraintButton_CheckedChanged);
            // 
            // AddVertexButton
            // 
            this.AddVertexButton.AutoSize = true;
            this.AddVertexButton.Location = new System.Drawing.Point(3, 116);
            this.AddVertexButton.Name = "AddVertexButton";
            this.AddVertexButton.Size = new System.Drawing.Size(103, 24);
            this.AddVertexButton.TabIndex = 4;
            this.AddVertexButton.TabStop = true;
            this.AddVertexButton.Text = "Add Vertex";
            this.AddVertexButton.UseVisualStyleBackColor = true;
            this.AddVertexButton.CheckedChanged += new System.EventHandler(this.AddVertexButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.libraryButton);
            this.groupBox2.Controls.Add(this.bresenhamButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 249);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drawing Mode";
            // 
            // libraryButton
            // 
            this.libraryButton.AutoSize = true;
            this.libraryButton.Checked = true;
            this.libraryButton.Location = new System.Drawing.Point(3, 26);
            this.libraryButton.Name = "libraryButton";
            this.libraryButton.Size = new System.Drawing.Size(75, 24);
            this.libraryButton.TabIndex = 1;
            this.libraryButton.TabStop = true;
            this.libraryButton.Text = "Library";
            this.libraryButton.UseVisualStyleBackColor = true;
            this.libraryButton.CheckedChanged += new System.EventHandler(this.libraryButton_CheckedChanged);
            // 
            // bresenhamButton
            // 
            this.bresenhamButton.AutoSize = true;
            this.bresenhamButton.Location = new System.Drawing.Point(3, 56);
            this.bresenhamButton.Name = "bresenhamButton";
            this.bresenhamButton.Size = new System.Drawing.Size(103, 24);
            this.bresenhamButton.TabIndex = 0;
            this.bresenhamButton.Text = "Bresenham";
            this.bresenhamButton.UseVisualStyleBackColor = true;
            this.bresenhamButton.CheckedChanged += new System.EventHandler(this.bresenhamButton_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.4F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.6F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(905, 515);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(766, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(136, 509);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox;
        private RadioButton placeButton;
        private RadioButton moveButton;
        private RadioButton deleteButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton bresenhamButton;
        private RadioButton libraryButton;
        private RadioButton AddVertexButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioButton parrellarConstraintButton;
        private RadioButton LengthConstraintButton;
    }
}