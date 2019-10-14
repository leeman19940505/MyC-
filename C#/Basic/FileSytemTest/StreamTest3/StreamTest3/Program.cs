using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest3
{
    class Program
    {
        const string txtFilePath = "F:\\MicrosoftVisualStudioworkingspace\\C#\\FileSytemTest\\TextWriter.txt";
        static void Main(string[] args)
        {
            NumberFormatInfo numberFomatProvider = new NumberFormatInfo();
            //将小数 “.”换成"?" 
            numberFomatProvider.PercentDecimalSeparator = "?";
            StreamWriterTest test = new StreamWriterTest(Encoding.Default, txtFilePath, numberFomatProvider);
            //StreamWriter
            test.WriteSomethingToFile();
            //TextWriter
            test.WriteSomethingToFileByUsingTextWriter();
            Console.ReadLine();
        }
    }
}
