namespace XstitchXcelWinFormsLib.Panels
{
    partial class ImageToExcelSplitPanel
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
            this.imageToExcelPanel1 = new XstitchXcelWinFormsLib.Panels.ImageToExcelPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageToExcelPanel1);
            // 
            // imageToExcelPanel1
            // 
            this.imageToExcelPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageToExcelPanel1.Location = new System.Drawing.Point(0, 0);
            this.imageToExcelPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.imageToExcelPanel1.Name = "imageToExcelPanel1";
            this.imageToExcelPanel1.Size = new System.Drawing.Size(754, 138);
            this.imageToExcelPanel1.TabIndex = 0;
            // 
            // ImageToExcelSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ImageToExcelSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageToExcelPanel imageToExcelPanel1;
    }
}
