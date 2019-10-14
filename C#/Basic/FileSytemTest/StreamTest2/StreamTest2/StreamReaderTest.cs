using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest2
{
    class StreamReaderTest
    {
        //构造方法
        //1:StreamReader(Stream stream)
        //将stream作为一个参数 放入StreamReader，这样的话StreamReader可以对该stream进行读取操作,Stream对象可以非常广泛，包括所有Stream的派生类对象
        //2:StreamReader(string string, Encoding encoding)
        //这里的string对象不是简单的字符串而是具体文件的地址,然后根据用户选择编码去读取流中的数据
        //3:StreamReader(string string，bool detectEncodingFromByteOrderMarks)
        //有时候我们希望程序自动判断用何种编码去读取，这时候detectEncodingFromByteOrderMarks这个参数就能起作用了，当设置为true的 时候数通过查看流的前三个字节来检测编码。如果文件以适当的字节顺序标记开头，该参数自动识别 UTF-8、Little-Endian Unicode 和 Big-Endian Unicode 文本，当为false 时，方法会去使用用户提供
        //4:StreamReader(string string, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        //这个放提供了4个参数的重载，前3个我们都已经了解，最后个是缓冲区大小的设置，

        //属性
        //1:BaseStream
        //FileStream fs = new FileStream("D:\\TextReader.txt", FileMode.Open, FileAccess.Read);
        //StreamReader sr = new StreamReader(fs);
        ////本例中的BaseStream就是FileStream
        //sr.BaseStream.Seek(0 , SeekOrigin.Begin ) ;
        //2:CurrentEncoding:
        //获取当前StreamReader的Encoding
        //3:EndOfStream:
        //判断StreamReader是否已经处于当前流的末尾
        public StreamReaderTest()
        {
            //文件地址
            string txtFilePath = "F:\\MicrosoftVisualStudioworkingspace\\C#\\FileSytemTest\\TextReader.txt";
            //定义char数组
            char[] charBuffer2 = new char[3];

            //利用FileStream类将文件文本数据变成流然后放入StreamReader构造函数中
            using (FileStream stream = File.OpenRead(txtFilePath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    //StreamReader.Read()方法
                    DisplayResultStringByUsingRead(reader);
                }
            }

            using (FileStream stream = File.OpenRead(txtFilePath))
            {
                //使用Encoding.ASCII来尝试下
                using (StreamReader reader = new StreamReader(stream, Encoding.ASCII, false))
                {
                    //StreamReader.ReadBlock()方法
                    DisplayResultStringByUsingReadBlock(reader);
                }
            }

            //尝试用文件定位直接得到StreamReader，顺便使用 Encoding.Default
            using (StreamReader reader = new StreamReader(txtFilePath, Encoding.Default, false, 123))
            {
                //StreamReader.ReadLine()方法
                DisplayResultStringByUsingReadLine(reader);
            }

            using (StreamReader reader = new StreamReader(txtFilePath, Encoding.BigEndianUnicode, false, 123))
            {
                //StreamReader.ReadLine()方法
                DisplayResultStringByUsingReadLine(reader);
            }

            using (StreamReader reader = new StreamReader(txtFilePath, Encoding.ASCII, false, 123))
            {
                //StreamReader.ReadLine()方法
                DisplayResultStringByUsingReadLine(reader);
            }

            //也可以通过File.OpenText方法直接获取到StreamReader对象
            using (StreamReader reader = File.OpenText(txtFilePath))
            {
                //StreamReader.ReadLine()方法
                DisplayResultStringByUsingReadLine(reader);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 使用StreamReader.Read()方法
        /// </summary>
        /// <param name="reader"></param>
        public static void DisplayResultStringByUsingRead(StreamReader reader)
        {
            int readChar = 0;
            string result = string.Empty;
            while ((readChar = reader.Read()) != -1)
            {
                result += (char)readChar;
            }
            Console.WriteLine("使用StreamReader.Read()方法得到Text文件中的数据为 : {0}", result);
        }

        /// <summary>
        /// 使用StreamReader.ReadBlock()方法
        /// </summary>
        /// <param name="reader"></param>
        public static void DisplayResultStringByUsingReadBlock(StreamReader reader)
        {
            char[] charBuffer = new char[10];
            string result = string.Empty;
            reader.ReadBlock(charBuffer, 0, 10);
            for (int i = 0; i < charBuffer.Length; i++)
            {
                result += charBuffer[i];
            }
            Console.WriteLine("使用StreamReader.ReadBlock()方法得到Text文件中前10个数据为 : {0}", result);
        }

        /// <summary>
        /// 使用StreamReader.ReadLine()方法
        /// </summary>
        /// <param name="reader"></param>
        public static void DisplayResultStringByUsingReadLine(StreamReader reader)
        {
            int i = 1;
            string resultString = string.Empty;
            while ((resultString = reader.ReadLine()) != null)
            {
                Console.WriteLine("使用StreamReader.Read()方法得到Text文件中第{1}行的数据为 : {0}", resultString, i);
                i++;
            }

        }

    }
}
