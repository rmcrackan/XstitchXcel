namespace XstitchXcelWinFormsLib.Panels
{
    partial class StatsPanel
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
            this.statsOutTb = new System.Windows.Forms.TextBox();
            this.statsUnitCb = new System.Windows.Forms.ComboBox();
            this.statsCountNum = new System.Windows.Forms.NumericUpDown();
            this.statsCountLbl = new System.Windows.Forms.Label();
            this.statsDgv = new System.Windows.Forms.DataGridView();
            this.qtyStitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minSkeins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSkeins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dmcNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dmcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statsCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // statsOutTb
            // 
            this.statsOutTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsOutTb.Location = new System.Drawing.Point(172, 328);
            this.statsOutTb.Name = "statsOutTb";
            this.statsOutTb.ReadOnly = true;
            this.statsOutTb.Size = new System.Drawing.Size(243, 23);
            this.statsOutTb.TabIndex = 9;
            // 
            // statsUnitCb
            // 
            this.statsUnitCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsUnitCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statsUnitCb.FormattingEnabled = true;
            this.statsUnitCb.Items.AddRange(new object[] {
            "inches",
            "cm"});
            this.statsUnitCb.Location = new System.Drawing.Point(106, 328);
            this.statsUnitCb.Name = "statsUnitCb";
            this.statsUnitCb.Size = new System.Drawing.Size(60, 23);
            this.statsUnitCb.TabIndex = 8;
            this.statsUnitCb.SelectedIndexChanged += new System.EventHandler(this.updateStatsOut);
            // 
            // statsCountNum
            // 
            this.statsCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsCountNum.Location = new System.Drawing.Point(52, 329);
            this.statsCountNum.Name = "statsCountNum";
            this.statsCountNum.Size = new System.Drawing.Size(48, 23);
            this.statsCountNum.TabIndex = 7;
            this.statsCountNum.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.statsCountNum.ValueChanged += new System.EventHandler(this.updateStatsOut);
            // 
            // statsCountLbl
            // 
            this.statsCountLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsCountLbl.AutoSize = true;
            this.statsCountLbl.Location = new System.Drawing.Point(3, 331);
            this.statsCountLbl.Name = "statsCountLbl";
            this.statsCountLbl.Size = new System.Drawing.Size(40, 15);
            this.statsCountLbl.TabIndex = 6;
            this.statsCountLbl.Text = "Count";
            // 
            // statsDgv
            // 
            this.statsDgv.AllowUserToAddRows = false;
            this.statsDgv.AllowUserToDeleteRows = false;
            this.statsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qtyStitches,
            this.minSkeins,
            this.maxSkeins,
            this.hex,
            this.dmcNumber,
            this.dmcName});
            this.statsDgv.EnableHeadersVisualStyles = false;
            this.statsDgv.Location = new System.Drawing.Point(3, 3);
            this.statsDgv.Name = "statsDgv";
            this.statsDgv.ReadOnly = true;
            this.statsDgv.RowHeadersVisible = false;
            this.statsDgv.RowTemplate.Height = 25;
            this.statsDgv.Size = new System.Drawing.Size(748, 318);
            this.statsDgv.TabIndex = 5;
            // 
            // qtyStitches
            // 
            this.qtyStitches.FillWeight = 93.1677F;
            this.qtyStitches.HeaderText = "# Stitches";
            this.qtyStitches.Name = "qtyStitches";
            this.qtyStitches.ReadOnly = true;
            // 
            // minSkeins
            // 
            this.minSkeins.FillWeight = 96.51846F;
            this.minSkeins.HeaderText = "Min skeins";
            this.minSkeins.Name = "minSkeins";
            this.minSkeins.ReadOnly = true;
            // 
            // maxSkeins
            // 
            this.maxSkeins.FillWeight = 99.34892F;
            this.maxSkeins.HeaderText = "Max skeins";
            this.maxSkeins.Name = "maxSkeins";
            this.maxSkeins.ReadOnly = true;
            // 
            // hex
            // 
            this.hex.FillWeight = 101.7399F;
            this.hex.HeaderText = "Hex #";
            this.hex.Name = "hex";
            this.hex.ReadOnly = true;
            // 
            // dmcNumber
            // 
            this.dmcNumber.FillWeight = 103.7595F;
            this.dmcNumber.HeaderText = "DMC #";
            this.dmcNumber.Name = "dmcNumber";
            this.dmcNumber.ReadOnly = true;
            // 
            // dmcName
            // 
            this.dmcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dmcName.FillWeight = 105.4656F;
            this.dmcName.HeaderText = "DMC name";
            this.dmcName.Name = "dmcName";
            this.dmcName.ReadOnly = true;
            // 
            // StatsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statsOutTb);
            this.Controls.Add(this.statsUnitCb);
            this.Controls.Add(this.statsCountNum);
            this.Controls.Add(this.statsCountLbl);
            this.Controls.Add(this.statsDgv);
            this.Name = "StatsPanel";
            this.Controls.SetChildIndex(this.statsDgv, 0);
            this.Controls.SetChildIndex(this.statsCountLbl, 0);
            this.Controls.SetChildIndex(this.statsCountNum, 0);
            this.Controls.SetChildIndex(this.statsUnitCb, 0);
            this.Controls.SetChildIndex(this.statsOutTb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.statsCountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statsOutTb;
        private System.Windows.Forms.ComboBox statsUnitCb;
        private System.Windows.Forms.NumericUpDown statsCountNum;
        private System.Windows.Forms.Label statsCountLbl;
        private System.Windows.Forms.DataGridView statsDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyStitches;
        private System.Windows.Forms.DataGridViewTextBoxColumn minSkeins;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSkeins;
        private System.Windows.Forms.DataGridViewTextBoxColumn hex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dmcNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dmcName;
    }
}
