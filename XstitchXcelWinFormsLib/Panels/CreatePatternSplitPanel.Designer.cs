namespace XstitchXcelWinFormsLib.Panels
{
    partial class CreatePatternSplitPanel
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
            this.createPatternPanel1 = new XstitchXcelWinFormsLib.Panels.CreatePatternPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createPatternPanel1);
            // 
            // createPatternPanel1
            // 
            this.createPatternPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createPatternPanel1.Location = new System.Drawing.Point(0, 0);
            this.createPatternPanel1.Name = "createPatternPanel1";
            this.createPatternPanel1.Size = new System.Drawing.Size(754, 138);
            this.createPatternPanel1.TabIndex = 0;
            // 
            // CreatePatternSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CreatePatternSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CreatePatternPanel createPatternPanel1;
    }
}
