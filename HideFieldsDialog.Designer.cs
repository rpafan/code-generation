namespace CodeGeneration
{
	partial class HideFieldsDialog
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
			this.cmbTable = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listFields = new System.Windows.Forms.CheckedListBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbTable
			// 
			this.cmbTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTable.FormattingEnabled = true;
			this.cmbTable.Location = new System.Drawing.Point(116, 3);
			this.cmbTable.Name = "cmbTable";
			this.cmbTable.Size = new System.Drawing.Size(381, 21);
			this.cmbTable.TabIndex = 0;
			this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.6F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.4F));
			this.tableLayoutPanel1.Controls.Add(this.cmbTable, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.listFields, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 28);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.90323F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.09677F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 310);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(73, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Table:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(73, 47);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Fields:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// listFields
			// 
			this.listFields.CheckOnClick = true;
			this.listFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listFields.FormattingEnabled = true;
			this.listFields.Location = new System.Drawing.Point(116, 43);
			this.listFields.Name = "listFields";
			this.listFields.Size = new System.Drawing.Size(381, 264);
			this.listFields.TabIndex = 2;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(243, 364);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// HideFieldsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 399);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "HideFieldsDialog";
			this.Text = "Hide Fields";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTable;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox listFields;
		private System.Windows.Forms.Button btnApply;
	}
}