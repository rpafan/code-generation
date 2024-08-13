using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace CodeGeneration
{
	internal static class CodeGenerator
	{
		public static string GenerateMeta(string dataModelsFile, string dataModelsXml, string fieldsXml)
		{
			XmlDocument modelsDoc = new XmlDocument();
			modelsDoc.LoadXml(dataModelsXml);

			fieldsXml = Regex.Match(fieldsXml, @"<[\s\S]+>").Value;

			XmlDocument fieldsDoc = new XmlDocument();
			fieldsDoc.LoadXml(fieldsXml);

			XmlDocument docMetaData = new XmlDocument();
			XmlElement xmlMeta = docMetaData.CreateElement("Meta");
			docMetaData.AppendChild(xmlMeta);
			XmlElement xmlMetaTables = docMetaData.CreateElement("Tables");
			xmlMeta.AppendChild(xmlMetaTables);

			XmlNodeList xmlTables = modelsDoc.DocumentElement.SelectNodes("//Table");
			List<string> processedTables = new List<string>();

			foreach (XmlElement xmlTable in xmlTables)
			{
				string tableName = xmlTable.GetAttribute("alias");
				if (processedTables.Contains(tableName))
					continue;
				ProcessTable(xmlTable, docMetaData, xmlMetaTables, fieldsDoc);
				processedTables.Add(tableName);
			}

			modelsDoc.Save(dataModelsFile);
			docMetaData.Save("meta.xml");
			return File.ReadAllText("meta.xml");
		}

		public static (string, bool) GetFields(string dataModelsXml, string metaXml = "", bool onlyNewFields = false, string tables = "")
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(dataModelsXml);

			XmlNodeList xmlTables = doc.DocumentElement.SelectNodes("//Table");
			List<string> tablesList = !string.IsNullOrEmpty(tables) ? tables.Split(',').ToList() : new List<string>();
			List<string> processedTables = new List<string>();
			List<string> fields = new List<string>();

			XmlDocument metaDoc = new XmlDocument();
			if (!string.IsNullOrEmpty(metaXml))
				metaDoc.LoadXml(metaXml);

			XmlDocument tempDoc = new XmlDocument();
			XmlElement xmlFieldsTag = tempDoc.CreateElement("Fields");
			tempDoc.AppendChild(xmlFieldsTag);

			foreach (XmlElement xmlTable in xmlTables)
			{
				string tableName = xmlTable.GetAttribute("alias");
				
				if (processedTables.Contains(tableName))
					continue;

				if (tablesList.Any() && !tablesList.Contains(tableName))
					continue;

				XmlNodeList xmlFields = xmlTable.OwnerDocument.DocumentElement.SelectNodes("//Table[@alias='" + xmlTable.GetAttribute("alias") + "']//Field");
				if (xmlFields.Count == 0)
					continue;

				foreach (XmlElement xmlField in xmlFields)
				{
					string fieldAlias = xmlField.GetAttribute("alias");
					if (fields.Contains(fieldAlias))
						continue;

					if (xmlField.HasAttribute("arrow-to"))
						continue;

					if (onlyNewFields && xmlField.HasAttribute("is-linked"))
						continue;

					if (onlyNewFields && !string.IsNullOrEmpty(metaXml))
					{
						XmlElement metaField = (XmlElement)metaDoc.DocumentElement.SelectSingleNode("//Table[@alias='" + xmlTable.GetAttribute("alias") + "']/Fields/Field[@alias='" + xmlField.GetAttribute("alias") + "']");
						if (metaField != null)
							continue;
					}

					XmlElement xmlTempField = tempDoc.CreateElement("Field");
					xmlTempField.SetAttribute("alias", xmlField.GetAttribute("alias"));
					xmlFieldsTag.AppendChild(xmlTempField);

					fields.Add(fieldAlias);
				}

				processedTables.Add(tableName);
			}

			tempDoc.Save("temp.xml");
			return (File.ReadAllText("temp.xml"), xmlFieldsTag.HasChildNodes);
		}

		private static void ProcessTable(XmlElement xmlTable, XmlDocument docMetaData, XmlElement xmlMetaTables, XmlDocument fieldsDoc)
		{
			XmlNodeList xmlFields = xmlTable.OwnerDocument.DocumentElement.SelectNodes("//Table[@alias='" + xmlTable.GetAttribute("alias") + "']//Field");
			if (xmlFields.Count == 0)
				return;

			XmlElement xmlMetaTable = docMetaData.CreateElement("Table");
			xmlMetaTable.SetAttribute("alias", xmlTable.GetAttribute("alias"));
			xmlMetaTables.AppendChild(xmlMetaTable);

			XmlElement xmlMetaFields = docMetaData.CreateElement("Fields");
			xmlMetaTable.AppendChild(xmlMetaFields);

			foreach (XmlElement xmlField in xmlFields) 
			{
				string fieldAlias = xmlField.GetAttribute("alias");
				XmlElement xmlGptField = (XmlElement)fieldsDoc.DocumentElement.SelectSingleNode("Field[@alias='" + fieldAlias + "']");
				XmlElement xmlMetaField = docMetaData.CreateElement("Field");
				xmlMetaField.SetAttribute("alias", fieldAlias);

				string dataType = "200";
				string refObjectType = "";
				if (xmlField.HasAttribute("arrow-to"))
				{
					dataType = "3";
					string tableID = xmlField.GetAttribute("arrow-to");
					if (tableID != ".")
					{
						XmlElement xmlRefTable = (XmlElement)xmlTable.OwnerDocument.DocumentElement.SelectSingleNode("//Table[@id='" + tableID + "']") ??
						(XmlElement)xmlTable.OwnerDocument.DocumentElement.SelectSingleNode("//Table[@alias='" + tableID + "']");
						if (xmlRefTable != null)
							refObjectType = xmlRefTable.GetAttribute("alias");
					}
					else
					{
						refObjectType = xmlTable.GetAttribute("alias");
					}
				}

				xmlMetaField.SetAttribute("datatype", xmlGptField != null ? xmlGptField.GetAttribute("datatype") : dataType);
				if (!string.IsNullOrEmpty(refObjectType))
					xmlMetaField.SetAttribute("ref-objecttype", refObjectType);
				xmlMetaFields.AppendChild(xmlMetaField);
				xmlField.SetAttribute("is-linked", "1");
			}

			if (xmlTable.HasAttribute("use-tree"))
				AddTreeFields(xmlMetaTable);

			if (xmlTable.HasAttribute("use-workflow"))
				AddWorkflowFields(xmlMetaTable);

				xmlTable.SetAttribute("is-linked", "1");
		}

		public static void AddTreeFields(XmlElement xmlTable)
		{
			XmlElement xmlFieldsTag = (XmlElement)xmlTable.SelectSingleNode("Fields");

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='ParentID']") == null)
			{
				XmlElement xmlParentID = xmlTable.OwnerDocument.CreateElement("Field");
				xmlParentID.SetAttribute("alias", "ParentID");
				xmlParentID.SetAttribute("datatype", "3");
				xmlParentID.SetAttribute("ref-objecttype", xmlTable.GetAttribute("alias"));
				xmlFieldsTag.AppendChild(xmlParentID);
			}

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='SortIndex']") == null)
			{
				XmlElement xmlSortIndex = xmlTable.OwnerDocument.CreateElement("Field");
				xmlSortIndex.SetAttribute("alias", "SortIndex");
				xmlSortIndex.SetAttribute("datatype", "3");
				xmlFieldsTag.AppendChild(xmlSortIndex);
			}

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='TreePath']") == null)
			{
				XmlElement xmlTreePath = xmlTable.OwnerDocument.CreateElement("Field");
				xmlTreePath.SetAttribute("alias", "TreePath");
				xmlTreePath.SetAttribute("datatype", "200");
				xmlFieldsTag.AppendChild(xmlTreePath);
			}

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='TreeLevel']") == null)
			{
				XmlElement xmlTreeLevel = xmlTable.OwnerDocument.CreateElement("Field");
				xmlTreeLevel.SetAttribute("alias", "TreeLevel");
				xmlTreeLevel.SetAttribute("datatype", "3");
				xmlFieldsTag.AppendChild(xmlTreeLevel);
			}
		}

		public static void AddWorkflowFields(XmlElement xmlTable)
		{
			XmlElement xmlFieldsTag = (XmlElement)xmlTable.SelectSingleNode("Fields");

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='Workflow']") == null)
			{
				XmlElement xmlParentID = xmlTable.OwnerDocument.CreateElement("Field");
				xmlParentID.SetAttribute("alias", "Workflow");
				xmlParentID.SetAttribute("datatype", "200");
				xmlFieldsTag.AppendChild(xmlParentID);
			}
		}

		public static void AddSortFields(XmlElement xmlTable)
		{
			XmlElement xmlFieldsTag = (XmlElement)xmlTable.SelectSingleNode("Fields");

			if (xmlFieldsTag.SelectSingleNode("Field[@alias='SortIndex']") == null)
			{
				XmlElement xmlSortIndex = xmlTable.OwnerDocument.CreateElement("Field");
				xmlSortIndex.SetAttribute("alias", "SortIndex");
				xmlSortIndex.SetAttribute("datatype", "3");
				xmlFieldsTag.AppendChild(xmlSortIndex);
			}
		}
	}
}
