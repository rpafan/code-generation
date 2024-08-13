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
	public partial class GptDialog : Form
	{
		public GptDialog(string fieldsXml)
		{
			InitializeComponent();

			txtPrompt.Text = @"Your task:
Analyze the following xml with fields.
Define the data type for each field and specify attribute ""datatype"". Data type is a number with possible value:
1 - Boolean
3 - Integer
135 - Date
200 - String

Write the xml with defined data types. Return only xml, that's important.
Output example:
<Fields>
<Field alias=""Title"" datatype=""200"" />
<Field alias=""Number"" datatype=""3"" />
</Fields>

Here is the xml:
" + fieldsXml;
		}
	}
}
