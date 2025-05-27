namespace TextureTool
{
    partial class ChannelMergeTool
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
            Merge_RGB_button1 = new Button();
            RGB_picture = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            R_picture = new PictureBox();
            label3 = new Label();
            G_picture = new PictureBox();
            label4 = new Label();
            B_picture = new PictureBox();
            label5 = new Label();
            Alpha_picture = new PictureBox();
            button2 = new Button();
            comboAlphaChannel = new ComboBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)RGB_picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)R_picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)G_picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)B_picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Alpha_picture).BeginInit();
            SuspendLayout();
            // 
            // Merge_RGB_button1
            // 
            Merge_RGB_button1.Location = new Point(46, 45);
            Merge_RGB_button1.Name = "Merge_RGB_button1";
            Merge_RGB_button1.Size = new Size(100, 23);
            Merge_RGB_button1.TabIndex = 0;
            Merge_RGB_button1.Text = "RGB+A";
            Merge_RGB_button1.UseVisualStyleBackColor = true;
            Merge_RGB_button1.Click += button1_Click;
            // 
            // RGB_picture
            // 
            RGB_picture.BackColor = SystemColors.ActiveBorder;
            RGB_picture.Cursor = Cursors.Hand;
            RGB_picture.Location = new Point(196, 12);
            RGB_picture.Name = "RGB_picture";
            RGB_picture.Size = new Size(100, 100);
            RGB_picture.SizeMode = PictureBoxSizeMode.Zoom;
            RGB_picture.TabIndex = 1;
            RGB_picture.TabStop = false;
            RGB_picture.Click += pictureBox1_Click;
            RGB_picture.DragDrop += RGB_picture_DragDrop;
            RGB_picture.DragEnter += RGB_picture_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 115);
            label1.Name = "label1";
            label1.Size = new Size(33, 17);
            label1.TabIndex = 2;
            label1.Text = "RGB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 277);
            label2.Name = "label2";
            label2.Size = new Size(16, 17);
            label2.TabIndex = 4;
            label2.Text = "R";
            // 
            // R_picture
            // 
            R_picture.BackColor = SystemColors.ActiveBorder;
            R_picture.Cursor = Cursors.Hand;
            R_picture.Location = new Point(196, 174);
            R_picture.Name = "R_picture";
            R_picture.Size = new Size(100, 100);
            R_picture.SizeMode = PictureBoxSizeMode.Zoom;
            R_picture.TabIndex = 3;
            R_picture.TabStop = false;
            R_picture.Click += R_picture_Click;
            R_picture.DragDrop += R_picture_DragDrop;
            R_picture.DragEnter += RGB_picture_DragEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 277);
            label3.Name = "label3";
            label3.Size = new Size(17, 17);
            label3.TabIndex = 6;
            label3.Text = "G";
            // 
            // G_picture
            // 
            G_picture.BackColor = SystemColors.ActiveBorder;
            G_picture.Cursor = Cursors.Hand;
            G_picture.Location = new Point(302, 174);
            G_picture.Name = "G_picture";
            G_picture.Size = new Size(100, 100);
            G_picture.SizeMode = PictureBoxSizeMode.Zoom;
            G_picture.TabIndex = 5;
            G_picture.TabStop = false;
            G_picture.Click += G_picture_Click;
            G_picture.DragDrop += G_picture_DragDrop;
            G_picture.DragEnter += RGB_picture_DragEnter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(450, 277);
            label4.Name = "label4";
            label4.Size = new Size(16, 17);
            label4.TabIndex = 8;
            label4.Text = "B";
            // 
            // B_picture
            // 
            B_picture.BackColor = SystemColors.ActiveBorder;
            B_picture.Cursor = Cursors.Hand;
            B_picture.Location = new Point(408, 174);
            B_picture.Name = "B_picture";
            B_picture.Size = new Size(100, 100);
            B_picture.SizeMode = PictureBoxSizeMode.Zoom;
            B_picture.TabIndex = 7;
            B_picture.TabStop = false;
            B_picture.Click += B_picture_Click;
            B_picture.DragDrop += B_picture_DragDrop;
            B_picture.DragEnter += RGB_picture_DragEnter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(356, 51);
            label5.Name = "label5";
            label5.Size = new Size(41, 17);
            label5.TabIndex = 10;
            label5.Text = "Alpha";
            // 
            // Alpha_picture
            // 
            Alpha_picture.BackColor = SystemColors.ActiveBorder;
            Alpha_picture.Cursor = Cursors.Hand;
            Alpha_picture.Location = new Point(408, 12);
            Alpha_picture.Name = "Alpha_picture";
            Alpha_picture.Size = new Size(100, 100);
            Alpha_picture.SizeMode = PictureBoxSizeMode.Zoom;
            Alpha_picture.TabIndex = 9;
            Alpha_picture.TabStop = false;
            Alpha_picture.Click += Alpha_picture_Click;
            Alpha_picture.DragDrop += Alpha_picture_DragDrop;
            Alpha_picture.DragEnter += RGB_picture_DragEnter;
            // 
            // button2
            // 
            button2.Location = new Point(46, 210);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 11;
            button2.Text = "R+G+B+A";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click_1;
            // 
            // comboAlphaChannel
            // 
            comboAlphaChannel.FormattingEnabled = true;
            comboAlphaChannel.Items.AddRange(new object[] { "R", "G", "B", "A" });
            comboAlphaChannel.Location = new Point(344, 76);
            comboAlphaChannel.Name = "comboAlphaChannel";
            comboAlphaChannel.Size = new Size(53, 25);
            comboAlphaChannel.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "R", "G", "B", "A" });
            comboBox1.Location = new Point(218, 297);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(53, 25);
            comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "R", "G", "B", "A" });
            comboBox2.Location = new Point(324, 297);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(53, 25);
            comboBox2.TabIndex = 14;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "R", "G", "B", "A" });
            comboBox3.Location = new Point(430, 297);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(53, 25);
            comboBox3.TabIndex = 15;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(24, 76);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(138, 23);
            progressBar1.Step = 1;
            progressBar1.TabIndex = 16;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(24, 239);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(138, 23);
            progressBar2.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(311, 51);
            label6.Name = "label6";
            label6.Size = new Size(17, 17);
            label6.TabIndex = 18;
            label6.Text = "+";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(449, 133);
            label7.Name = "label7";
            label7.Size = new Size(17, 17);
            label7.TabIndex = 19;
            label7.Text = "+";
            // 
            // ChannelMergeTool
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 354);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(comboAlphaChannel);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(Alpha_picture);
            Controls.Add(label4);
            Controls.Add(B_picture);
            Controls.Add(label3);
            Controls.Add(G_picture);
            Controls.Add(label2);
            Controls.Add(R_picture);
            Controls.Add(label1);
            Controls.Add(RGB_picture);
            Controls.Add(Merge_RGB_button1);
            Name = "ChannelMergeTool";
            Text = "ChannelMergeTool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)RGB_picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)R_picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)G_picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)B_picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)Alpha_picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Merge_RGB_button1;
        private PictureBox RGB_picture;
        private Label label1;
        private Label label2;
        private PictureBox R_picture;
        private Label label3;
        private PictureBox G_picture;
        private Label label4;
        private PictureBox B_picture;
        private Label label5;
        private PictureBox Alpha_picture;
        private Button button2;
        private ComboBox comboAlphaChannel;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label6;
        private Label label7;
    }
}
