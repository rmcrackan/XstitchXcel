namespace XstitchXcelWinFormsLib.Panels
{
    partial class CrtBlurPanel
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
            this.saveFileControl1 = new XstitchXcelWinFormsLib.Controls.SaveFileControl();
            this.SuspendLayout();
            // 
            // saveFileControl1
            // 
            this.saveFileControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileControl1.DialogTitle = "generated CRT Blur file";
            this.saveFileControl1.FileExtension = "xlsx";
            this.saveFileControl1.FileName = "";
            this.saveFileControl1.FileTypeName = "Excel Spreadsheet";
            this.saveFileControl1.LabelText = "CRT Blur output file";
            this.saveFileControl1.Location = new System.Drawing.Point(3, 3);
            this.saveFileControl1.Name = "saveFileControl1";
            this.saveFileControl1.Size = new System.Drawing.Size(748, 31);
            this.saveFileControl1.TabIndex = 1;
            this.saveFileControl1.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveFileControl1_FileNameKeyPress);
            // 
            // CrtBlurPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveFileControl1);
            this.Name = "CrtBlurPanel";
            this.Controls.SetChildIndex(this.saveFileControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SaveFileControl saveFileControl1;
    }
}
