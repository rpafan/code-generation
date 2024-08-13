namespace CodeGeneration
{
	partial class GptDialog
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
			this.txtPrompt = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtPrompt
			// 
			this.txtPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPrompt.Location = new System.Drawing.Point(0, 0);
			this.txtPrompt.Name = "txtPrompt";
			this.txtPrompt.Size = new System.Drawing.Size(800, 450);
			this.txtPrompt.TabIndex = 0;
			this.txtPrompt.Text = "";
			// 
			// GptDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtPrompt);
			this.Name = "GptDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GptDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtPrompt;
	}
}