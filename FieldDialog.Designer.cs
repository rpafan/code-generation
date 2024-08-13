namespace CodeGeneration
{
	partial class FieldDialog
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnContinue = new System.Windows.Forms.Button();
			this.txtFields = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnContinue);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 403);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 47);
			this.panel1.TabIndex = 0;
			// 
			// btnContinue
			// 
			this.btnContinue.Location = new System.Drawing.Point(360, 12);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(75, 23);
			this.btnContinue.TabIndex = 0;
			this.btnContinue.Text = "Continue";
			this.btnContinue.UseVisualStyleBackColor = true;
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// txtFields
			// 
			this.txtFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFields.Location = new System.Drawing.Point(0, 0);
			this.txtFields.Name = "txtFields";
			this.txtFields.Size = new System.Drawing.Size(800, 403);
			this.txtFields.TabIndex = 1;
			this.txtFields.Text = "";
			// 
			// FieldDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtFields);
			this.Controls.Add(this.panel1);
			this.Name = "FieldDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fields with Data Types";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox txtFields;
		private System.Windows.Forms.Button btnContinue;
	}
}