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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.libraryButton = new System.Windows.Forms.RadioButton();
            this.bresenhamButton = new System.Windows.Forms.RadioButton();
            this.AddVertexButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(658, 451);
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
            this.groupBox1.Controls.Add(this.AddVertexButton);
            this.groupBox1.Controls.Add(this.placeButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.moveButton);
            this.groupBox1.Location = new System.Drawing.Point(664, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 220);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.libraryButton);
            this.groupBox2.Controls.Add(this.bresenhamButton);
            this.groupBox2.Location = new System.Drawing.Point(664, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // libraryButton
            // 
            this.libraryButton.AutoSize = true;
            this.libraryButton.Location = new System.Drawing.Point(3, 53);
            this.libraryButton.Name = "libraryButton";
            this.libraryButton.Size = new System.Drawing.Size(75, 24);
            this.libraryButton.TabIndex = 1;
            this.libraryButton.Text = "Library";
            this.libraryButton.UseVisualStyleBackColor = true;
            // 
            // bresenhamButton
            // 
            this.bresenhamButton.AutoSize = true;
            this.bresenhamButton.Checked = true;
            this.bresenhamButton.Location = new System.Drawing.Point(3, 23);
            this.bresenhamButton.Name = "bresenhamButton";
            this.bresenhamButton.Size = new System.Drawing.Size(103, 24);
            this.bresenhamButton.TabIndex = 0;
            this.bresenhamButton.TabStop = true;
            this.bresenhamButton.Text = "Bresenham";
            this.bresenhamButton.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}