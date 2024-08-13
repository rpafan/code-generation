namespace CodeGeneration
{
	partial class Form1
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.pnlDataModel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtModelsFile = new System.Windows.Forms.TextBox();
			this.btnFile = new System.Windows.Forms.Button();
			this.pnlMetaData = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.btnMetaSave = new System.Windows.Forms.Button();
			this.btnMetaFile = new System.Windows.Forms.Button();
			this.txtMetaFile = new System.Windows.Forms.TextBox();
			this.btnSyncMeta = new System.Windows.Forms.Button();
			this.btnApplyChanges = new System.Windows.Forms.Button();
			this.btnSyncModels = new System.Windows.Forms.Button();
			this.btnHideFields = new System.Windows.Forms.Button();
			this.btnGPT = new System.Windows.Forms.Button();
			this.btnGenerateMeta = new System.Windows.Forms.Button();
			this.btnMetaApplyChanges = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnMetaApplyChanges);
			this.splitContainer1.Panel2.Controls.Add(this.btnSyncMeta);
			this.splitContainer1.Panel2.Controls.Add(this.btnApplyChanges);
			this.splitContainer1.Panel2.Controls.Add(this.btnSyncModels);
			this.splitContainer1.Panel2.Controls.Add(this.btnHideFields);
			this.splitContainer1.Panel2.Controls.Add(this.btnGPT);
			this.splitContainer1.Panel2.Controls.Add(this.btnGenerateMeta);
			this.splitContainer1.Size = new System.Drawing.Size(1678, 833);
			this.splitContainer1.SplitterDistance = 686;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.pnlDataModel);
			this.splitContainer2.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pnlMetaData);
			this.splitContainer2.Panel2.Controls.Add(this.panel2);
			this.splitContainer2.Size = new System.Drawing.Size(1678, 686);
			this.splitContainer2.SplitterDistance = 834;
			this.splitContainer2.TabIndex = 0;
			// 
			// pnlDataModel
			// 
			this.pnlDataModel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDataModel.Location = new System.Drawing.Point(0, 42);
			this.pnlDataModel.Name = "pnlDataModel";
			this.pnlDataModel.Size = new System.Drawing.Size(834, 644);
			this.pnlDataModel.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.txtModelsFile);
			this.panel1.Controls.Add(this.btnFile);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(834, 42);
			this.panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Data Model:";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(757, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtModelsFile
			// 
			this.txtModelsFile.Location = new System.Drawing.Point(74, 12);
			this.txtModelsFile.Name = "txtModelsFile";
			this.txtModelsFile.ReadOnly = true;
			this.txtModelsFile.Size = new System.Drawing.Size(550, 20);
			this.txtModelsFile.TabIndex = 0;
			this.txtModelsFile.Text = "D:\\Dev\\dbm.xml";
			// 
			// btnFile
			// 
			this.btnFile.Location = new System.Drawing.Point(633, 10);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(75, 23);
			this.btnFile.TabIndex = 1;
			this.btnFile.Text = "Select File...";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// pnlMetaData
			// 
			this.pnlMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMetaData.Location = new System.Drawing.Point(0, 42);
			this.pnlMetaData.Name = "pnlMetaData";
			this.pnlMetaData.Size = new System.Drawing.Size(840, 644);
			this.pnlMetaData.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btnMetaSave);
			this.panel2.Controls.Add(this.btnMetaFile);
			this.panel2.Controls.Add(this.txtMetaFile);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(840, 42);
			this.panel2.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "MetaData:";
			// 
			// btnMetaSave
			// 
			this.btnMetaSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMetaSave.Location = new System.Drawing.Point(762, 10);
			this.btnMetaSave.Name = "btnMetaSave";
			this.btnMetaSave.Size = new System.Drawing.Size(75, 23);
			this.btnMetaSave.TabIndex = 5;
			this.btnMetaSave.Text = "Save";
			this.btnMetaSave.UseVisualStyleBackColor = true;
			this.btnMetaSave.Click += new System.EventHandler(this.btnMetaSave_Click);
			// 
			// btnMetaFile
			// 
			this.btnMetaFile.Location = new System.Drawing.Point(619, 10);
			this.btnMetaFile.Name = "btnMetaFile";
			this.btnMetaFile.Size = new System.Drawing.Size(75, 23);
			this.btnMetaFile.TabIndex = 4;
			this.btnMetaFile.Text = "Select File...";
			this.btnMetaFile.UseVisualStyleBackColor = true;
			this.btnMetaFile.Click += new System.EventHandler(this.btnMetaFile_Click);
			// 
			// txtMetaFile
			// 
			this.txtMetaFile.Location = new System.Drawing.Point(63, 12);
			this.txtMetaFile.Name = "txtMetaFile";
			this.txtMetaFile.ReadOnly = true;
			this.txtMetaFile.Size = new System.Drawing.Size(550, 20);
			this.txtMetaFile.TabIndex = 3;
			// 
			// btnSyncMeta
			// 
			this.btnSyncMeta.Location = new System.Drawing.Point(163, 32);
			this.btnSyncMeta.Name = "btnSyncMeta";
			this.btnSyncMeta.Size = new System.Drawing.Size(93, 23);
			this.btnSyncMeta.TabIndex = 5;
			this.btnSyncMeta.Text = "Sync Meta";
			this.btnSyncMeta.UseVisualStyleBackColor = true;
			this.btnSyncMeta.Click += new System.EventHandler(this.btnSyncMeta_Click);
			// 
			// btnApplyChanges
			// 
			this.btnApplyChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnApplyChanges.Location = new System.Drawing.Point(262, 3);
			this.btnApplyChanges.Name = "btnApplyChanges";
			this.btnApplyChanges.Size = new System.Drawing.Size(93, 23);
			this.btnApplyChanges.TabIndex = 0;
			this.btnApplyChanges.Text = "Apply Changes";
			this.btnApplyChanges.UseVisualStyleBackColor = true;
			this.btnApplyChanges.Click += new System.EventHandler(this.btnApplyChanges_Click);
			// 
			// btnSyncModels
			// 
			this.btnSyncModels.Location = new System.Drawing.Point(1021, 3);
			this.btnSyncModels.Name = "btnSyncModels";
			this.btnSyncModels.Size = new System.Drawing.Size(93, 23);
			this.btnSyncModels.TabIndex = 2;
			this.btnSyncModels.Text = "Sync Models";
			this.btnSyncModels.UseVisualStyleBackColor = true;
			this.btnSyncModels.Click += new System.EventHandler(this.btnSyncModels_Click);
			// 
			// btnHideFields
			// 
			this.btnHideFields.Location = new System.Drawing.Point(163, 3);
			this.btnHideFields.Name = "btnHideFields";
			this.btnHideFields.Size = new System.Drawing.Size(93, 23);
			this.btnHideFields.TabIndex = 4;
			this.btnHideFields.Text = "Hide Fields";
			this.btnHideFields.UseVisualStyleBackColor = true;
			this.btnHideFields.Click += new System.EventHandler(this.btnHideFields_Click);
			// 
			// btnGPT
			// 
			this.btnGPT.Location = new System.Drawing.Point(64, 3);
			this.btnGPT.Name = "btnGPT";
			this.btnGPT.Size = new System.Drawing.Size(93, 23);
			this.btnGPT.TabIndex = 1;
			this.btnGPT.Text = "Send to GPT";
			this.btnGPT.UseVisualStyleBackColor = true;
			this.btnGPT.Click += new System.EventHandler(this.btnGPT_Click);
			// 
			// btnGenerateMeta
			// 
			this.btnGenerateMeta.Location = new System.Drawing.Point(64, 32);
			this.btnGenerateMeta.Name = "btnGenerateMeta";
			this.btnGenerateMeta.Size = new System.Drawing.Size(93, 23);
			this.btnGenerateMeta.TabIndex = 0;
			this.btnGenerateMeta.Text = "Generate Meta";
			this.btnGenerateMeta.UseVisualStyleBackColor = true;
			this.btnGenerateMeta.Click += new System.EventHandler(this.btnGenerateMeta_Click);
			// 
			// btnMetaApplyChanges
			// 
			this.btnMetaApplyChanges.Location = new System.Drawing.Point(1021, 32);
			this.btnMetaApplyChanges.Name = "btnMetaApplyChanges";
			this.btnMetaApplyChanges.Size = new System.Drawing.Size(93, 23);
			this.btnMetaApplyChanges.TabIndex = 6;
			this.btnMetaApplyChanges.Text = "Apply Changes";
			this.btnMetaApplyChanges.UseVisualStyleBackColor = true;
			this.btnMetaApplyChanges.Click += new System.EventHandler(this.btnMetaApplyChanges_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1678, 833);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Code Generation";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnFile;
		private System.Windows.Forms.TextBox txtModelsFile;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlDataModel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnlMetaData;
		private System.Windows.Forms.Button btnGenerateMeta;
		private System.Windows.Forms.Button btnGPT;
		private System.Windows.Forms.Button btnSyncModels;
		private System.Windows.Forms.Button btnMetaFile;
		private System.Windows.Forms.TextBox txtMetaFile;
		private System.Windows.Forms.Button btnHideFields;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnMetaSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnApplyChanges;
		private System.Windows.Forms.Button btnSyncMeta;
		private System.Windows.Forms.Button btnMetaApplyChanges;
	}
}

