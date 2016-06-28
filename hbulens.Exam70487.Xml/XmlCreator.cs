using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hbulens.Exam70487.Xml
{
    public static class XmlCreator
    {
        public static string Create(string text)
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (XmlWriter xmlWriter = XmlWriter.Create(mydocpath + @"\Exam70487.txt"))
            {
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("MyElement");

                xmlWriter.WriteStartAttribute("RandomAttribute");
                xmlWriter.WriteValue("Random Value");
                xmlWriter.WriteEndAttribute();

                xmlWriter.WriteValue(text);

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
            }


            return "Document is now available on " + mydocpath + @"\Exam70487.txt";
        }
    }
}
