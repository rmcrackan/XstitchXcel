﻿namespace XstitchXcelWinFormsLib.Panels
{
    partial class ReplaceColorInPatternSplitPanel
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
            this.replaceColorInPatternPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.replaceColorInPatternPanel1);
            // 
            // replaceColorInPatternPanel1
            // 
            this.replaceColorInPatternPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replaceColorInPatternPanel1.Location = new System.Drawing.Point(0, 0);
            this.replaceColorInPatternPanel1.Name = "replaceColorInPatternPanel1";
            this.replaceColorInPatternPanel1.Size = new System.Drawing.Size(754, 138);
            this.replaceColorInPatternPanel1.TabIndex = 0;
            // 
            // ReplaceColorInPatternSplitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ReplaceColorInPatternSplitPanel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReplaceColorInPatternPanel replaceColorInPatternPanel1;
    }
}
