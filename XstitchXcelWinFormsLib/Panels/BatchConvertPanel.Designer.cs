namespace XstitchXcelWinFormsLib.Panels
{
    partial class BatchConvertPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceBrowseFolderControl = new XstitchXcelWinFormsLib.Controls.BrowseFolderControl();
            this.destinationBrowseFolderControl = new XstitchXcelWinFormsLib.Controls.BrowseFolderControl();
            this.SuspendLayout();
            // 
            // sourceBrowseFolderControl
            // 
            this.sourceBrowseFolderControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceBrowseFolderControl.DialogTitle = null;
            this.sourceBrowseFolderControl.FileExtension = null;
            this.sourceBrowseFolderControl.FileName = "";
            this.sourceBrowseFolderControl.FileTypeName = null;
            this.sourceBrowseFolderControl.LabelText = "Source dir";
            this.sourceBrowseFolderControl.Location = new System.Drawing.Point(0, 0);
            this.sourceBrowseFolderControl.Name = "sourceBrowseFolderControl";
            this.sourceBrowseFolderControl.Size = new System.Drawing.Size(754, 31);
            this.sourceBrowseFolderControl.TabIndex = 1;
            this.sourceBrowseFolderControl.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileNameKeyPress);
            // 
            // destinationBrowseFolderControl
            // 
            this.destinationBrowseFolderControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationBrowseFolderControl.DialogTitle = null;
            this.destinationBrowseFolderControl.FileExtension = null;
            this.destinationBrowseFolderControl.FileName = "";
            this.destinationBrowseFolderControl.FileTypeName = null;
            this.destinationBrowseFolderControl.LabelText = "Destination dir";
            this.destinationBrowseFolderControl.Location = new System.Drawing.Point(0, 37);
            this.destinationBrowseFolderControl.Name = "destinationBrowseFolderControl";
            this.destinationBrowseFolderControl.Size = new System.Drawing.Size(754, 31);
            this.destinationBrowseFolderControl.TabIndex = 2;
            this.destinationBrowseFolderControl.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileNameKeyPress);
            // 
            // BatchConvertPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.destinationBrowseFolderControl);
            this.Controls.Add(this.sourceBrowseFolderControl);
            this.Name = "BatchConvertPanel";
            this.Controls.SetChildIndex(this.sourceBrowseFolderControl, 0);
            this.Controls.SetChildIndex(this.destinationBrowseFolderControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BrowseFolderControl sourceBrowseFolderControl;
        private Controls.BrowseFolderControl destinationBrowseFolderControl;
    }
}
