
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
            openBtn = new System.Windows.Forms.Button();
            shoppingListGrp = new System.Windows.Forms.GroupBox();
            shoppingListAllDmcBtn = new System.Windows.Forms.Button();
            shoppingListAddTb = new System.Windows.Forms.TextBox();
            shoppingListAddBtn = new System.Windows.Forms.Button();
            shoppingListRemoveTb = new System.Windows.Forms.TextBox();
            shoppingListRemoveBtn = new System.Windows.Forms.Button();
            inventoryGrp = new System.Windows.Forms.GroupBox();
            inventoryAddTb = new System.Windows.Forms.TextBox();
            inventoryAddBtn = new System.Windows.Forms.Button();
            inventoryRemoveTb = new System.Windows.Forms.TextBox();
            inventoryRemoveBtn = new System.Windows.Forms.Button();
            inventorySearchTb = new System.Windows.Forms.TextBox();
            inventorySearchBtn = new System.Windows.Forms.Button();
            inventoryOutTb = new System.Windows.Forms.TextBox();
            inventoryFileSaveBtn = new System.Windows.Forms.Button();
            inventoryFileBtn = new System.Windows.Forms.Button();
            inventoryFileTb = new System.Windows.Forms.TextBox();
            inventoryFileLbl = new System.Windows.Forms.Label();
            inventoryInstructionsTb = new System.Windows.Forms.TextBox();
            bulkInventoryAddGrp = new System.Windows.Forms.GroupBox();
            bulkInventoryAddBtn = new System.Windows.Forms.Button();
            bulkInventoryAddTb = new System.Windows.Forms.TextBox();
            inventoryOutBtn = new System.Windows.Forms.Button();
            shoppingListGrp.SuspendLayout();
            inventoryGrp.SuspendLayout();
            bulkInventoryAddGrp.SuspendLayout();
            SuspendLayout();
            // 
            // openBtn
            // 
            openBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            openBtn.Location = new System.Drawing.Point(689, 75);
            openBtn.Name = "openBtn";
            openBtn.Size = new System.Drawing.Size(75, 23);
            openBtn.TabIndex = 14;
            openBtn.Text = "Open";
            openBtn.UseVisualStyleBackColor = true;
            openBtn.Click += openBtn_Click;
            // 
            // shoppingListGrp
            // 
            shoppingListGrp.Controls.Add(shoppingListAllDmcBtn);
            shoppingListGrp.Controls.Add(shoppingListAddTb);
            shoppingListGrp.Controls.Add(shoppingListAddBtn);
            shoppingListGrp.Controls.Add(shoppingListRemoveTb);
            shoppingListGrp.Controls.Add(shoppingListRemoveBtn);
            shoppingListGrp.Location = new System.Drawing.Point(217, 104);
            shoppingListGrp.Name = "shoppingListGrp";
            shoppingListGrp.Size = new System.Drawing.Size(197, 113);
            shoppingListGrp.TabIndex = 16;
            shoppingListGrp.TabStop = false;
            shoppingListGrp.Text = "Shopping List";
            // 
            // shoppingListAllDmcBtn
            // 
            shoppingListAllDmcBtn.Location = new System.Drawing.Point(6, 80);
            shoppingListAllDmcBtn.Name = "shoppingListAllDmcBtn";
            shoppingListAllDmcBtn.Size = new System.Drawing.Size(181, 23);
            shoppingListAllDmcBtn.TabIndex = 5;
            shoppingListAllDmcBtn.Text = "Show missing DMC colors";
            shoppingListAllDmcBtn.UseVisualStyleBackColor = true;
            shoppingListAllDmcBtn.Click += shoppingListAllDmcBtn_Click;
            // 
            // shoppingListAddTb
            // 
            shoppingListAddTb.Location = new System.Drawing.Point(6, 22);
            shoppingListAddTb.Name = "shoppingListAddTb";
            shoppingListAddTb.Size = new System.Drawing.Size(100, 23);
            shoppingListAddTb.TabIndex = 1;
            shoppingListAddTb.KeyPress += shoppingListAddTb_KeyPress;
            // 
            // shoppingListAddBtn
            // 
            shoppingListAddBtn.Location = new System.Drawing.Point(112, 21);
            shoppingListAddBtn.Name = "shoppingListAddBtn";
            shoppingListAddBtn.Size = new System.Drawing.Size(75, 23);
            shoppingListAddBtn.TabIndex = 2;
            shoppingListAddBtn.Text = "Add";
            shoppingListAddBtn.UseVisualStyleBackColor = true;
            shoppingListAddBtn.Click += shoppingListAddBtn_Click;
            // 
            // shoppingListRemoveTb
            // 
            shoppingListRemoveTb.Location = new System.Drawing.Point(6, 51);
            shoppingListRemoveTb.Name = "shoppingListRemoveTb";
            shoppingListRemoveTb.Size = new System.Drawing.Size(100, 23);
            shoppingListRemoveTb.TabIndex = 3;
            shoppingListRemoveTb.KeyPress += shoppingListRemoveTb_KeyPress;
            // 
            // shoppingListRemoveBtn
            // 
            shoppingListRemoveBtn.Location = new System.Drawing.Point(112, 50);
            shoppingListRemoveBtn.Name = "shoppingListRemoveBtn";
            shoppingListRemoveBtn.Size = new System.Drawing.Size(75, 23);
            shoppingListRemoveBtn.TabIndex = 4;
            shoppingListRemoveBtn.Text = "Remove";
            shoppingListRemoveBtn.UseVisualStyleBackColor = true;
            shoppingListRemoveBtn.Click += shoppingListRemoveBtn_Click;
            // 
            // inventoryGrp
            // 
            inventoryGrp.Controls.Add(inventoryAddTb);
            inventoryGrp.Controls.Add(inventoryAddBtn);
            inventoryGrp.Controls.Add(inventoryRemoveTb);
            inventoryGrp.Controls.Add(inventoryRemoveBtn);
            inventoryGrp.Controls.Add(inventorySearchTb);
            inventoryGrp.Controls.Add(inventorySearchBtn);
            inventoryGrp.Location = new System.Drawing.Point(12, 104);
            inventoryGrp.Name = "inventoryGrp";
            inventoryGrp.Size = new System.Drawing.Size(199, 113);
            inventoryGrp.TabIndex = 15;
            inventoryGrp.TabStop = false;
            inventoryGrp.Text = "Inventory";
            // 
            // inventoryAddTb
            // 
            inventoryAddTb.Location = new System.Drawing.Point(6, 22);
            inventoryAddTb.Name = "inventoryAddTb";
            inventoryAddTb.Size = new System.Drawing.Size(100, 23);
            inventoryAddTb.TabIndex = 1;
            inventoryAddTb.KeyPress += inventoryAddTb_KeyPress;
            // 
            // inventoryAddBtn
            // 
            inventoryAddBtn.Location = new System.Drawing.Point(112, 21);
            inventoryAddBtn.Name = "inventoryAddBtn";
            inventoryAddBtn.Size = new System.Drawing.Size(75, 23);
            inventoryAddBtn.TabIndex = 2;
            inventoryAddBtn.Text = "Add";
            inventoryAddBtn.UseVisualStyleBackColor = true;
            inventoryAddBtn.Click += inventoryAddBtn_Click;
            // 
            // inventoryRemoveTb
            // 
            inventoryRemoveTb.Location = new System.Drawing.Point(6, 51);
            inventoryRemoveTb.Name = "inventoryRemoveTb";
            inventoryRemoveTb.Size = new System.Drawing.Size(100, 23);
            inventoryRemoveTb.TabIndex = 3;
            inventoryRemoveTb.KeyPress += inventoryRemoveTb_KeyPress;
            // 
            // inventoryRemoveBtn
            // 
            inventoryRemoveBtn.Location = new System.Drawing.Point(112, 50);
            inventoryRemoveBtn.Name = "inventoryRemoveBtn";
            inventoryRemoveBtn.Size = new System.Drawing.Size(75, 23);
            inventoryRemoveBtn.TabIndex = 4;
            inventoryRemoveBtn.Text = "Remove";
            inventoryRemoveBtn.UseVisualStyleBackColor = true;
            inventoryRemoveBtn.Click += inventoryRemoveBtn_Click;
            // 
            // inventorySearchTb
            // 
            inventorySearchTb.Location = new System.Drawing.Point(6, 80);
            inventorySearchTb.Name = "inventorySearchTb";
            inventorySearchTb.Size = new System.Drawing.Size(100, 23);
            inventorySearchTb.TabIndex = 5;
            inventorySearchTb.KeyPress += inventorySearchTb_KeyPress;
            // 
            // inventorySearchBtn
            // 
            inventorySearchBtn.Location = new System.Drawing.Point(112, 79);
            inventorySearchBtn.Name = "inventorySearchBtn";
            inventorySearchBtn.Size = new System.Drawing.Size(75, 23);
            inventorySearchBtn.TabIndex = 6;
            inventorySearchBtn.Text = "Search";
            inventorySearchBtn.UseVisualStyleBackColor = true;
            inventorySearchBtn.Click += inventorySearchBtn_Click;
            // 
            // inventoryOutTb
            // 
            inventoryOutTb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            inventoryOutTb.Location = new System.Drawing.Point(420, 113);
            inventoryOutTb.Multiline = true;
            inventoryOutTb.Name = "inventoryOutTb";
            inventoryOutTb.ReadOnly = true;
            inventoryOutTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            inventoryOutTb.Size = new System.Drawing.Size(344, 238);
            inventoryOutTb.TabIndex = 17;
            // 
            // inventoryFileSaveBtn
            // 
            inventoryFileSaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            inventoryFileSaveBtn.Enabled = false;
            inventoryFileSaveBtn.Location = new System.Drawing.Point(572, 75);
            inventoryFileSaveBtn.Name = "inventoryFileSaveBtn";
            inventoryFileSaveBtn.Size = new System.Drawing.Size(75, 23);
            inventoryFileSaveBtn.TabIndex = 13;
            inventoryFileSaveBtn.Text = "SAVE";
            inventoryFileSaveBtn.UseVisualStyleBackColor = true;
            inventoryFileSaveBtn.Click += inventoryFileSaveBtn_Click;
            // 
            // inventoryFileBtn
            // 
            inventoryFileBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            inventoryFileBtn.Location = new System.Drawing.Point(534, 75);
            inventoryFileBtn.Name = "inventoryFileBtn";
            inventoryFileBtn.Size = new System.Drawing.Size(32, 23);
            inventoryFileBtn.TabIndex = 12;
            inventoryFileBtn.Text = "...";
            inventoryFileBtn.UseVisualStyleBackColor = true;
            inventoryFileBtn.Click += inventoryFileBtn_Click;
            // 
            // inventoryFileTb
            // 
            inventoryFileTb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            inventoryFileTb.Location = new System.Drawing.Point(46, 76);
            inventoryFileTb.Name = "inventoryFileTb";
            inventoryFileTb.Size = new System.Drawing.Size(482, 23);
            inventoryFileTb.TabIndex = 11;
            inventoryFileTb.TextChanged += inventoryFileTb_TextChanged;
            // 
            // inventoryFileLbl
            // 
            inventoryFileLbl.AutoSize = true;
            inventoryFileLbl.Location = new System.Drawing.Point(12, 79);
            inventoryFileLbl.Name = "inventoryFileLbl";
            inventoryFileLbl.Size = new System.Drawing.Size(28, 15);
            inventoryFileLbl.TabIndex = 10;
            inventoryFileLbl.Text = "File:";
            // 
            // inventoryInstructionsTb
            // 
            inventoryInstructionsTb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            inventoryInstructionsTb.Location = new System.Drawing.Point(12, 12);
            inventoryInstructionsTb.Multiline = true;
            inventoryInstructionsTb.Name = "inventoryInstructionsTb";
            inventoryInstructionsTb.ReadOnly = true;
            inventoryInstructionsTb.Size = new System.Drawing.Size(752, 57);
            inventoryInstructionsTb.TabIndex = 9;
            inventoryInstructionsTb.Text = "Inventory is kept in spreadsheet for easy sharing.\r\nInventory: Add/remove colors. Search.\r\nShopping list: Add/remove. View.";
            // 
            // bulkInventoryAddGrp
            // 
            bulkInventoryAddGrp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bulkInventoryAddGrp.Controls.Add(bulkInventoryAddBtn);
            bulkInventoryAddGrp.Controls.Add(bulkInventoryAddTb);
            bulkInventoryAddGrp.Location = new System.Drawing.Point(12, 223);
            bulkInventoryAddGrp.Name = "bulkInventoryAddGrp";
            bulkInventoryAddGrp.Size = new System.Drawing.Size(402, 163);
            bulkInventoryAddGrp.TabIndex = 18;
            bulkInventoryAddGrp.TabStop = false;
            bulkInventoryAddGrp.Text = "Bulk Inventory";
            // 
            // bulkInventoryAddBtn
            // 
            bulkInventoryAddBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bulkInventoryAddBtn.Location = new System.Drawing.Point(6, 134);
            bulkInventoryAddBtn.Name = "bulkInventoryAddBtn";
            bulkInventoryAddBtn.Size = new System.Drawing.Size(75, 23);
            bulkInventoryAddBtn.TabIndex = 1;
            bulkInventoryAddBtn.Text = "Add";
            bulkInventoryAddBtn.UseVisualStyleBackColor = true;
            bulkInventoryAddBtn.Click += bulkInventoryAddBtn_Click;
            // 
            // bulkInventoryAddTb
            // 
            bulkInventoryAddTb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bulkInventoryAddTb.Location = new System.Drawing.Point(6, 22);
            bulkInventoryAddTb.Multiline = true;
            bulkInventoryAddTb.Name = "bulkInventoryAddTb";
            bulkInventoryAddTb.Size = new System.Drawing.Size(386, 106);
            bulkInventoryAddTb.TabIndex = 0;
            // 
            // inventoryOutBtn
            // 
            inventoryOutBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            inventoryOutBtn.Location = new System.Drawing.Point(420, 357);
            inventoryOutBtn.Name = "inventoryOutBtn";
            inventoryOutBtn.Size = new System.Drawing.Size(108, 23);
            inventoryOutBtn.TabIndex = 19;
            inventoryOutBtn.Text = "Clear output";
            inventoryOutBtn.UseVisualStyleBackColor = true;
            inventoryOutBtn.Click += inventoryOutBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(776, 398);
            Controls.Add(inventoryOutBtn);
            Controls.Add(bulkInventoryAddGrp);
            Controls.Add(openBtn);
            Controls.Add(shoppingListGrp);
            Controls.Add(inventoryGrp);
            Controls.Add(inventoryOutTb);
            Controls.Add(inventoryFileSaveBtn);
            Controls.Add(inventoryFileBtn);
            Controls.Add(inventoryFileTb);
            Controls.Add(inventoryFileLbl);
            Controls.Add(inventoryInstructionsTb);
            Name = "Form1";
            Text = "FlossInventory";
            Load += Form1_Load;
            shoppingListGrp.ResumeLayout(false);
            shoppingListGrp.PerformLayout();
            inventoryGrp.ResumeLayout(false);
            inventoryGrp.PerformLayout();
            bulkInventoryAddGrp.ResumeLayout(false);
            bulkInventoryAddGrp.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.GroupBox bulkInventoryAddGrp;
        private System.Windows.Forms.Button bulkInventoryAddBtn;
        private System.Windows.Forms.TextBox bulkInventoryAddTb;
        private System.Windows.Forms.Button inventoryOutBtn;
        private System.Windows.Forms.Button shoppingListAllDmcBtn;
    }
}

