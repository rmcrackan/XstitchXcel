namespace XstitchXcelWinFormsLib.Panels
{
    partial class _ToolSplit
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
            this.instructionsTb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // instructionsTb
            // 
            this.instructionsTb.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructionsTb.Location = new System.Drawing.Point(0, 0);
            this.instructionsTb.Multiline = true;
            this.instructionsTb.Name = "instructionsTb";
            this.instructionsTb.ReadOnly = true;
            this.instructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.instructionsTb.Size = new System.Drawing.Size(754, 215);
            this.instructionsTb.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 138);
            this.panel1.TabIndex = 11;
            // 
            // _ToolSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.instructionsTb);
            this.Name = "_ToolSplit";
            this.Load += new System.EventHandler(this._ToolSplit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox instructionsTb;
    }
}
