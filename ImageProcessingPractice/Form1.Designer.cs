namespace ImageProcessingPractice
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            copyPasteToolStripMenuItem = new ToolStripMenuItem();
            grayscaleToolStripMenuItem = new ToolStripMenuItem();
            invertToolStripMenuItem = new ToolStripMenuItem();
            xToolStripMenuItem = new ToolStripMenuItem();
            yToolStripMenuItem = new ToolStripMenuItem();
            invertToolStripMenuItem1 = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(49, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(319, 305);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(431, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(319, 305);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, actionsToolStripMenuItem, saveToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyPasteToolStripMenuItem, grayscaleToolStripMenuItem, invertToolStripMenuItem, invertToolStripMenuItem1, histogramToolStripMenuItem, sepiaToolStripMenuItem });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(59, 20);
            actionsToolStripMenuItem.Text = "Actions";
            actionsToolStripMenuItem.Click += actionsToolStripMenuItem_Click;
            // 
            // copyPasteToolStripMenuItem
            // 
            copyPasteToolStripMenuItem.Name = "copyPasteToolStripMenuItem";
            copyPasteToolStripMenuItem.Size = new Size(180, 22);
            copyPasteToolStripMenuItem.Text = "Copy / Paste";
            copyPasteToolStripMenuItem.Click += copyPasteToolStripMenuItem_Click;
            // 
            // grayscaleToolStripMenuItem
            // 
            grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            grayscaleToolStripMenuItem.Size = new Size(180, 22);
            grayscaleToolStripMenuItem.Text = "Grayscale";
            grayscaleToolStripMenuItem.Click += grayscaleToolStripMenuItem_Click;
            // 
            // invertToolStripMenuItem
            // 
            invertToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { xToolStripMenuItem, yToolStripMenuItem });
            invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            invertToolStripMenuItem.Size = new Size(180, 22);
            invertToolStripMenuItem.Text = "Rotate";
            // 
            // xToolStripMenuItem
            // 
            xToolStripMenuItem.Name = "xToolStripMenuItem";
            xToolStripMenuItem.Size = new Size(81, 22);
            xToolStripMenuItem.Text = "X";
            xToolStripMenuItem.Click += xToolStripMenuItem_Click;
            // 
            // yToolStripMenuItem
            // 
            yToolStripMenuItem.Name = "yToolStripMenuItem";
            yToolStripMenuItem.Size = new Size(81, 22);
            yToolStripMenuItem.Text = "Y";
            yToolStripMenuItem.Click += yToolStripMenuItem_Click;
            // 
            // invertToolStripMenuItem1
            // 
            invertToolStripMenuItem1.Name = "invertToolStripMenuItem1";
            invertToolStripMenuItem1.Size = new Size(180, 22);
            invertToolStripMenuItem1.Text = "Invert";
            invertToolStripMenuItem1.Click += invertToolStripMenuItem1_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(180, 22);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(180, 22);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(43, 20);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem copyPasteToolStripMenuItem;
        private ToolStripMenuItem grayscaleToolStripMenuItem;
        private ToolStripMenuItem invertToolStripMenuItem;
        private ToolStripMenuItem xToolStripMenuItem;
        private ToolStripMenuItem yToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem invertToolStripMenuItem1;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
    }
}