using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace CodeGeneration
{
	internal static class CodeSynchronizer
	{
		public static string SyncModels(string metaXml, string tables, bool createTables, string dataModelsXml)
		{
			List<string> tablesList = tables.Split(',').ToList();
			XmlDocument metaDoc = new XmlDocument();
			metaDoc.LoadXml(metaXml);

			XmlDocument modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			XmlNodeList xmlMetaTables = metaDoc.DocumentElement.SelectNodes("//Table");

			int x = 0, y = 0;
			foreach (XmlElement xmlMetaTable in xmlMetaTables)
			{
				string tableAlias = xmlMetaTable.GetAttribute("alias");
				if (!tablesList.Contains(tableAlias))
					continue;

				XmlElement xmlModelsTable = (XmlElement)modelsDoc.DocumentElement.SelectSingleNode("//Table[@alias='" + xmlMetaTable.GetAttribute("alias") + "']");
				if (xmlModelsTable == null && !createTables)
					continue;

				// Create table
				if (xmlModelsTable == null)
				{
					xmlModelsTable = modelsDoc.CreateElement("Table");
					xmlModelsTable.SetAttribute("alias", tableAlias);
					xmlModelsTable.SetAttribute("width", "200");
					xmlModelsTable.SetAttribute("x", x.ToString());
					xmlModelsTable.SetAttribute("y", y.ToString());
					xmlModelsTable.SetAttribute("is-linked", "1");
					xmlModelsTable.SetAttribute("is-new", "1");
					XmlElement xmlFields = modelsDoc.CreateElement("Fields");
					modelsDoc.SelectSingleNode("//Layout").AppendChild(xmlModelsTable);
					xmlModelsTable.AppendChild(xmlFields);
					x += 20;
					y += 20;
				}
				ProcessModelsTable(xmlMetaTable, xmlModelsTable);
			}

			modelsDoc.Save("dbm.xml");
			return File.ReadAllText("dbm.xml");
		}

		public static string HideFields(string dataModelsXml, string tableAlias, string fields)
		{
			XmlDocument modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			XmlElement xmlTable = (XmlElement)modelsDoc.DocumentElement.SelectSingleNode("//Table[@alias='" + tableAlias + "']");
			XmlElement xmlFieldsTag = (XmlElement)xmlTable.SelectSingleNode("Fields");

			if (!string.IsNullOrEmpty(fields))
				xmlFieldsTag.SetAttribute("skip", fields);
			else
				xmlFieldsTag.RemoveAttribute("skip");

			XmlNodeList xmlFields = modelsDoc.DocumentElement.SelectNodes("//Table[@alias='" + tableAlias + "']//Field");
			List<string> fieldsList = fields.Split(',').ToList();
			foreach (XmlElement xmlField in xmlFields)
			{
				if (fieldsList.Contains(xmlField.GetAttribute("alias")))
					xmlField.ParentNode.RemoveChild(xmlField);
			}

			modelsDoc.Save("dbm.xml");
			return File.ReadAllText("dbm.xml");
		}

		public static string ModelsApplyChanges(string dataModelsXml)
		{
			XmlDocument modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			XmlNodeList xmlTables = modelsDoc.DocumentElement.SelectNodes("//Table");
			foreach (XmlElement xmlTable in xmlTables) 
			{
				string tableAlias = xmlTable.GetAttribute("alias");
				if (xmlTable.HasAttribute("is-new"))
					xmlTable.RemoveAttribute("is-new");

				if (xmlTable.HasAttribute("is-changed"))
					xmlTable.RemoveAttribute("is-changed");

				if (xmlTable.HasAttribute("atrs-new"))
					xmlTable.RemoveAttribute("atrs-new");

				if (xmlTable.HasAttribute("atrs-changed"))
					xmlTable.RemoveAttribute("atrs-changed");

				if (xmlTable.HasAttribute("attrs-deleted"))
				{
					foreach (string attrDeleted in xmlTable.GetAttribute("attrs-deleted").Split('.'))
					{
						xmlTable.RemoveAttribute(attrDeleted);
					}
					xmlTable.RemoveAttribute("attrs-deleted");
				}

				XmlNodeList xmlFields = modelsDoc.DocumentElement.SelectNodes("//Table[@alias='" + tableAlias + "']//Field");
				foreach (XmlElement xmlField in xmlFields)
				{
					if (xmlField.HasAttribute("is-new"))
						xmlField.RemoveAttribute("is-new");
					else if (xmlField.HasAttribute("is-deleted"))
						xmlField.ParentNode.RemoveChild(xmlField);
				}
			}

			modelsDoc.Save("dbm.xml");
			return File.ReadAllText("dbm.xml");
		}

		public static string MetaApplyChanges(string metaXml)
		{
			XmlDocument metaDoc = new XmlDocument();
			metaDoc.LoadXml(metaXml);

			XmlNodeList xmlTables = metaDoc.DocumentElement.SelectNodes("//Table");
			foreach (XmlElement xmlTable in xmlTables)
			{
				if (xmlTable.HasAttribute("is-changed"))
					xmlTable.RemoveAttribute("is-changed");

				XmlNodeList xmlFields = xmlTable.SelectNodes("Fields/Field");
				foreach (XmlElement xmlField in xmlFields)
				{
					if (xmlField.HasAttribute("is-new"))
						xmlField.RemoveAttribute("is-new");
				}
			}

			metaDoc.Save("meta.xml");
			return File.ReadAllText("meta.xml");
		}

		public static string SyncMeta(string dataModelsXml, string dataModelsFile, string tables, string metaXml, string fieldsXml)
		{
			List<string> tablesList = tables.Split(',').ToList();
			XmlDocument modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			XmlDocument metaDoc = new XmlDocument();
			metaDoc.LoadXml(metaXml);

			fieldsXml = Regex.Match(fieldsXml, @"<[\s\S]+>").Value;

			XmlDocument fieldsDoc = new XmlDocument();
			fieldsDoc.LoadXml(fieldsXml);

			XmlNodeList xmlModelsTables = modelsDoc.DocumentElement.SelectNodes("//Table");
			foreach (XmlElement xmlModelsTable in xmlModelsTables)
			{
				string tableAlias = xmlModelsTable.GetAttribute("alias");
				if (!tablesList.Contains(tableAlias))
					continue;

				XmlElement xmlMetaTable = (XmlElement)metaDoc.DocumentElement.SelectSingleNode("//Table[@alias='" + tableAlias + "']");
				// Create table
				if (xmlMetaTable == null)
				{
					xmlMetaTable = metaDoc.CreateElement("Table");
					xmlMetaTable.SetAttribute("alias", tableAlias);
					xmlMetaTable.SetAttribute("is-new", "1");
					XmlElement xmlFields = metaDoc.CreateElement("Fields");
					metaDoc.SelectSingleNode("Meta/Tables").AppendChild(xmlMetaTable);
					xmlMetaTable.AppendChild(xmlFields);
				}
				ProcessMetaTable(xmlModelsTable, xmlMetaTable, fieldsDoc);
			}

			modelsDoc.Save(dataModelsFile);
			metaDoc.Save("meta.xml");
			return File.ReadAllText("meta.xml");
		}

		private static void ProcessModelsTable(XmlElement xmlMetaTable, XmlElement xmlModelsTable)
		{
			List<string> attrsNew = xmlModelsTable.HasAttribute("attrs-new") ? xmlModelsTable.GetAttribute("attrs-new").Split(',').ToList() : new List<string>();
			List<string> attrsDeleted = xmlModelsTable.HasAttribute("attrs-deleted") ? xmlModelsTable.GetAttribute("attrs-deleted").Split(',').ToList() : new List<string>();
			List<string> attrsChanged = xmlModelsTable.HasAttribute("attrs-changed") ? xmlModelsTable.GetAttribute("attrs-changed").Split(',').ToList() : new List<string>();

			XmlElement xmlFieldsTag = (XmlElement)xmlModelsTable.SelectSingleNode("Fields");
			List<string> skipFields = xmlFieldsTag.HasAttribute("skip") ? xmlFieldsTag.GetAttribute("skip").Split(',').ToList() : new List<string>();

			List<string> attrsUsed = new List<string>();

			XmlNodeList xmlModelsFields = xmlModelsTable.OwnerDocument.DocumentElement.SelectNodes("//Table[@alias='" + xmlModelsTable.GetAttribute("alias") + "']//Field");
			foreach (XmlElement xmlModelsField in xmlModelsFields)
			{
				xmlModelsField.SetAttribute("is-deleted", "1");
			}

			XmlNodeList xmlMetaFields = xmlMetaTable.SelectNodes("Fields/Field");
			foreach (XmlElement xmlMetaField in xmlMetaFields)
			{
				if (new string[] { "TreePath", "TreeLevel" }.Contains(xmlMetaField.GetAttribute("alias")))
				{
					if (!xmlModelsTable.HasAttribute("use-tree") && !attrsNew.Contains("use-tree"))
					{
						attrsNew.Add("use-tree");
						xmlModelsTable.SetAttribute("use-tree", "1");
					}
					attrsDeleted.Remove("use-tree");
					attrsUsed.Add("use-tree");
					continue;
				}
				if (xmlMetaField.GetAttribute("alias") == "Workflow")
				{
					if (!xmlModelsTable.HasAttribute("use-workflow") && !attrsNew.Contains("use-workflow"))
					{
						attrsNew.Add("use-workflow");
						xmlModelsTable.SetAttribute("use-workflow", "1");
					}
					attrsDeleted.Remove("use-workflow");
					attrsUsed.Add("use-workflow");
					continue;
				}
				if (xmlMetaField.GetAttribute("alias") == "SortIndex")
				{
					if (!xmlModelsTable.HasAttribute("use-sort") && !attrsNew.Contains("use-sort"))
					{
						attrsNew.Add("use-sort");
						xmlModelsTable.SetAttribute("use-sort", "1");
					}
					attrsDeleted.Remove("use-sort");
					attrsUsed.Add("use-sort");
					continue;
				}

				XmlElement xmlModelsField = (XmlElement)xmlModelsTable.OwnerDocument.DocumentElement.SelectSingleNode("//Table[@alias='" + xmlModelsTable.GetAttribute("alias") + "']//Field[@alias='" + xmlMetaField.GetAttribute("alias") + "']");
				// Create field
				if (xmlModelsField == null)
				{
					string fieldAlias = xmlMetaField.GetAttribute("alias");
					if (!skipFields.Contains(fieldAlias))
					{
						XmlElement xmlField = xmlModelsTable.OwnerDocument.CreateElement("Field");
						xmlField.SetAttribute("alias", fieldAlias);
						xmlField.SetAttribute("is-linked", "1");
						xmlField.SetAttribute("is-new", "1");
						xmlModelsTable.SelectSingleNode("Fields").AppendChild(xmlField);
					}
				}
				else
				{
					xmlModelsField.RemoveAttribute("is-deleted");
				}
			}

			foreach (XmlElement xmlField in xmlModelsFields)
			{
				if (xmlField.HasAttribute("is-new") && xmlField.HasAttribute("is-deleted"))
					xmlField.RemoveAttribute("is-new");
			}

			foreach (string useAttr in new string[] { "use-tree", "use-workflow", "use-sort" })
			{
				if (xmlModelsTable.HasAttribute(useAttr) && !attrsUsed.Contains(useAttr) && !attrsDeleted.Contains(useAttr))
					attrsDeleted.Add(useAttr);
			}

			foreach (string attrDeleted in attrsDeleted)
			{
				if (attrsNew.Contains(attrDeleted))
					attrsNew.Remove(attrDeleted);
			}

			bool hasChangedFields = false;
			foreach (XmlElement xmlField in xmlModelsFields)
			{
				if (xmlField.HasAttribute("is-new") || xmlField.HasAttribute("is-deleted"))
				{
					hasChangedFields = true;
					break;
				}
			}

			if (attrsNew.Any() || attrsChanged.Any() || attrsDeleted.Any() || hasChangedFields)
				xmlModelsTable.SetAttribute("is-changed", "1");
			else
				xmlModelsTable.RemoveAttribute("is-changed");

			if (attrsNew.Any())
				xmlModelsTable.SetAttribute("attrs-new", string.Join(",", attrsNew));
			else
				xmlModelsTable.RemoveAttribute("attrs-new");
			if (attrsChanged.Any())
				xmlModelsTable.SetAttribute("attrs-changed", string.Join(",", attrsChanged));
			else
				xmlModelsTable.RemoveAttribute("attrs-changed");
			if (attrsDeleted.Any())
				xmlModelsTable.SetAttribute("attrs-deleted", string.Join(",", attrsDeleted));
			else
				xmlModelsTable.RemoveAttribute("attrs-deleted");
		}

		private static void ProcessMetaTable(XmlElement xmlModelsTable, XmlElement xmlMetaTable, XmlDocument fieldsDoc)
		{
			List<string> attrsDeleted = xmlModelsTable.HasAttribute("attrs-deleted") ? xmlModelsTable.GetAttribute("attrs-deleted").Split(',').ToList() : new List<string>();
			XmlElement xmlFieldsTag = (XmlElement)xmlMetaTable.SelectSingleNode("Fields");
			XmlNodeList xmlModelsFields = xmlModelsTable.OwnerDocument.DocumentElement.SelectNodes("//Table[@alias='" + xmlModelsTable.GetAttribute("alias") + "']//Field");
			foreach (XmlElement xmlModelsField in xmlModelsFields)
			{
				if (xmlModelsField.HasAttribute("is-deleted"))
					continue;

				string fieldAlias = xmlModelsField.GetAttribute("alias");
				XmlElement xmlMetaField = (XmlElement)xmlFieldsTag.SelectSingleNode("Field[@alias='" + fieldAlias + "']");
				XmlElement xmlGptField = (XmlElement)fieldsDoc.DocumentElement.SelectSingleNode("Field[@alias='" + fieldAlias + "']");

				// Create field
				if (xmlMetaField == null)
				{
					string dataType = "200";
					string refObjectType = "";
					if (xmlModelsField.HasAttribute("arrow-to"))
					{
						dataType = "3";
						string tableID = xmlModelsField.GetAttribute("arrow-to");
						if (tableID != ".")
						{
							XmlElement xmlRefTable = (XmlElement)xmlModelsTable.OwnerDocument.DocumentElement.SelectSingleNode("//Table[@id='" + tableID + "']") ??
							(XmlElement)xmlModelsTable.OwnerDocument.DocumentElement.SelectSingleNode("//Table[@alias='" + tableID + "']");
							if (xmlRefTable != null)
								refObjectType = xmlRefTable.GetAttribute("alias");
						}
						else
						{
							refObjectType = xmlModelsTable.GetAttribute("alias");
						}
					}

					XmlElement xmlField = xmlMetaTable.OwnerDocument.CreateElement("Field");
					xmlField.SetAttribute("alias", fieldAlias);
					xmlField.SetAttribute("datatype", xmlGptField != null ? xmlGptField.GetAttribute("datatype") : dataType);
					if (!string.IsNullOrEmpty(refObjectType))
						xmlField.SetAttribute("ref-objecttype", refObjectType);
					xmlField.SetAttribute("is-new", "1");
					xmlFieldsTag.AppendChild(xmlField);

					if (!xmlMetaTable.HasAttribute("is-changed"))
						xmlMetaTable.SetAttribute("is-changed", "1");
				}

				if (!xmlModelsField.HasAttribute("is-linked"))
					xmlModelsField.SetAttribute("is-linked", "1");
			}

			if (xmlModelsTable.HasAttribute("use-sort") && !attrsDeleted.Contains("use-sort"))
				CodeGenerator.AddSortFields(xmlMetaTable);

			if (xmlModelsTable.HasAttribute("use-tree") && !attrsDeleted.Contains("use-tree"))
				CodeGenerator.AddTreeFields(xmlMetaTable);

			if (xmlModelsTable.HasAttribute("use-workflow") && !attrsDeleted.Contains("use-workflow"))
				CodeGenerator.AddWorkflowFields(xmlMetaTable);
		}
	}
}
