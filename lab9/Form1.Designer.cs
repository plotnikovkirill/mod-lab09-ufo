﻿namespace lab9
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            X1 = new Label();
            X2 = new Label();
            Y2 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox5 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            Y1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(81, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(280, 31);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // X1
            // 
            X1.AutoSize = true;
            X1.Location = new Point(25, 37);
            X1.Name = "X1";
            X1.Size = new Size(26, 20);
            X1.TabIndex = 2;
            X1.Text = "X1";
            // 
            // X2
            // 
            X2.AutoSize = true;
            X2.Location = new Point(234, 34);
            X2.Name = "X2";
            X2.Size = new Size(26, 20);
            X2.TabIndex = 3;
            X2.Text = "X2";
            // 
            // Y2
            // 
            Y2.AutoSize = true;
            Y2.Location = new Point(235, 67);
            Y2.Name = "Y2";
            Y2.Size = new Size(25, 20);
            Y2.TabIndex = 5;
            Y2.Text = "Y2";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(81, 67);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(280, 67);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(502, 31);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Первая";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(502, 65);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "Вторая";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(653, 27);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(630, 42);
            label1.Name = "label1";
            label1.Size = new Size(20, 20);
            label1.TabIndex = 11;
            label1.Text = "N";
            // 
            // button3
            // 
            button3.Location = new Point(653, 60);
            button3.Name = "button3";
            button3.Size = new Size(125, 29);
            button3.TabIndex = 12;
            button3.Text = "Старт";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Y1
            // 
            Y1.AutoSize = true;
            Y1.Location = new Point(26, 67);
            Y1.Name = "Y1";
            Y1.Size = new Size(25, 20);
            Y1.TabIndex = 13;
            Y1.Text = "Y1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(Y1);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(Y2);
            Controls.Add(X2);
            Controls.Add(X1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label X1;
        private Label X2;
        private Label textBox1Y1;
        private Label Y2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private TextBox textBox5;
        private Label label1;
        private Button button3;
        private Label Y1;
    }
}
