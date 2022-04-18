namespace XstitchXcelWinFormsLib.Panels
{
    partial class ImageToExcelPanel
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
            this.openFileControl1 = new XstitchXcelWinFormsLib.Controls.OpenFileControl();
            this.saveFileControl1 = new XstitchXcelWinFormsLib.Controls.SaveFileControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // openFileControl1
            // 
            this.openFileControl1.DialogTitle = null;
            this.openFileControl1.FileExtension = null;
            this.openFileControl1.FileFilterOverride = null;
            this.openFileControl1.FileName = "";
            this.openFileControl1.FileTypeName = null;
            this.openFileControl1.LabelText = "label1";
            this.openFileControl1.Location = new System.Drawing.Point(0, 0);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(754, 28);
            this.openFileControl1.TabIndex = 1;
            this.openFileControl1.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileNameKeyPress);
            // 
            // saveFileControl1
            // 
            this.saveFileControl1.DialogTitle = null;
            this.saveFileControl1.FileExtension = null;
            this.saveFileControl1.FileFilterOverride = null;
            this.saveFileControl1.FileName = "";
            this.saveFileControl1.FileTypeName = null;
            this.saveFileControl1.LabelText = "label1";
            this.saveFileControl1.Location = new System.Drawing.Point(0, 34);
            this.saveFileControl1.Name = "saveFileControl1";
            this.saveFileControl1.Size = new System.Drawing.Size(754, 28);
            this.saveFileControl1.TabIndex = 2;
            this.saveFileControl1.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileNameKeyPress);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 72);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(748, 21);
            this.progressBar1.TabIndex = 4;
            // 
            // ImageToExcelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.saveFileControl1);
            this.Controls.Add(this.openFileControl1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ImageToExcelPanel";
            this.Controls.SetChildIndex(this.openFileControl1, 0);
            this.Controls.SetChildIndex(this.saveFileControl1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.OpenFileControl openFileControl1;
        private Controls.SaveFileControl saveFileControl1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
