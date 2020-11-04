namespace QuickPrint
{
    partial class QuickPrintUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quickViewButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorBox = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.arcLengthButton = new System.Windows.Forms.Button();
            this.diameterButton = new System.Windows.Forms.Button();
            this.angularButton = new System.Windows.Forms.Button();
            this.alignedButton = new System.Windows.Forms.Button();
            this.radiusButton = new System.Windows.Forms.Button();
            this.linearButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.printButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quickViewButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QuickView";
            // 
            // quickViewButton
            // 
            this.quickViewButton.Location = new System.Drawing.Point(6, 19);
            this.quickViewButton.Name = "quickViewButton";
            this.quickViewButton.Size = new System.Drawing.Size(165, 39);
            this.quickViewButton.TabIndex = 0;
            this.quickViewButton.Text = "Activate";
            this.quickViewButton.UseVisualStyleBackColor = true;
            this.quickViewButton.Click += new System.EventHandler(this.quickViewButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorBox);
            this.groupBox2.Controls.Add(this.colorButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(6, 19);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(165, 20);
            this.colorBox.TabIndex = 2;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            this.colorBox.Enter += new System.EventHandler(this.colorBox_Enter);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(6, 46);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(165, 31);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "Set Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.arcLengthButton);
            this.groupBox3.Controls.Add(this.diameterButton);
            this.groupBox3.Controls.Add(this.angularButton);
            this.groupBox3.Controls.Add(this.alignedButton);
            this.groupBox3.Controls.Add(this.radiusButton);
            this.groupBox3.Controls.Add(this.linearButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 106);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dimension Tools";
            // 
            // arcLengthButton
            // 
            this.arcLengthButton.Location = new System.Drawing.Point(93, 77);
            this.arcLengthButton.Name = "arcLengthButton";
            this.arcLengthButton.Size = new System.Drawing.Size(78, 23);
            this.arcLengthButton.TabIndex = 5;
            this.arcLengthButton.Text = "Arc Length";
            this.arcLengthButton.UseVisualStyleBackColor = true;
            this.arcLengthButton.Click += new System.EventHandler(this.arcLengthButton_Click);
            // 
            // diameterButton
            // 
            this.diameterButton.Location = new System.Drawing.Point(93, 48);
            this.diameterButton.Name = "diameterButton";
            this.diameterButton.Size = new System.Drawing.Size(78, 23);
            this.diameterButton.TabIndex = 4;
            this.diameterButton.Text = "Diameter";
            this.diameterButton.UseVisualStyleBackColor = true;
            this.diameterButton.Click += new System.EventHandler(this.diameterButton_Click);
            // 
            // angularButton
            // 
            this.angularButton.Location = new System.Drawing.Point(6, 77);
            this.angularButton.Name = "angularButton";
            this.angularButton.Size = new System.Drawing.Size(78, 23);
            this.angularButton.TabIndex = 3;
            this.angularButton.Text = "Angular";
            this.angularButton.UseVisualStyleBackColor = true;
            this.angularButton.Click += new System.EventHandler(this.angularButton_Click);
            // 
            // alignedButton
            // 
            this.alignedButton.Location = new System.Drawing.Point(6, 48);
            this.alignedButton.Name = "alignedButton";
            this.alignedButton.Size = new System.Drawing.Size(78, 23);
            this.alignedButton.TabIndex = 2;
            this.alignedButton.Text = "Aligned";
            this.alignedButton.UseVisualStyleBackColor = true;
            this.alignedButton.Click += new System.EventHandler(this.alignedButton_Click);
            // 
            // radiusButton
            // 
            this.radiusButton.Location = new System.Drawing.Point(93, 19);
            this.radiusButton.Name = "radiusButton";
            this.radiusButton.Size = new System.Drawing.Size(78, 23);
            this.radiusButton.TabIndex = 1;
            this.radiusButton.Text = "Radius";
            this.radiusButton.UseVisualStyleBackColor = true;
            this.radiusButton.Click += new System.EventHandler(this.radiusButton_Click);
            // 
            // linearButton
            // 
            this.linearButton.Location = new System.Drawing.Point(6, 19);
            this.linearButton.Name = "linearButton";
            this.linearButton.Size = new System.Drawing.Size(78, 23);
            this.linearButton.TabIndex = 0;
            this.linearButton.Text = "Linear";
            this.linearButton.UseVisualStyleBackColor = true;
            this.linearButton.Click += new System.EventHandler(this.linearButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.printButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 72);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quick Print";
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(6, 19);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(165, 39);
            this.printButton.TabIndex = 1;
            this.printButton.Text = "Print to PDF";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // QuickPrintUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 370);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "QuickPrintUI";
            this.Text = "Quick Print";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickPrintUI_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button quickViewButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.TextBox colorBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button arcLengthButton;
        private System.Windows.Forms.Button diameterButton;
        private System.Windows.Forms.Button angularButton;
        private System.Windows.Forms.Button alignedButton;
        private System.Windows.Forms.Button radiusButton;
        private System.Windows.Forms.Button linearButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button printButton;
    }
}