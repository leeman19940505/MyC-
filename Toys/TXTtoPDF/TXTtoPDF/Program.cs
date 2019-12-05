using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTtoPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //要转换的文件的路径
            string path = "C:\\Users\\69439\\Desktop\\Lee\\test.txt";
            //第一个参数是txt文件物理地址
            string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("gb2312"));
            //iTextSharp.text.PageSize.A4; //自定义页面大小
            Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 20, 20, 20);
            PdfWriter pdfwriter = PdfWriter.GetInstance(doc
                , new FileStream(path.ToString().Substring(0, path.ToString().Length - 4) + ".pdf", FileMode.Create));
            doc.Open();
            //创建我的基本字体
            BaseFont baseFont = BaseFont.CreateFont("c:\\Windows\\Fonts\\SIMYOU.TTF", "Identity-H", false);
            //创建字体 字体大小 字体粗细 字体颜色
            Font font = new Font(baseFont, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Paragraph paragraph;
            foreach(string line in lines)
            {
                paragraph = new Paragraph(line, font);
                doc.Add(paragraph);
            }

            doc.Close();
            Console.WriteLine("tran complete");
            Console.ReadKey();
        }
    }
}
