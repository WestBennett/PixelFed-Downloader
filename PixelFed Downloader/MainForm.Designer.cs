namespace PixelFed_Downloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnDownload = new Button();
            txtStatus = new TextBox();
            chkMakeFolders = new CheckBox();
            grpFileHandling = new GroupBox();
            rdoRename = new RadioButton();
            rdoOverwrite = new RadioButton();
            grpFileHandling.SuspendLayout();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDownload.Location = new Point(196, 12);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(111, 100);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // txtStatus
            // 
            txtStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtStatus.Location = new Point(12, 128);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(295, 288);
            txtStatus.TabIndex = 2;
            // 
            // chkMakeFolders
            // 
            chkMakeFolders.AutoSize = true;
            chkMakeFolders.Location = new Point(12, 12);
            chkMakeFolders.Name = "chkMakeFolders";
            chkMakeFolders.Size = new Size(178, 19);
            chkMakeFolders.TabIndex = 3;
            chkMakeFolders.Text = "Make Separate Folders Per ID";
            chkMakeFolders.UseVisualStyleBackColor = true;
            // 
            // grpFileHandling
            // 
            grpFileHandling.Controls.Add(rdoRename);
            grpFileHandling.Controls.Add(rdoOverwrite);
            grpFileHandling.Location = new Point(12, 37);
            grpFileHandling.Name = "grpFileHandling";
            grpFileHandling.Size = new Size(178, 75);
            grpFileHandling.TabIndex = 4;
            grpFileHandling.TabStop = false;
            grpFileHandling.Text = "File Handling:";
            // 
            // rdoRename
            // 
            rdoRename.AutoSize = true;
            rdoRename.Location = new Point(6, 47);
            rdoRename.Name = "rdoRename";
            rdoRename.Size = new Size(164, 19);
            rdoRename.TabIndex = 1;
            rdoRename.Text = "Rename Downloaded Files";
            rdoRename.UseVisualStyleBackColor = true;
            // 
            // rdoOverwrite
            // 
            rdoOverwrite.AutoSize = true;
            rdoOverwrite.Checked = true;
            rdoOverwrite.Location = new Point(6, 22);
            rdoOverwrite.Name = "rdoOverwrite";
            rdoOverwrite.Size = new Size(145, 19);
            rdoOverwrite.TabIndex = 0;
            rdoOverwrite.TabStop = true;
            rdoOverwrite.Text = "Overwrite Existing Files";
            rdoOverwrite.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 428);
            Controls.Add(grpFileHandling);
            Controls.Add(chkMakeFolders);
            Controls.Add(txtStatus);
            Controls.Add(btnDownload);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "PixelFed Downloader";
            grpFileHandling.ResumeLayout(false);
            grpFileHandling.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownload;
        private StatusStrip ssMain;
        private ToolStripStatusLabel tsslMain;
        private TextBox txtStatus;
        private CheckBox chkMakeFolders;
        private GroupBox grpFileHandling;
        private RadioButton rdoRename;
        private RadioButton rdoOverwrite;
    }
}
