using Efficiency.DevTools.CodeAnalysis;
using ScintillaNET;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CodeGeneration
{
	public partial class Form1 : Form
	{
		private Scintilla ctlLeftTextEditor;
		private Scintilla ctlRightTextEditor;

		private string dataModelsFile = "";
		private string metaFile = "";

		public Form1()
		{
			InitializeComponent();

			ctlLeftTextEditor = ScintillaEditor.Create();
			ctlLeftTextEditor.BorderStyle = ScintillaNET.BorderStyle.None;
			ctlLeftTextEditor.Dock = DockStyle.Fill;
			ctlLeftTextEditor.TabStop = true;
			ctlLeftTextEditor.TabIndex = 0;
			pnlDataModel.Controls.Add(ctlLeftTextEditor);

			ctlRightTextEditor = ScintillaEditor.Create();
			ctlRightTextEditor.BorderStyle = ScintillaNET.BorderStyle.None;
			ctlRightTextEditor.Dock = DockStyle.Fill;
			ctlRightTextEditor.TabStop = true;
			ctlRightTextEditor.TabIndex = 0;
			pnlMetaData.Controls.Add(ctlRightTextEditor);

			dataModelsFile = txtModelsFile.Text;
			ctlLeftTextEditor.Text = File.ReadAllText(dataModelsFile);
		}

		private void btnFile_Click(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName)) 
				{
					txtModelsFile.Text = dialog.FileName;
					ctlLeftTextEditor.Text = File.ReadAllText(dialog.FileName);
					dataModelsFile = dialog.FileName;
				}
			}
		}

		private void btnMetaFile_Click(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
				{
					txtMetaFile.Text = dialog.FileName;
					ctlRightTextEditor.Text = File.ReadAllText(dialog.FileName);
					metaFile = dialog.FileName;
				}
			}
		}

		private void btnGenerateMeta_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(dataModelsFile))
				return;

			string fieldsXml = "";

			using (var dialog = new FieldDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK)
					fieldsXml = dialog.FieldsXml;
			}

			if (string.IsNullOrEmpty(fieldsXml))
				return;

			ctlRightTextEditor.Text = CodeGenerator.GenerateMeta(dataModelsFile, ctlLeftTextEditor.Text, fieldsXml);
			ctlLeftTextEditor.Text = File.ReadAllText(dataModelsFile);
		}

		private void btnGPT_Click(object sender, EventArgs e)
		{
			(string fieldsXml, _) = CodeGenerator.GetFields(ctlLeftTextEditor.Text);
			using (var dialog = new GptDialog(fieldsXml))
			{
				dialog.ShowDialog();
			}
		}

		private void btnSyncModels_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(metaFile) || string.IsNullOrEmpty(dataModelsFile))
				return;

			using (var dialog = new SelectTablesDialog(ctlRightTextEditor.Text, true))
			{
				if (dialog.ShowDialog() == DialogResult.OK)
					ctlLeftTextEditor.Text = CodeSynchronizer.SyncModels(ctlRightTextEditor.Text, dialog.Tables, dialog.CreateTables, ctlLeftTextEditor.Text);
			}
		}

		private void btnHideFields_Click(object sender, EventArgs e)
		{
			using (var dialog = new HideFieldsDialog(ctlLeftTextEditor.Text))
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ctlLeftTextEditor.Text = CodeSynchronizer.HideFields(ctlLeftTextEditor.Text, dialog.Table, dialog.Fields);
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			File.WriteAllText(txtModelsFile.Text, ctlLeftTextEditor.Text);
		}

		private void btnMetaSave_Click(object sender, EventArgs e)
		{
			File.WriteAllText(txtMetaFile.Text, ctlRightTextEditor.Text);
		}

		private void btnApplyChanges_Click(object sender, EventArgs e)
		{
			ctlLeftTextEditor.Text = CodeSynchronizer.ModelsApplyChanges(ctlLeftTextEditor.Text);
		}

		private void btnSyncMeta_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(metaFile) || string.IsNullOrEmpty(dataModelsFile))
				return;

			string tables = "";

			using (var dialog = new SelectTablesDialog(ctlLeftTextEditor.Text, false))
			{
				if (dialog.ShowDialog() == DialogResult.OK)
					tables = dialog.Tables;
			}

			if (string.IsNullOrEmpty(tables))
				return;

			(string fieldsXml, bool hasFields) = CodeGenerator.GetFields(ctlLeftTextEditor.Text, ctlRightTextEditor.Text, true, tables);
			if (hasFields)
			{
				using (var dialog = new GptDialog(fieldsXml))
				{
					dialog.ShowDialog();
				}

				fieldsXml = "";

				using (var dialog = new FieldDialog())
				{
					if (dialog.ShowDialog() == DialogResult.OK)
						fieldsXml = dialog.FieldsXml;
				}
				if (string.IsNullOrEmpty(fieldsXml))
					return;
			}
			else
			{
				fieldsXml = "<Fields />";
			}

			ctlRightTextEditor.Text = CodeSynchronizer.SyncMeta(ctlLeftTextEditor.Text, dataModelsFile, tables, ctlRightTextEditor.Text, fieldsXml);
			ctlLeftTextEditor.Text = File.ReadAllText(dataModelsFile);
		}

		private void btnMetaApplyChanges_Click(object sender, EventArgs e)
		{
			ctlRightTextEditor.Text = CodeSynchronizer.MetaApplyChanges(ctlRightTextEditor.Text);
		}
	}
}
