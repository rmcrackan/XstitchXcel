namespace XstitchXcelWinFormsLib.Panels
{
    partial class CrtBlurSplitPanel
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
            this.crtBlurPanel1 = new XstitchXcelWinFormsLib.Panels.CrtBlurPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crtBlurPanel1);
            // 
            // crtBlurPanel1
            // 
            this.crtBlurPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtBlurPanel1.Location = new System.Drawing.Point(0, 0);
            this.crtBlurPanel1.Name = "crtBlurPanel1";
            this.crtBlurPanel1.Size = new System.Drawing.Size(754, 138);
            this.crtBlurPanel1.TabIndex = 0;
            // 
            // CrtBlurSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CrtBlurSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrtBlurPanel crtBlurPanel1;
    }
}
