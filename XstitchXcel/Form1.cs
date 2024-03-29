﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelWinFormsLib;
using XstitchXcelWinFormsLib.Panels;

namespace XstitchXcel
{
    public partial class Form1 : Form, IMasterForm<Control>
    {
        #region IMasterForm impl
        public event EventHandler NewExcelFileSelected
        {
            add => this.openFileControl1.FileNameChanged += value;
            remove => this.openFileControl1.FileNameChanged -= value;
        }

        public string FileName
        {
            get => this.openFileControl1.FileName;
            set => this.openFileControl1.FileName = value;
        }

        public Control GetInstance() => this;

        public Pattern GetPattern() => Configuration.GetPattern(FileName);
        #endregion

        public Form1() => InitializeComponent();

        private Dictionary<TabPage, XstitchXcelWinFormsLib.Panels._ToolControlsBase> tabControlsMap { get; } = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            // register all tool controls, whether or not they are contained by a tab page
            foreach (var tc in this.GetChildrenByType<_ToolControlsBase>())
                tc.RegisterMasterForm(this);

            // build map
            foreach (var tab in this.tabControl.TabPages.Cast<TabPage>())
            {
                var tc = tab.GetChildrenByType<_ToolControlsBase>().FirstOrDefault();
                if (tc != default)
                    tabControlsMap.Add(tab, tc);
            }

            TabControl_SelectedIndexChanged();
            this.EnableUI();
        }

        private void TabControl_SelectedIndexChanged(object sender = null, EventArgs e = null)
            => this.openFileControl1.Enabled = tabControlsMap.TryGetValue(this.tabControl.SelectedTab, out var toolControls) && toolControls.UseGlobalExcelFile;

        #region drag + drop
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (!this.openFileControl1.Enabled)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (!this.openFileControl1.Enabled)
                return;

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var xlsx = files.FirstOrDefault(f => Path.GetExtension(f).Trim('.') == "xlsx");
            if (xlsx is not null)
                this.openFileControl1.FileName = xlsx;
        }
        #endregion
    }
}
