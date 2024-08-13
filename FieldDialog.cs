using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGeneration
{
	public partial class FieldDialog : Form
	{
		public string FieldsXml { get; private set; }

		public FieldDialog()
		{
			InitializeComponent();
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			FieldsXml = txtFields.Text;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
