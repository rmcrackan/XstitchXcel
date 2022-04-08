namespace XstitchXcelWinFormsLib.Panels
{
    partial class BatchConvertSplitPanel
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
            this.batchConvertPanel1 = new XstitchXcelWinFormsLib.Panels.BatchConvertPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.batchConvertPanel1);
            // 
            // batchConvertPanel1
            // 
            this.batchConvertPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchConvertPanel1.Location = new System.Drawing.Point(0, 0);
            this.batchConvertPanel1.Name = "batchConvertPanel1";
            this.batchConvertPanel1.Size = new System.Drawing.Size(754, 138);
            this.batchConvertPanel1.TabIndex = 0;
            // 
            // BatchConvertSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BatchConvertSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BatchConvertPanel batchConvertPanel1;
    }
}
