using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LINQTest
{
    class LinqToXML
    {
        private static string xmlString =
            "<Persons>" +
            "<Person Id='1'>" +
            "<Name>张三</Name>" +
            "<Age>18</Age>" +
            "</Person>" +
            "<Person Id='2'>" +
            "<Name>李四</Name>" +
            "<Age>19</Age>" +
            "</Person>" +
            "<Person Id='3'>" +
            "<Name>王五</Name>" +
            "<Age>22</Age>" +
            "</Person>" +
            "</Persons>";

        public static void OldQueryTest()
        {
            Console.WriteLine("xpath: ");
            OldLinqToXMLQuery();
            Console.Read();
        }

        public static void OldLinqToXMLQuery()
        {
            //导入XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            //创建查问XML文件的XPath
            string xPath = "/Persons/Person";

            //查询Person元素
            XmlNodeList querynodes = xmlDoc.SelectNodes(xPath);
            foreach(XmlNode node in querynodes)
            {
                //查询名字为李四的元素
                foreach(XmlNode childnode in node.ChildNodes)
                {
                    if(childnode.InnerXml == "李四")
                    {
                        Console.WriteLine("name: " + childnode.InnerXml + "id: " + node.Attributes["Id"].Value);
                    }
                }
            }
        }
    }
}