namespace CodeGeneration
{
	partial class SelectTablesDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listTables = new System.Windows.Forms.CheckedListBox();
			this.cbCreateTables = new System.Windows.Forms.CheckBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listTables
			// 
			this.listTables.CheckOnClick = true;
			this.listTables.FormattingEnabled = true;
			this.listTables.Location = new System.Drawing.Point(12, 12);
			this.listTables.Name = "listTables";
			this.listTables.Size = new System.Drawing.Size(378, 304);
			this.listTables.TabIndex = 0;
			// 
			// cbCreateTables
			// 
			this.cbCreateTables.AutoSize = true;
			this.cbCreateTables.Checked = true;
			this.cbCreateTables.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCreateTables.Location = new System.Drawing.Point(12, 363);
			this.cbCreateTables.Name = "cbCreateTables";
			this.cbCreateTables.Size = new System.Drawing.Size(92, 17);
			this.cbCreateTables.TabIndex = 1;
			this.cbCreateTables.Text = "Create Tables";
			this.cbCreateTables.UseVisualStyleBackColor = true;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(161, 393);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Location = new System.Drawing.Point(12, 322);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
			this.btnSelectAll.TabIndex = 3;
			this.btnSelectAll.Text = "Select All";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// SelectTablesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(407, 428);
			this.Controls.Add(this.btnSelectAll);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.cbCreateTables);
			this.Controls.Add(this.listTables);
			this.Name = "SelectTablesDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Tables";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox listTables;
		private System.Windows.Forms.CheckBox cbCreateTables;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnSelectAll;
	}
}