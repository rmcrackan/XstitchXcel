namespace XstitchXcelWinFormsLib.Panels
{
    partial class ToPngPanel
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
            this.toPngNud = new System.Windows.Forms.NumericUpDown();
            this.toPngScaleRb = new System.Windows.Forms.RadioButton();
            this.toPngOriginalRb = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileControl1
            // 
            this.saveFileControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileControl1.DialogTitle = "generated png image file";
            this.saveFileControl1.FileExtension = "png";
            this.saveFileControl1.FileName = "";
            this.saveFileControl1.FileTypeName = "PNG";
            this.saveFileControl1.LabelText = "Png output file";
            this.saveFileControl1.Location = new System.Drawing.Point(3, 3);
            this.saveFileControl1.Name = "saveFileControl1";
            this.saveFileControl1.Size = new System.Drawing.Size(748, 31);
            this.saveFileControl1.TabIndex = 1;
            this.saveFileControl1.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveFileControl1_FileNameKeyPress);
            // 
            // toPngNud
            // 
            this.toPngNud.Location = new System.Drawing.Point(84, 65);
            this.toPngNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toPngNud.Name = "toPngNud";
            this.toPngNud.Size = new System.Drawing.Size(50, 23);
            this.toPngNud.TabIndex = 27;
            this.toPngNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // toPngScaleRb
            // 
            this.toPngScaleRb.AutoSize = true;
            this.toPngScaleRb.Location = new System.Drawing.Point(3, 65);
            this.toPngScaleRb.Name = "toPngScaleRb";
            this.toPngScaleRb.Size = new System.Drawing.Size(75, 19);
            this.toPngScaleRb.TabIndex = 26;
            this.toPngScaleRb.Text = "Scale to x";
            this.toPngScaleRb.UseVisualStyleBackColor = true;
            this.toPngScaleRb.CheckedChanged += new System.EventHandler(this.enableScaleUpDown);
            // 
            // toPngOriginalRb
            // 
            this.toPngOriginalRb.AutoSize = true;
            this.toPngOriginalRb.Checked = true;
            this.toPngOriginalRb.Location = new System.Drawing.Point(3, 40);
            this.toPngOriginalRb.Name = "toPngOriginalRb";
            this.toPngOriginalRb.Size = new System.Drawing.Size(89, 19);
            this.toPngOriginalRb.TabIndex = 25;
            this.toPngOriginalRb.TabStop = true;
            this.toPngOriginalRb.Text = "Original size";
            this.toPngOriginalRb.UseVisualStyleBackColor = true;
            this.toPngOriginalRb.CheckedChanged += new System.EventHandler(this.enableScaleUpDown);
            // 
            // ToPngPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toPngNud);
            this.Controls.Add(this.toPngScaleRb);
            this.Controls.Add(this.toPngOriginalRb);
            this.Controls.Add(this.saveFileControl1);
            this.Name = "ToPngPanel";
            this.Controls.SetChildIndex(this.saveFileControl1, 0);
            this.Controls.SetChildIndex(this.toPngOriginalRb, 0);
            this.Controls.SetChildIndex(this.toPngScaleRb, 0);
            this.Controls.SetChildIndex(this.toPngNud, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SaveFileControl saveFileControl1;
        private System.Windows.Forms.NumericUpDown toPngNud;
        private System.Windows.Forms.RadioButton toPngScaleRb;
        private System.Windows.Forms.RadioButton toPngOriginalRb;
    }
}
