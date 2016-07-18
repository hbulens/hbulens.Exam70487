using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace hbulens.Exam70487.Xml
{
    public static class XmlParser
    {
        public static string ParseFile(string filePath)
        {
            using (XmlTextReader reader = new XmlTextReader(filePath))
            {
                while (reader.Read())
                {
                    Debug.WriteLine($"{reader.NodeType} has value: {(reader.NodeType == XmlNodeType.Element ? reader.Name : reader.Value)}");
                }
            }

            return string.Empty;
        }


        public static string Parse(string xmlString)
        {
            StringBuilder output = new StringBuilder();

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {
                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);
                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }

            return output.ToString();
        }

        public static void ParseDocument(string documentPath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(documentPath);

            XPathNavigator navigator = document.CreateNavigator();
            string query = "//MyElement[@RandomAttribute='Random Value']";

            XPathNodeIterator iterator = navigator.Select(query);
            while (iterator.MoveNext())
            {
                string val = iterator.Current.Name;
                Debug.WriteLine(val);
            }
        }
    }
}
