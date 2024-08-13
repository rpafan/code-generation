using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace CodeGeneration
{
	public partial class SelectTablesDialog : Form
	{
		public string Tables { get; private set; }

		public bool CreateTables { get; private set; }

		public SelectTablesDialog(string xml, bool syncModels)
		{
			InitializeComponent();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);

			XmlNodeList xmlTables = doc.DocumentElement.SelectNodes("//Table");
			List<string> tables = new List<string>();
			foreach (XmlElement xmlTable in xmlTables)
			{
				string tableAlias = xmlTable.GetAttribute("alias");
				if (tables.Contains(tableAlias))
					continue;
				listTables.Items.Add(tableAlias);
				tables.Add(tableAlias);
			}
			cbCreateTables.Visible = syncModels;
			Text = syncModels ? "Meta > DB Models. Select Tables" : "DB Models > Meta. Select Tables";
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			List<string> tables = new List<string>();
			foreach (var item in listTables.CheckedItems)
			{
				tables.Add(item.ToString());
			}
			if (!tables.Any())
			{
				MessageBox.Show("Please, select at least 1 table.");
				return;
			}
			Tables = string.Join(",", tables);
			CreateTables = cbCreateTables.Checked;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnSelectAll_Click(object sender, System.EventArgs e)
		{
			bool check = !listTables.GetItemChecked(0);
			for (int i = 0; i < listTables.Items.Count; i++)
			{
				listTables.SetItemChecked(i, check);
			}
		}
	}
}
