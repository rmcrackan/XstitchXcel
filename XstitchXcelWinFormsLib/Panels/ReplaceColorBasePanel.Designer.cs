namespace XstitchXcelWinFormsLib.Panels
{
    partial class ReplaceColorBasePanel
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
            this.backupCb = new System.Windows.Forms.CheckBox();
            this.colorBoxControl1 = new XstitchXcelWinFormsLib.Controls.ColorBoxControl();
            this.colorBoxControl2 = new XstitchXcelWinFormsLib.Controls.ColorBoxControl();
            this.SuspendLayout();
            // 
            // backupCb
            // 
            this.backupCb.AutoSize = true;
            this.backupCb.Location = new System.Drawing.Point(3, 3);
            this.backupCb.Name = "backupCb";
            this.backupCb.Size = new System.Drawing.Size(234, 19);
            this.backupCb.TabIndex = 11;
            this.backupCb.Text = "Back up my file before making changes";
            this.backupCb.UseVisualStyleBackColor = true;
            // 
            // colorBoxControl1
            // 
            this.colorBoxControl1.ColorName = "";
            this.colorBoxControl1.Location = new System.Drawing.Point(3, 28);
            this.colorBoxControl1.Name = "colorBoxControl1";
            this.colorBoxControl1.Size = new System.Drawing.Size(515, 23);
            this.colorBoxControl1.TabIndex = 12;
            this.colorBoxControl1.Title = "Old color";
            this.colorBoxControl1.ColorTextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colorTextBoxKeyPress);
            // 
            // colorBoxControl2
            // 
            this.colorBoxControl2.ColorName = "";
            this.colorBoxControl2.Location = new System.Drawing.Point(3, 57);
            this.colorBoxControl2.Name = "colorBoxControl2";
            this.colorBoxControl2.Size = new System.Drawing.Size(515, 23);
            this.colorBoxControl2.TabIndex = 13;
            this.colorBoxControl2.Title = "New color";
            this.colorBoxControl2.ColorTextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colorTextBoxKeyPress);
            // 
            // ReplaceColorBasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorBoxControl2);
            this.Controls.Add(this.colorBoxControl1);
            this.Controls.Add(this.backupCb);
            this.Name = "ReplaceColorBasePanel";
            this.Controls.SetChildIndex(this.backupCb, 0);
            this.Controls.SetChildIndex(this.colorBoxControl1, 0);
            this.Controls.SetChildIndex(this.colorBoxControl2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox backupCb;
        private Controls.ColorBoxControl colorBoxControl1;
        private Controls.ColorBoxControl colorBoxControl2;
    }
}
