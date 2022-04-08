namespace XstitchXcelWinFormsLib.Controls
{
    partial class ColorBoxControl
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
            this.colorLbl = new System.Windows.Forms.Label();
            this.colorPb = new System.Windows.Forms.PictureBox();
            this.colorTb = new System.Windows.Forms.TextBox();
            this.titleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.colorPb)).BeginInit();
            this.SuspendLayout();
            // 
            // colorLbl
            // 
            this.colorLbl.AutoSize = true;
            this.colorLbl.Location = new System.Drawing.Point(328, 3);
            this.colorLbl.Name = "colorLbl";
            this.colorLbl.Size = new System.Drawing.Size(38, 15);
            this.colorLbl.TabIndex = 15;
            this.colorLbl.Text = "label1";
            this.colorLbl.Visible = false;
            // 
            // colorPb
            // 
            this.colorPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPb.Location = new System.Drawing.Point(204, 0);
            this.colorPb.Name = "colorPb";
            this.colorPb.Size = new System.Drawing.Size(100, 23);
            this.colorPb.TabIndex = 16;
            this.colorPb.TabStop = false;
            this.colorPb.Visible = false;
            // 
            // colorTb
            // 
            this.colorTb.Location = new System.Drawing.Point(78, 0);
            this.colorTb.Name = "colorTb";
            this.colorTb.Size = new System.Drawing.Size(100, 23);
            this.colorTb.TabIndex = 14;
            this.colorTb.TextChanged += new System.EventHandler(this.colorTb_TextChanged);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(0, 3);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(43, 15);
            this.titleLbl.TabIndex = 17;
            this.titleLbl.Text = "titleLbl";
            // 
            // ColorBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorLbl);
            this.Controls.Add(this.colorPb);
            this.Controls.Add(this.colorTb);
            this.Controls.Add(this.titleLbl);
            this.Name = "ColorBoxControl";
            this.Size = new System.Drawing.Size(515, 23);
            ((System.ComponentModel.ISupportInitialize)(this.colorPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label colorLbl;
        private System.Windows.Forms.PictureBox colorPb;
        private System.Windows.Forms.TextBox colorTb;
        private System.Windows.Forms.Label titleLbl;
    }
}
