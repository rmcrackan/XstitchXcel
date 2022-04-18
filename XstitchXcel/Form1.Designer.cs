
namespace XstitchXcel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.createPatternTabPage = new System.Windows.Forms.TabPage();
            this.createPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.CreatePatternSplitPanel();
            this.statsTabPage = new System.Windows.Forms.TabPage();
            this.statsPanel1 = new XstitchXcelWinFormsLib.Panels.StatsPanel();
            this.findDmcColorsTabPage = new System.Windows.Forms.TabPage();
            this.findDmcColorsSplitPanel1 = new XstitchXcelWinFormsLib.Panels.FindDmcColorsSplitPanel();
            this.replaceColorTabPage = new System.Windows.Forms.TabPage();
            this.replaceColorInPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternSplitPanel();
            this.replaceColorNaiveTabPage = new System.Windows.Forms.TabPage();
            this.replaceColorNaiveSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorNaiveSplitPanel();
            this.batchConvertTabPage = new System.Windows.Forms.TabPage();
            this.batchConvertSplitPanel1 = new XstitchXcelWinFormsLib.Panels.BatchConvertSplitPanel();
            this.toPngTabPage = new System.Windows.Forms.TabPage();
            this.toPngSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ToPngSplitPanel();
            this.crtBlurTabPage = new System.Windows.Forms.TabPage();
            this.crtBlurSplitPanel1 = new XstitchXcelWinFormsLib.Panels.CrtBlurSplitPanel();
            this.imageToExcelTabPage = new System.Windows.Forms.TabPage();
            this.imageToExcelSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ImageToExcelSplitPanel();
            this.openFileControl1 = new XstitchXcelWinFormsLib.Controls.OpenFileControl();
            this.tabControl.SuspendLayout();
            this.createPatternTabPage.SuspendLayout();
            this.statsTabPage.SuspendLayout();
            this.findDmcColorsTabPage.SuspendLayout();
            this.replaceColorTabPage.SuspendLayout();
            this.replaceColorNaiveTabPage.SuspendLayout();
            this.batchConvertTabPage.SuspendLayout();
            this.toPngTabPage.SuspendLayout();
            this.crtBlurTabPage.SuspendLayout();
            this.imageToExcelTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.createPatternTabPage);
            this.tabControl.Controls.Add(this.statsTabPage);
            this.tabControl.Controls.Add(this.findDmcColorsTabPage);
            this.tabControl.Controls.Add(this.replaceColorTabPage);
            this.tabControl.Controls.Add(this.replaceColorNaiveTabPage);
            this.tabControl.Controls.Add(this.batchConvertTabPage);
            this.tabControl.Controls.Add(this.toPngTabPage);
            this.tabControl.Controls.Add(this.crtBlurTabPage);
            this.tabControl.Controls.Add(this.imageToExcelTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 37);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(762, 386);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // createPatternTabPage
            // 
            this.createPatternTabPage.Controls.Add(this.createPatternSplitPanel1);
            this.createPatternTabPage.Location = new System.Drawing.Point(4, 24);
            this.createPatternTabPage.Name = "createPatternTabPage";
            this.createPatternTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.createPatternTabPage.Size = new System.Drawing.Size(754, 358);
            this.createPatternTabPage.TabIndex = 8;
            this.createPatternTabPage.Text = "Create Pattern";
            this.createPatternTabPage.UseVisualStyleBackColor = true;
            // 
            // createPatternSplitPanel1
            // 
            this.createPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createPatternSplitPanel1.Location = new System.Drawing.Point(3, 3);
            this.createPatternSplitPanel1.Name = "createPatternSplitPanel1";
            this.createPatternSplitPanel1.Size = new System.Drawing.Size(748, 352);
            this.createPatternSplitPanel1.TabIndex = 0;
            // 
            // statsTabPage
            // 
            this.statsTabPage.Controls.Add(this.statsPanel1);
            this.statsTabPage.Location = new System.Drawing.Point(4, 24);
            this.statsTabPage.Name = "statsTabPage";
            this.statsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.statsTabPage.Size = new System.Drawing.Size(754, 358);
            this.statsTabPage.TabIndex = 9;
            this.statsTabPage.Text = "Stats";
            this.statsTabPage.UseVisualStyleBackColor = true;
            // 
            // statsPanel1
            // 
            this.statsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsPanel1.Location = new System.Drawing.Point(3, 3);
            this.statsPanel1.Name = "statsPanel1";
            this.statsPanel1.Size = new System.Drawing.Size(748, 352);
            this.statsPanel1.TabIndex = 0;
            // 
            // findDmcColorsTabPage
            // 
            this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsSplitPanel1);
            this.findDmcColorsTabPage.Location = new System.Drawing.Point(4, 24);
            this.findDmcColorsTabPage.Name = "findDmcColorsTabPage";
            this.findDmcColorsTabPage.Size = new System.Drawing.Size(754, 358);
            this.findDmcColorsTabPage.TabIndex = 10;
            this.findDmcColorsTabPage.Text = "Find DMC Colors";
            this.findDmcColorsTabPage.UseVisualStyleBackColor = true;
            // 
            // findDmcColorsSplitPanel1
            // 
            this.findDmcColorsSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findDmcColorsSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.findDmcColorsSplitPanel1.Name = "findDmcColorsSplitPanel1";
            this.findDmcColorsSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.findDmcColorsSplitPanel1.TabIndex = 0;
            // 
            // replaceColorTabPage
            // 
            this.replaceColorTabPage.Controls.Add(this.replaceColorInPatternSplitPanel1);
            this.replaceColorTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorTabPage.Name = "replaceColorTabPage";
            this.replaceColorTabPage.Size = new System.Drawing.Size(754, 358);
            this.replaceColorTabPage.TabIndex = 11;
            this.replaceColorTabPage.Text = "Replace Color";
            this.replaceColorTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorInPatternSplitPanel1
            // 
            this.replaceColorInPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replaceColorInPatternSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.replaceColorInPatternSplitPanel1.Name = "replaceColorInPatternSplitPanel1";
            this.replaceColorInPatternSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.replaceColorInPatternSplitPanel1.TabIndex = 0;
            // 
            // replaceColorNaiveTabPage
            // 
            this.replaceColorNaiveTabPage.Controls.Add(this.replaceColorNaiveSplitPanel1);
            this.replaceColorNaiveTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorNaiveTabPage.Name = "replaceColorNaiveTabPage";
            this.replaceColorNaiveTabPage.Size = new System.Drawing.Size(754, 358);
            this.replaceColorNaiveTabPage.TabIndex = 12;
            this.replaceColorNaiveTabPage.Text = "Replace Color (naive)";
            this.replaceColorNaiveTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorNaiveSplitPanel1
            // 
            this.replaceColorNaiveSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replaceColorNaiveSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.replaceColorNaiveSplitPanel1.Name = "replaceColorNaiveSplitPanel1";
            this.replaceColorNaiveSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.replaceColorNaiveSplitPanel1.TabIndex = 0;
            // 
            // batchConvertTabPage
            // 
            this.batchConvertTabPage.Controls.Add(this.batchConvertSplitPanel1);
            this.batchConvertTabPage.Location = new System.Drawing.Point(4, 24);
            this.batchConvertTabPage.Name = "batchConvertTabPage";
            this.batchConvertTabPage.Size = new System.Drawing.Size(754, 358);
            this.batchConvertTabPage.TabIndex = 15;
            this.batchConvertTabPage.Text = "Batch Convert";
            this.batchConvertTabPage.UseVisualStyleBackColor = true;
            // 
            // batchConvertSplitPanel1
            // 
            this.batchConvertSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchConvertSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.batchConvertSplitPanel1.Name = "batchConvertSplitPanel1";
            this.batchConvertSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.batchConvertSplitPanel1.TabIndex = 0;
            // 
            // toPngTabPage
            // 
            this.toPngTabPage.Controls.Add(this.toPngSplitPanel1);
            this.toPngTabPage.Location = new System.Drawing.Point(4, 24);
            this.toPngTabPage.Name = "toPngTabPage";
            this.toPngTabPage.Size = new System.Drawing.Size(754, 358);
            this.toPngTabPage.TabIndex = 13;
            this.toPngTabPage.Text = "To png";
            this.toPngTabPage.UseVisualStyleBackColor = true;
            // 
            // toPngSplitPanel1
            // 
            this.toPngSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toPngSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.toPngSplitPanel1.Name = "toPngSplitPanel1";
            this.toPngSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.toPngSplitPanel1.TabIndex = 0;
            // 
            // crtBlurTabPage
            // 
            this.crtBlurTabPage.Controls.Add(this.crtBlurSplitPanel1);
            this.crtBlurTabPage.Location = new System.Drawing.Point(4, 24);
            this.crtBlurTabPage.Name = "crtBlurTabPage";
            this.crtBlurTabPage.Size = new System.Drawing.Size(754, 358);
            this.crtBlurTabPage.TabIndex = 14;
            this.crtBlurTabPage.Text = "CRT Blur";
            this.crtBlurTabPage.UseVisualStyleBackColor = true;
            // 
            // crtBlurSplitPanel1
            // 
            this.crtBlurSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtBlurSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.crtBlurSplitPanel1.Name = "crtBlurSplitPanel1";
            this.crtBlurSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.crtBlurSplitPanel1.TabIndex = 0;
            // 
            // imageToExcelTabPage
            // 
            this.imageToExcelTabPage.Controls.Add(this.imageToExcelSplitPanel1);
            this.imageToExcelTabPage.Location = new System.Drawing.Point(4, 24);
            this.imageToExcelTabPage.Name = "imageToExcelTabPage";
            this.imageToExcelTabPage.Size = new System.Drawing.Size(754, 358);
            this.imageToExcelTabPage.TabIndex = 16;
            this.imageToExcelTabPage.Text = "Image to Excel";
            this.imageToExcelTabPage.UseVisualStyleBackColor = true;
            // 
            // imageToExcelSplitPanel1
            // 
            this.imageToExcelSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageToExcelSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.imageToExcelSplitPanel1.Name = "imageToExcelSplitPanel1";
            this.imageToExcelSplitPanel1.Size = new System.Drawing.Size(754, 358);
            this.imageToExcelSplitPanel1.TabIndex = 0;
            // 
            // openFileControl1
            // 
            this.openFileControl1.DialogTitle = "Select the Excel file with your design";
            this.openFileControl1.FileExtension = "xlsx";
            this.openFileControl1.FileFilterOverride = null;
            this.openFileControl1.FileName = "";
            this.openFileControl1.FileTypeName = "Excel Spreadsheet";
            this.openFileControl1.LabelText = "Excel file";
            this.openFileControl1.Location = new System.Drawing.Point(12, 0);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(762, 31);
            this.openFileControl1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 435);
            this.Controls.Add(this.openFileControl1);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Xstitch Xcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl.ResumeLayout(false);
            this.createPatternTabPage.ResumeLayout(false);
            this.statsTabPage.ResumeLayout(false);
            this.findDmcColorsTabPage.ResumeLayout(false);
            this.replaceColorTabPage.ResumeLayout(false);
            this.replaceColorNaiveTabPage.ResumeLayout(false);
            this.batchConvertTabPage.ResumeLayout(false);
            this.toPngTabPage.ResumeLayout(false);
            this.crtBlurTabPage.ResumeLayout(false);
            this.imageToExcelTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage createPatternTabPage;
        private XstitchXcelWinFormsLib.Panels.CreatePatternSplitPanel createPatternSplitPanel1;
        private System.Windows.Forms.TabPage statsTabPage;
        private System.Windows.Forms.TabPage findDmcColorsTabPage;
        private XstitchXcelWinFormsLib.Panels.FindDmcColorsSplitPanel findDmcColorsSplitPanel1;
        private System.Windows.Forms.TabPage replaceColorTabPage;
        private XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternSplitPanel replaceColorInPatternSplitPanel1;
        private XstitchXcelWinFormsLib.Panels.StatsPanel statsPanel1;
        private System.Windows.Forms.TabPage replaceColorNaiveTabPage;
        private XstitchXcelWinFormsLib.Panels.ReplaceColorNaiveSplitPanel replaceColorNaiveSplitPanel1;
        private System.Windows.Forms.TabPage toPngTabPage;
        private XstitchXcelWinFormsLib.Panels.ToPngSplitPanel toPngSplitPanel1;
        private System.Windows.Forms.TabPage crtBlurTabPage;
        private XstitchXcelWinFormsLib.Panels.CrtBlurSplitPanel crtBlurSplitPanel1;
        private XstitchXcelWinFormsLib.Controls.OpenFileControl openFileControl1;
        private System.Windows.Forms.TabPage batchConvertTabPage;
        private XstitchXcelWinFormsLib.Panels.BatchConvertSplitPanel batchConvertSplitPanel1;
        private System.Windows.Forms.TabPage imageToExcelTabPage;
        private XstitchXcelWinFormsLib.Panels.ImageToExcelSplitPanel imageToExcelSplitPanel1;
    }
}

