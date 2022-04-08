namespace XstitchXcelWinFormsLib.Panels
{
    partial class CreatePatternPanel
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
            this.colorsAndGlyphsCb = new System.Windows.Forms.CheckBox();
            this.glyphsCb = new System.Windows.Forms.CheckBox();
            this.colorsCb = new System.Windows.Forms.CheckBox();
            this.saveFileControl1 = new XstitchXcelWinFormsLib.Controls.SaveFileControl();
            this.SuspendLayout();
            // 
            // colorsAndGlyphsCb
            // 
            this.colorsAndGlyphsCb.AutoSize = true;
            this.colorsAndGlyphsCb.Checked = true;
            this.colorsAndGlyphsCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorsAndGlyphsCb.Location = new System.Drawing.Point(32, 86);
            this.colorsAndGlyphsCb.Name = "colorsAndGlyphsCb";
            this.colorsAndGlyphsCb.Size = new System.Drawing.Size(130, 19);
            this.colorsAndGlyphsCb.TabIndex = 13;
            this.colorsAndGlyphsCb.Text = "Colors and symbols";
            this.colorsAndGlyphsCb.UseVisualStyleBackColor = true;
            // 
            // glyphsCb
            // 
            this.glyphsCb.AutoSize = true;
            this.glyphsCb.Checked = true;
            this.glyphsCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.glyphsCb.Location = new System.Drawing.Point(32, 61);
            this.glyphsCb.Name = "glyphsCb";
            this.glyphsCb.Size = new System.Drawing.Size(141, 19);
            this.glyphsCb.TabIndex = 12;
            this.glyphsCb.Text = "Symbols (aka: glyphs)";
            this.glyphsCb.UseVisualStyleBackColor = true;
            // 
            // colorsCb
            // 
            this.colorsCb.AutoSize = true;
            this.colorsCb.Checked = true;
            this.colorsCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorsCb.Location = new System.Drawing.Point(32, 36);
            this.colorsCb.Name = "colorsCb";
            this.colorsCb.Size = new System.Drawing.Size(60, 19);
            this.colorsCb.TabIndex = 11;
            this.colorsCb.Text = "Colors";
            this.colorsCb.UseVisualStyleBackColor = true;
            // 
            // saveFileControl1
            // 
            this.saveFileControl1.DialogTitle = "generated pattern file";
            this.saveFileControl1.FileExtension = "xlsx";
            this.saveFileControl1.FileTypeName = "Excel Spreadsheet";
            this.saveFileControl1.LabelText = "Pattern output file";
            this.saveFileControl1.Location = new System.Drawing.Point(0, 0);
            this.saveFileControl1.Name = "saveFileControl1";
            this.saveFileControl1.Size = new System.Drawing.Size(751, 31);
            this.saveFileControl1.TabIndex = 14;
            this.saveFileControl1.FileName = "";
            this.saveFileControl1.FileNameKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveFileControl1_FileNameKeyPress);
            // 
            // CreatePatternPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveFileControl1);
            this.Controls.Add(this.colorsAndGlyphsCb);
            this.Controls.Add(this.glyphsCb);
            this.Controls.Add(this.colorsCb);
            this.Name = "CreatePatternPanel";
            this.Controls.SetChildIndex(this.colorsCb, 0);
            this.Controls.SetChildIndex(this.glyphsCb, 0);
            this.Controls.SetChildIndex(this.colorsAndGlyphsCb, 0);
            this.Controls.SetChildIndex(this.saveFileControl1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colorsAndGlyphsCb;
        private System.Windows.Forms.CheckBox glyphsCb;
        private System.Windows.Forms.CheckBox colorsCb;
        private Controls.SaveFileControl saveFileControl1;
    }
}
