
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
            tabControl = new System.Windows.Forms.TabControl();
            createPatternTabPage = new System.Windows.Forms.TabPage();
            createPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.CreatePatternSplitPanel();
            statsTabPage = new System.Windows.Forms.TabPage();
            statsPanel1 = new XstitchXcelWinFormsLib.Panels.StatsPanel();
            findDmcColorsTabPage = new System.Windows.Forms.TabPage();
            findDmcColorsSplitPanel1 = new XstitchXcelWinFormsLib.Panels.FindDmcColorsSplitPanel();
            replaceColorTabPage = new System.Windows.Forms.TabPage();
            replaceColorInPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternSplitPanel();
            replaceColorNaiveTabPage = new System.Windows.Forms.TabPage();
            replaceColorNaiveSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorNaiveSplitPanel();
            toPngTabPage = new System.Windows.Forms.TabPage();
            toPngSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ToPngSplitPanel();
            crtBlurTabPage = new System.Windows.Forms.TabPage();
            crtBlurSplitPanel1 = new XstitchXcelWinFormsLib.Panels.CrtBlurSplitPanel();
            imageToExcelTabPage = new System.Windows.Forms.TabPage();
            imageToExcelSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ImageToExcelSplitPanel();
            openFileControl1 = new XstitchXcelWinFormsLib.Controls.OpenFileControl();
            tabControl.SuspendLayout();
            createPatternTabPage.SuspendLayout();
            statsTabPage.SuspendLayout();
            findDmcColorsTabPage.SuspendLayout();
            replaceColorTabPage.SuspendLayout();
            replaceColorNaiveTabPage.SuspendLayout();
            toPngTabPage.SuspendLayout();
            crtBlurTabPage.SuspendLayout();
            imageToExcelTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(createPatternTabPage);
            tabControl.Controls.Add(statsTabPage);
            tabControl.Controls.Add(findDmcColorsTabPage);
            tabControl.Controls.Add(replaceColorTabPage);
            tabControl.Controls.Add(replaceColorNaiveTabPage);
            tabControl.Controls.Add(toPngTabPage);
            tabControl.Controls.Add(crtBlurTabPage);
            tabControl.Controls.Add(imageToExcelTabPage);
            tabControl.Location = new System.Drawing.Point(12, 37);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(762, 386);
            tabControl.TabIndex = 3;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // createPatternTabPage
            // 
            createPatternTabPage.Controls.Add(createPatternSplitPanel1);
            createPatternTabPage.Location = new System.Drawing.Point(4, 24);
            createPatternTabPage.Name = "createPatternTabPage";
            createPatternTabPage.Padding = new System.Windows.Forms.Padding(3);
            createPatternTabPage.Size = new System.Drawing.Size(754, 358);
            createPatternTabPage.TabIndex = 8;
            createPatternTabPage.Text = "Create Pattern";
            createPatternTabPage.UseVisualStyleBackColor = true;
            // 
            // createPatternSplitPanel1
            // 
            createPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            createPatternSplitPanel1.Location = new System.Drawing.Point(3, 3);
            createPatternSplitPanel1.Name = "createPatternSplitPanel1";
            createPatternSplitPanel1.Size = new System.Drawing.Size(748, 352);
            createPatternSplitPanel1.TabIndex = 0;
            // 
            // statsTabPage
            // 
            statsTabPage.Controls.Add(statsPanel1);
            statsTabPage.Location = new System.Drawing.Point(4, 24);
            statsTabPage.Name = "statsTabPage";
            statsTabPage.Padding = new System.Windows.Forms.Padding(3);
            statsTabPage.Size = new System.Drawing.Size(754, 358);
            statsTabPage.TabIndex = 9;
            statsTabPage.Text = "Stats";
            statsTabPage.UseVisualStyleBackColor = true;
            // 
            // statsPanel1
            // 
            statsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            statsPanel1.Location = new System.Drawing.Point(3, 3);
            statsPanel1.Name = "statsPanel1";
            statsPanel1.Size = new System.Drawing.Size(748, 352);
            statsPanel1.TabIndex = 0;
            // 
            // findDmcColorsTabPage
            // 
            findDmcColorsTabPage.Controls.Add(findDmcColorsSplitPanel1);
            findDmcColorsTabPage.Location = new System.Drawing.Point(4, 24);
            findDmcColorsTabPage.Name = "findDmcColorsTabPage";
            findDmcColorsTabPage.Size = new System.Drawing.Size(754, 358);
            findDmcColorsTabPage.TabIndex = 10;
            findDmcColorsTabPage.Text = "Find DMC Colors";
            findDmcColorsTabPage.UseVisualStyleBackColor = true;
            // 
            // findDmcColorsSplitPanel1
            // 
            findDmcColorsSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            findDmcColorsSplitPanel1.Location = new System.Drawing.Point(0, 0);
            findDmcColorsSplitPanel1.Name = "findDmcColorsSplitPanel1";
            findDmcColorsSplitPanel1.Size = new System.Drawing.Size(754, 358);
            findDmcColorsSplitPanel1.TabIndex = 0;
            // 
            // replaceColorTabPage
            // 
            replaceColorTabPage.Controls.Add(replaceColorInPatternSplitPanel1);
            replaceColorTabPage.Location = new System.Drawing.Point(4, 24);
            replaceColorTabPage.Name = "replaceColorTabPage";
            replaceColorTabPage.Size = new System.Drawing.Size(754, 358);
            replaceColorTabPage.TabIndex = 11;
            replaceColorTabPage.Text = "Replace Color";
            replaceColorTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorInPatternSplitPanel1
            // 
            replaceColorInPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            replaceColorInPatternSplitPanel1.Location = new System.Drawing.Point(0, 0);
            replaceColorInPatternSplitPanel1.Name = "replaceColorInPatternSplitPanel1";
            replaceColorInPatternSplitPanel1.Size = new System.Drawing.Size(754, 358);
            replaceColorInPatternSplitPanel1.TabIndex = 0;
            // 
            // replaceColorNaiveTabPage
            // 
            replaceColorNaiveTabPage.Controls.Add(replaceColorNaiveSplitPanel1);
            replaceColorNaiveTabPage.Location = new System.Drawing.Point(4, 24);
            replaceColorNaiveTabPage.Name = "replaceColorNaiveTabPage";
            replaceColorNaiveTabPage.Size = new System.Drawing.Size(754, 358);
            replaceColorNaiveTabPage.TabIndex = 12;
            replaceColorNaiveTabPage.Text = "Replace Color (naive)";
            replaceColorNaiveTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorNaiveSplitPanel1
            // 
            replaceColorNaiveSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            replaceColorNaiveSplitPanel1.Location = new System.Drawing.Point(0, 0);
            replaceColorNaiveSplitPanel1.Name = "replaceColorNaiveSplitPanel1";
            replaceColorNaiveSplitPanel1.Size = new System.Drawing.Size(754, 358);
            replaceColorNaiveSplitPanel1.TabIndex = 0;
            // 
            // toPngTabPage
            // 
            toPngTabPage.Controls.Add(toPngSplitPanel1);
            toPngTabPage.Location = new System.Drawing.Point(4, 24);
            toPngTabPage.Name = "toPngTabPage";
            toPngTabPage.Size = new System.Drawing.Size(754, 358);
            toPngTabPage.TabIndex = 13;
            toPngTabPage.Text = "To png";
            toPngTabPage.UseVisualStyleBackColor = true;
            // 
            // toPngSplitPanel1
            // 
            toPngSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            toPngSplitPanel1.Location = new System.Drawing.Point(0, 0);
            toPngSplitPanel1.Name = "toPngSplitPanel1";
            toPngSplitPanel1.Size = new System.Drawing.Size(754, 358);
            toPngSplitPanel1.TabIndex = 0;
            // 
            // crtBlurTabPage
            // 
            crtBlurTabPage.Controls.Add(crtBlurSplitPanel1);
            crtBlurTabPage.Location = new System.Drawing.Point(4, 24);
            crtBlurTabPage.Name = "crtBlurTabPage";
            crtBlurTabPage.Size = new System.Drawing.Size(754, 358);
            crtBlurTabPage.TabIndex = 14;
            crtBlurTabPage.Text = "CRT Blur";
            crtBlurTabPage.UseVisualStyleBackColor = true;
            // 
            // crtBlurSplitPanel1
            // 
            crtBlurSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            crtBlurSplitPanel1.Location = new System.Drawing.Point(0, 0);
            crtBlurSplitPanel1.Name = "crtBlurSplitPanel1";
            crtBlurSplitPanel1.Size = new System.Drawing.Size(754, 358);
            crtBlurSplitPanel1.TabIndex = 0;
            // 
            // imageToExcelTabPage
            // 
            imageToExcelTabPage.Controls.Add(imageToExcelSplitPanel1);
            imageToExcelTabPage.Location = new System.Drawing.Point(4, 24);
            imageToExcelTabPage.Name = "imageToExcelTabPage";
            imageToExcelTabPage.Size = new System.Drawing.Size(754, 358);
            imageToExcelTabPage.TabIndex = 16;
            imageToExcelTabPage.Text = "Image to Excel";
            imageToExcelTabPage.UseVisualStyleBackColor = true;
            // 
            // imageToExcelSplitPanel1
            // 
            imageToExcelSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            imageToExcelSplitPanel1.Location = new System.Drawing.Point(0, 0);
            imageToExcelSplitPanel1.Name = "imageToExcelSplitPanel1";
            imageToExcelSplitPanel1.Size = new System.Drawing.Size(754, 358);
            imageToExcelSplitPanel1.TabIndex = 0;
            // 
            // openFileControl1
            // 
            openFileControl1.DialogTitle = "Select the Excel file with your design";
            openFileControl1.FileExtension = "xlsx";
            openFileControl1.FileFilterOverride = null;
            openFileControl1.FileName = "";
            openFileControl1.FileTypeName = "Excel Spreadsheet";
            openFileControl1.LabelText = "Excel file";
            openFileControl1.Location = new System.Drawing.Point(12, 0);
            openFileControl1.Name = "openFileControl1";
            openFileControl1.Size = new System.Drawing.Size(762, 31);
            openFileControl1.TabIndex = 4;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(786, 435);
            Controls.Add(openFileControl1);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "Xstitch Xcel";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            tabControl.ResumeLayout(false);
            createPatternTabPage.ResumeLayout(false);
            statsTabPage.ResumeLayout(false);
            findDmcColorsTabPage.ResumeLayout(false);
            replaceColorTabPage.ResumeLayout(false);
            replaceColorNaiveTabPage.ResumeLayout(false);
            toPngTabPage.ResumeLayout(false);
            crtBlurTabPage.ResumeLayout(false);
            imageToExcelTabPage.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.TabPage imageToExcelTabPage;
        private XstitchXcelWinFormsLib.Panels.ImageToExcelSplitPanel imageToExcelSplitPanel1;
    }
}

