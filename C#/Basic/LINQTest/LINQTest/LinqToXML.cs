using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        public static void UsingLinqTest()
        {
            Console.WriteLine("使用Linq方法来对XML文件查询 查询结果为：");
            UsingLinqtoXMLQuery();
            Console.Read();
        }

        // 使用LINQ来对XML文件进行查询
        public static void UsingLinqtoXMLQuery()
        {
            //导入XML
            XElement xmlDoc = XElement.Parse(xmlString);

            //创建查询
            var queryResults = from element in xmlDoc.Elements("Person")
                               where element.Element("Name").Value == "李四"
                               select element;

            //输入查询结果
            foreach(var xele in queryResults)
            {
                Console.WriteLine("姓名为： " + xele.Element("Name").Value + " id为:" + xele.Attribute("Id").Value);
            }
        }

    }
}