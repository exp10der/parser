using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Pars
{
     class XML
     {
         public void Download(List<Price> myPrices )
         {
            const string filename = "mybase.xml";
            var textWritter = new XmlTextWriter(filename, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("head");
            textWritter.WriteEndElement();
            textWritter.Close();

            var document = new XmlDocument();
            document.Load(filename);
            int row = 0;


            foreach (Price c in myPrices)
            {
                row++;
                XmlNode element = document.CreateElement("element");
                document.DocumentElement.AppendChild(element); // указываем родителя
                XmlAttribute attribute = document.CreateAttribute("number"); // создаём атрибут
                attribute.Value = row.ToString(); // устанавливаем значение атрибута
                element.Attributes.Append(attribute); // добавляем атрибут

                XmlNode Name = document.CreateElement("Name");
                Name.InnerText = c.Name;
                element.AppendChild(Name);

                XmlNode Site = document.CreateElement("Site");
                Site.InnerText = c.Site;
                element.AppendChild(Site);

                XmlNode Cost = document.CreateElement("Cost");
                Cost.InnerText = Convert.ToString(c.Cost);
                element.AppendChild(Cost);

                XmlNode eToken = document.CreateElement("eToken");
                eToken.InnerText = Convert.ToString(c.eToken);
                element.AppendChild(eToken);
            }

            document.Save(filename);
        }

        public static List<Price> FU()
        {
            const string fileName = "mybase.xml";

            var doc = new XmlDocument();
            doc.Load(fileName);

            return (from XmlNode node in doc.DocumentElement let ИМЯ = node["Name"].InnerText let САЙТ = node["Site"].InnerText let ЦЕНА = Convert.ToInt32(node["Cost"].InnerText) let ЕТОКЕН = Convert.ToInt32(node["eToken"].InnerText) select new Price() {Name = ИМЯ, Site = САЙТ, Cost = ЦЕНА, eToken = ЕТОКЕН}).ToList();
         }
     }
}

