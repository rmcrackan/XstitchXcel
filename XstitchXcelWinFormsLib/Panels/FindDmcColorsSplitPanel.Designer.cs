namespace XstitchXcelWinFormsLib.Panels
{
    partial class FindDmcColorsSplitPanel
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
            this.findDmcColorsPanel1 = new XstitchXcelWinFormsLib.Panels.FindDmcColorsPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.findDmcColorsPanel1);
            // 
            // findDmcColorsPanel1
            // 
            this.findDmcColorsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findDmcColorsPanel1.Location = new System.Drawing.Point(0, 0);
            this.findDmcColorsPanel1.Name = "findDmcColorsPanel1";
            this.findDmcColorsPanel1.Size = new System.Drawing.Size(754, 138);
            this.findDmcColorsPanel1.TabIndex = 0;
            // 
            // FindDmcColorsSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FindDmcColorsSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FindDmcColorsPanel findDmcColorsPanel1;
    }
}
