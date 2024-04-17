namespace Blokus
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            Auto = new Button();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 620);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(10, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 600);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Auto
            // 
            Auto.Location = new Point(661, 24);
            Auto.Name = "Auto";
            Auto.Size = new Size(99, 30);
            Auto.TabIndex = 1;
            Auto.Text = "Auto";
            Auto.UseVisualStyleBackColor = true;
            Auto.Click += button_auto;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(657, 84);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(657, 99);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(657, 114);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(657, 129);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 5;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(657, 160);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 6;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(766, 32);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 7;
            label6.Text = "label6";
            // 
            // button1
            // 
            button1.Location = new Point(821, 24);
            button1.Name = "button1";
            button1.Size = new Size(99, 30);
            button1.TabIndex = 8;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_next;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(766, 84);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 9;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(766, 99);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 10;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(766, 114);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 11;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(766, 129);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 12;
            label10.Text = "label10";
            // 
            // button2
            // 
            button2.Location = new Point(983, 24);
            button2.Name = "button2";
            button2.Size = new Size(99, 30);
            button2.TabIndex = 13;
            button2.Text = "RESET";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_reset;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 674);
            Controls.Add(button2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Auto);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button Auto;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button2;
    }
}