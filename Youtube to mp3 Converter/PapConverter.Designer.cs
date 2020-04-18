namespace Youtube_to_mp3_Converter
{
    partial class PapConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PapConverter));
            this.label1 = new System.Windows.Forms.Label();
            this.Url = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Convert = new System.Windows.Forms.Button();
            this.Statuslbl = new System.Windows.Forms.Label();
            this.Titlelbl = new System.Windows.Forms.Label();
            this.Artistlbl = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.Label();
            this.Image = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mp3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troubleshootingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url: ";
            // 
            // Url
            // 
            this.Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Url.Location = new System.Drawing.Point(68, 49);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(1028, 22);
            this.Url.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(31, 487);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1065, 23);
            this.progressBar.TabIndex = 2;
            // 
            // Convert
            // 
            this.Convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Convert.Enabled = false;
            this.Convert.Location = new System.Drawing.Point(982, 123);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(114, 34);
            this.Convert.TabIndex = 3;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Statuslbl
            // 
            this.Statuslbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Statuslbl.AutoSize = true;
            this.Statuslbl.Location = new System.Drawing.Point(28, 513);
            this.Statuslbl.Name = "Statuslbl";
            this.Statuslbl.Size = new System.Drawing.Size(48, 17);
            this.Statuslbl.TabIndex = 4;
            this.Statuslbl.Text = "Status";
            // 
            // Titlelbl
            // 
            this.Titlelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titlelbl.AutoSize = true;
            this.Titlelbl.Location = new System.Drawing.Point(512, 177);
            this.Titlelbl.Name = "Titlelbl";
            this.Titlelbl.Size = new System.Drawing.Size(35, 17);
            this.Titlelbl.TabIndex = 5;
            this.Titlelbl.Text = "Title";
            // 
            // Artistlbl
            // 
            this.Artistlbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Artistlbl.AutoSize = true;
            this.Artistlbl.Location = new System.Drawing.Point(512, 203);
            this.Artistlbl.Name = "Artistlbl";
            this.Artistlbl.Size = new System.Drawing.Size(40, 17);
            this.Artistlbl.TabIndex = 6;
            this.Artistlbl.Text = "Artist";
            // 
            // Duration
            // 
            this.Duration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Duration.AutoSize = true;
            this.Duration.Location = new System.Drawing.Point(512, 231);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(62, 17);
            this.Duration.TabIndex = 7;
            this.Duration.Text = "Duration";
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(68, 177);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(438, 251);
            this.Image.TabIndex = 8;
            this.Image.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.troubleshootingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.convertToolStripMenuItem.Text = "Convert";
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mp3ToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // mp3ToolStripMenuItem
            // 
            this.mp3ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.mp3ToolStripMenuItem.Name = "mp3ToolStripMenuItem";
            this.mp3ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.mp3ToolStripMenuItem.Text = "mp3";
            this.mp3ToolStripMenuItem.Click += new System.EventHandler(this.mp3ToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mp4ToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // mp4ToolStripMenuItem
            // 
            this.mp4ToolStripMenuItem.Name = "mp4ToolStripMenuItem";
            this.mp4ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.mp4ToolStripMenuItem.Text = "mp4";
            this.mp4ToolStripMenuItem.Click += new System.EventHandler(this.mp4ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // troubleshootingToolStripMenuItem
            // 
            this.troubleshootingToolStripMenuItem.Name = "troubleshootingToolStripMenuItem";
            this.troubleshootingToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.troubleshootingToolStripMenuItem.Text = "Troubleshooting";
            this.troubleshootingToolStripMenuItem.Click += new System.EventHandler(this.troubleshootingToolStripMenuItem_Click);
            // 
            // PapConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 561);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.Artistlbl);
            this.Controls.Add(this.Titlelbl);
            this.Controls.Add(this.Statuslbl);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PapConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pap Converter";
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.Label Statuslbl;
        private System.Windows.Forms.Label Titlelbl;
        private System.Windows.Forms.Label Artistlbl;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mp3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mp4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troubleshootingToolStripMenuItem;
    }
}

