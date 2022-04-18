
namespace FlossInventory
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
            this.openBtn = new System.Windows.Forms.Button();
            this.shoppingListGrp = new System.Windows.Forms.GroupBox();
            this.shoppingListAddTb = new System.Windows.Forms.TextBox();
            this.shoppingListAddBtn = new System.Windows.Forms.Button();
            this.shoppingListRemoveTb = new System.Windows.Forms.TextBox();
            this.shoppingListRemoveBtn = new System.Windows.Forms.Button();
            this.inventoryGrp = new System.Windows.Forms.GroupBox();
            this.inventoryAddTb = new System.Windows.Forms.TextBox();
            this.inventoryAddBtn = new System.Windows.Forms.Button();
            this.inventoryRemoveTb = new System.Windows.Forms.TextBox();
            this.inventoryRemoveBtn = new System.Windows.Forms.Button();
            this.inventorySearchTb = new System.Windows.Forms.TextBox();
            this.inventorySearchBtn = new System.Windows.Forms.Button();
            this.inventoryOutTb = new System.Windows.Forms.TextBox();
            this.inventoryFileSaveBtn = new System.Windows.Forms.Button();
            this.inventoryFileBtn = new System.Windows.Forms.Button();
            this.inventoryFileTb = new System.Windows.Forms.TextBox();
            this.inventoryFileLbl = new System.Windows.Forms.Label();
            this.inventoryInstructionsTb = new System.Windows.Forms.TextBox();
            this.shoppingListGrp.SuspendLayout();
            this.inventoryGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Location = new System.Drawing.Point(689, 75);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 14;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // shoppingListGrp
            // 
            this.shoppingListGrp.Controls.Add(this.shoppingListAddTb);
            this.shoppingListGrp.Controls.Add(this.shoppingListAddBtn);
            this.shoppingListGrp.Controls.Add(this.shoppingListRemoveTb);
            this.shoppingListGrp.Controls.Add(this.shoppingListRemoveBtn);
            this.shoppingListGrp.Location = new System.Drawing.Point(217, 104);
            this.shoppingListGrp.Name = "shoppingListGrp";
            this.shoppingListGrp.Size = new System.Drawing.Size(197, 113);
            this.shoppingListGrp.TabIndex = 16;
            this.shoppingListGrp.TabStop = false;
            this.shoppingListGrp.Text = "Shopping List";
            // 
            // shoppingListAddTb
            // 
            this.shoppingListAddTb.Location = new System.Drawing.Point(6, 22);
            this.shoppingListAddTb.Name = "shoppingListAddTb";
            this.shoppingListAddTb.Size = new System.Drawing.Size(100, 23);
            this.shoppingListAddTb.TabIndex = 1;
            this.shoppingListAddTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shoppingListAddTb_KeyPress);
            // 
            // shoppingListAddBtn
            // 
            this.shoppingListAddBtn.Location = new System.Drawing.Point(112, 21);
            this.shoppingListAddBtn.Name = "shoppingListAddBtn";
            this.shoppingListAddBtn.Size = new System.Drawing.Size(75, 23);
            this.shoppingListAddBtn.TabIndex = 2;
            this.shoppingListAddBtn.Text = "Add";
            this.shoppingListAddBtn.UseVisualStyleBackColor = true;
            this.shoppingListAddBtn.Click += new System.EventHandler(this.shoppingListAddBtn_Click);
            // 
            // shoppingListRemoveTb
            // 
            this.shoppingListRemoveTb.Location = new System.Drawing.Point(6, 51);
            this.shoppingListRemoveTb.Name = "shoppingListRemoveTb";
            this.shoppingListRemoveTb.Size = new System.Drawing.Size(100, 23);
            this.shoppingListRemoveTb.TabIndex = 3;
            this.shoppingListRemoveTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shoppingListRemoveTb_KeyPress);
            // 
            // shoppingListRemoveBtn
            // 
            this.shoppingListRemoveBtn.Location = new System.Drawing.Point(112, 50);
            this.shoppingListRemoveBtn.Name = "shoppingListRemoveBtn";
            this.shoppingListRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.shoppingListRemoveBtn.TabIndex = 4;
            this.shoppingListRemoveBtn.Text = "Remove";
            this.shoppingListRemoveBtn.UseVisualStyleBackColor = true;
            this.shoppingListRemoveBtn.Click += new System.EventHandler(this.shoppingListRemoveBtn_Click);
            // 
            // inventoryGrp
            // 
            this.inventoryGrp.Controls.Add(this.inventoryAddTb);
            this.inventoryGrp.Controls.Add(this.inventoryAddBtn);
            this.inventoryGrp.Controls.Add(this.inventoryRemoveTb);
            this.inventoryGrp.Controls.Add(this.inventoryRemoveBtn);
            this.inventoryGrp.Controls.Add(this.inventorySearchTb);
            this.inventoryGrp.Controls.Add(this.inventorySearchBtn);
            this.inventoryGrp.Location = new System.Drawing.Point(12, 104);
            this.inventoryGrp.Name = "inventoryGrp";
            this.inventoryGrp.Size = new System.Drawing.Size(199, 113);
            this.inventoryGrp.TabIndex = 15;
            this.inventoryGrp.TabStop = false;
            this.inventoryGrp.Text = "Inventory";
            // 
            // inventoryAddTb
            // 
            this.inventoryAddTb.Location = new System.Drawing.Point(6, 22);
            this.inventoryAddTb.Name = "inventoryAddTb";
            this.inventoryAddTb.Size = new System.Drawing.Size(100, 23);
            this.inventoryAddTb.TabIndex = 1;
            this.inventoryAddTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inventoryAddTb_KeyPress);
            // 
            // inventoryAddBtn
            // 
            this.inventoryAddBtn.Location = new System.Drawing.Point(112, 21);
            this.inventoryAddBtn.Name = "inventoryAddBtn";
            this.inventoryAddBtn.Size = new System.Drawing.Size(75, 23);
            this.inventoryAddBtn.TabIndex = 2;
            this.inventoryAddBtn.Text = "Add";
            this.inventoryAddBtn.UseVisualStyleBackColor = true;
            this.inventoryAddBtn.Click += new System.EventHandler(this.inventoryAddBtn_Click);
            // 
            // inventoryRemoveTb
            // 
            this.inventoryRemoveTb.Location = new System.Drawing.Point(6, 51);
            this.inventoryRemoveTb.Name = "inventoryRemoveTb";
            this.inventoryRemoveTb.Size = new System.Drawing.Size(100, 23);
            this.inventoryRemoveTb.TabIndex = 3;
            this.inventoryRemoveTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inventoryRemoveTb_KeyPress);
            // 
            // inventoryRemoveBtn
            // 
            this.inventoryRemoveBtn.Location = new System.Drawing.Point(112, 50);
            this.inventoryRemoveBtn.Name = "inventoryRemoveBtn";
            this.inventoryRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.inventoryRemoveBtn.TabIndex = 4;
            this.inventoryRemoveBtn.Text = "Remove";
            this.inventoryRemoveBtn.UseVisualStyleBackColor = true;
            this.inventoryRemoveBtn.Click += new System.EventHandler(this.inventoryRemoveBtn_Click);
            // 
            // inventorySearchTb
            // 
            this.inventorySearchTb.Location = new System.Drawing.Point(6, 80);
            this.inventorySearchTb.Name = "inventorySearchTb";
            this.inventorySearchTb.Size = new System.Drawing.Size(100, 23);
            this.inventorySearchTb.TabIndex = 5;
            this.inventorySearchTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inventorySearchTb_KeyPress);
            // 
            // inventorySearchBtn
            // 
            this.inventorySearchBtn.Location = new System.Drawing.Point(112, 79);
            this.inventorySearchBtn.Name = "inventorySearchBtn";
            this.inventorySearchBtn.Size = new System.Drawing.Size(75, 23);
            this.inventorySearchBtn.TabIndex = 6;
            this.inventorySearchBtn.Text = "Search";
            this.inventorySearchBtn.UseVisualStyleBackColor = true;
            this.inventorySearchBtn.Click += new System.EventHandler(this.inventorySearchBtn_Click);
            // 
            // inventoryOutTb
            // 
            this.inventoryOutTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryOutTb.Location = new System.Drawing.Point(420, 113);
            this.inventoryOutTb.Multiline = true;
            this.inventoryOutTb.Name = "inventoryOutTb";
            this.inventoryOutTb.ReadOnly = true;
            this.inventoryOutTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inventoryOutTb.Size = new System.Drawing.Size(344, 221);
            this.inventoryOutTb.TabIndex = 17;
            // 
            // inventoryFileSaveBtn
            // 
            this.inventoryFileSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryFileSaveBtn.Enabled = false;
            this.inventoryFileSaveBtn.Location = new System.Drawing.Point(572, 75);
            this.inventoryFileSaveBtn.Name = "inventoryFileSaveBtn";
            this.inventoryFileSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.inventoryFileSaveBtn.TabIndex = 13;
            this.inventoryFileSaveBtn.Text = "SAVE";
            this.inventoryFileSaveBtn.UseVisualStyleBackColor = true;
            this.inventoryFileSaveBtn.Click += new System.EventHandler(this.inventoryFileSaveBtn_Click);
            // 
            // inventoryFileBtn
            // 
            this.inventoryFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryFileBtn.Location = new System.Drawing.Point(534, 75);
            this.inventoryFileBtn.Name = "inventoryFileBtn";
            this.inventoryFileBtn.Size = new System.Drawing.Size(32, 23);
            this.inventoryFileBtn.TabIndex = 12;
            this.inventoryFileBtn.Text = "...";
            this.inventoryFileBtn.UseVisualStyleBackColor = true;
            this.inventoryFileBtn.Click += new System.EventHandler(this.inventoryFileBtn_Click);
            // 
            // inventoryFileTb
            // 
            this.inventoryFileTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryFileTb.Location = new System.Drawing.Point(46, 76);
            this.inventoryFileTb.Name = "inventoryFileTb";
            this.inventoryFileTb.Size = new System.Drawing.Size(482, 23);
            this.inventoryFileTb.TabIndex = 11;
            this.inventoryFileTb.TextChanged += new System.EventHandler(this.inventoryFileTb_TextChanged);
            // 
            // inventoryFileLbl
            // 
            this.inventoryFileLbl.AutoSize = true;
            this.inventoryFileLbl.Location = new System.Drawing.Point(12, 79);
            this.inventoryFileLbl.Name = "inventoryFileLbl";
            this.inventoryFileLbl.Size = new System.Drawing.Size(28, 15);
            this.inventoryFileLbl.TabIndex = 10;
            this.inventoryFileLbl.Text = "File:";
            // 
            // inventoryInstructionsTb
            // 
            this.inventoryInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryInstructionsTb.Location = new System.Drawing.Point(12, 12);
            this.inventoryInstructionsTb.Multiline = true;
            this.inventoryInstructionsTb.Name = "inventoryInstructionsTb";
            this.inventoryInstructionsTb.ReadOnly = true;
            this.inventoryInstructionsTb.Size = new System.Drawing.Size(752, 57);
            this.inventoryInstructionsTb.TabIndex = 9;
            this.inventoryInstructionsTb.Text = "Inventory is kept in spreadsheet for easy sharing.\r\nInventory: Add/remove colors." +
    " Search.\r\nShopping list: Add/remove. View.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 346);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.shoppingListGrp);
            this.Controls.Add(this.inventoryGrp);
            this.Controls.Add(this.inventoryOutTb);
            this.Controls.Add(this.inventoryFileSaveBtn);
            this.Controls.Add(this.inventoryFileBtn);
            this.Controls.Add(this.inventoryFileTb);
            this.Controls.Add(this.inventoryFileLbl);
            this.Controls.Add(this.inventoryInstructionsTb);
            this.Name = "Form1";
            this.Text = "FlossInventory";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.shoppingListGrp.ResumeLayout(false);
            this.shoppingListGrp.PerformLayout();
            this.inventoryGrp.ResumeLayout(false);
            this.inventoryGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button openBtn;
		private System.Windows.Forms.GroupBox shoppingListGrp;
		private System.Windows.Forms.TextBox shoppingListAddTb;
		private System.Windows.Forms.Button shoppingListAddBtn;
		private System.Windows.Forms.TextBox shoppingListRemoveTb;
		private System.Windows.Forms.Button shoppingListRemoveBtn;
		private System.Windows.Forms.GroupBox inventoryGrp;
		private System.Windows.Forms.TextBox inventoryAddTb;
		private System.Windows.Forms.Button inventoryAddBtn;
		private System.Windows.Forms.TextBox inventoryRemoveTb;
		private System.Windows.Forms.Button inventoryRemoveBtn;
		private System.Windows.Forms.TextBox inventorySearchTb;
		private System.Windows.Forms.Button inventorySearchBtn;
		private System.Windows.Forms.TextBox inventoryOutTb;
		private System.Windows.Forms.Button inventoryFileSaveBtn;
		private System.Windows.Forms.Button inventoryFileBtn;
		private System.Windows.Forms.TextBox inventoryFileTb;
		private System.Windows.Forms.Label inventoryFileLbl;
		private System.Windows.Forms.TextBox inventoryInstructionsTb;
	}
}

