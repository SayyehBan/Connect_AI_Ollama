namespace Connect_AI_Ollama
{
    partial class FrmGemma3
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
            panel1 = new Panel();
            Txttarget = new TextBox();
            TxtSource = new TextBox();
            label3 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Txttarget);
            panel1.Controls.Add(TxtSource);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(965, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(398, 657);
            panel1.TabIndex = 0;
            // 
            // Txttarget
            // 
            Txttarget.Location = new Point(18, 272);
            Txttarget.Name = "Txttarget";
            Txttarget.Size = new Size(100, 23);
            Txttarget.TabIndex = 8;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(215, 272);
            TxtSource.Name = "TxtSource";
            TxtSource.Size = new Size(100, 23);
            TxtSource.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 276);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 6;
            label3.Text = "کد زبان مقصد : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(321, 276);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "کد زبان مبدا : ";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(0, 298);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(398, 336);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.Location = new Point(0, 634);
            button2.Name = "button2";
            button2.Size = new Size(398, 23);
            button2.TabIndex = 3;
            button2.Text = "پردازش متن";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 153);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(0, 130);
            button1.Name = "button1";
            button1.Size = new Size(398, 23);
            button1.TabIndex = 1;
            button1.Text = "پردازش تصویر";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 130);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(965, 657);
            listBox1.TabIndex = 1;
            // 
            // FrmGemma3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 657);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Name = "FrmGemma3";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "gemma3";
            Load += FrmQwen_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Label label1;
        private Button button2;
        private RichTextBox richTextBox1;
        private TextBox TxtSource;
        private Label label3;
        private Label label2;
        private TextBox Txttarget;
    }
}