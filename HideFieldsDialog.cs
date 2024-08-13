using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace CodeGeneration
{
	public partial class HideFieldsDialog : Form
	{
		public string Table { get; private set; }

		public string Fields { get; private set; }

		private XmlDocument modelsDoc;

		public HideFieldsDialog(string dataModelsXml)
		{
			InitializeComponent();

			modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			XmlNodeList xmlTables = modelsDoc.DocumentElement.SelectNodes("//Table");
			List<string> tables = new List<string>();
			foreach (XmlElement xmlTable in xmlTables) 
			{
				string tableAlias = xmlTable.GetAttribute("alias");
				if (tables.Contains(tableAlias))
					continue;
				cmbTable.Items.Add(tableAlias);
				tables.Add(tableAlias);
			}
			cmbTable.SelectedIndex = 0;
		}

		private void cmbTable_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listFields.Items.Clear();
			XmlNodeList xmlFields = modelsDoc.DocumentElement.SelectNodes("//Table[@alias='" + cmbTable.Text + "']//Field");
			XmlElement xmlTable = (XmlElement)modelsDoc.DocumentElement.SelectSingleNode("//Table[@alias='" + cmbTable.Text + "']");
			XmlElement xmlFieldsTag = (XmlElement)xmlTable.SelectSingleNode("Fields");
			List<string> hideFields = xmlFieldsTag.HasAttribute("skip") ? xmlFieldsTag.GetAttribute("skip").Split(',').ToList() : new List<string>();

			int idx = 0;
			foreach (XmlElement xmlField in xmlFields)
			{
				string fieldAlias = xmlField.GetAttribute("alias");
				listFields.Items.Add(fieldAlias);
				if (hideFields.Contains(fieldAlias))
					listFields.SetItemChecked(idx, true);
				idx++;
			}

			foreach (string hideField in hideFields)
			{
				listFields.Items.Add(hideField);
				listFields.SetItemChecked(idx++, true);
			}
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			Table = cmbTable.Text;
			List<string> fields = new List<string>();
			foreach (var item in listFields.CheckedItems)
			{
				fields.Add(item.ToString());
			}
			Fields = string.Join(",", fields);
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
