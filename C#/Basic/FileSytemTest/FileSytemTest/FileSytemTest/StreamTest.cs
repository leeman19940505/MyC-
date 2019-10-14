using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSytemTest
{
    //流 内存中的字节序列
    //  Stream <- NetworkStream 网络通信的基础数据流
    //            FileStream    将数据以流的形式写入文件，或从文件中读取
    //            MemoryStream  用于对内存中的数据进行写入或读取
    //            GZipStream    提供用于压缩和解压缩流的数据
    class StreamTest
    {
        public void fileStreamWrite()
        {
            string filePath = "D:\\test.txt";
            //以读/写访问权限打开指定路径上的FileStream
            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                string msg = "HelloWorld";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                Console.WriteLine("开始写入 {0}到文件中", msg);
                fileStream.Write(msgAsByteArray, 0, msgAsByteArray.Length); //对流进行写入
                fileStream.Seek(0, SeekOrigin.Begin);  //对流进行查找
                Console.WriteLine("写入文件中的数据为：");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                fileStream.Read(bytesFromFile, 0, msgAsByteArray.Length); //对流进行读取
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
                Console.Read();
            }
        }

        //文本读写器 TextReader/TextWrite
        //字符串读写器 StringReader/StringWrite
        //二进制读写器 BinaryReader/BinaryWriter
        //流读写器 StreamReader/StreamWriter
        public void streamWrite()
        {
            string filePath = "D:\\test.txt";
            using(FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                string msg = "Hello World";
                StreamWriter streamWriter = new StreamWriter(fileStream); //创建StreamWriter对象
                Console.WriteLine("开始写入{0} 到文件中", msg);
                streamWriter.Write(msg);
                StreamReader streamReader = new StreamReader(fileStream); //创建StreamReader对象
                Console.WriteLine("写入文件中的数据为：\n{0}", streamReader.ReadToEnd());
                streamWriter.Close();
                streamReader.Close();
                Console.Read();
            }
        }
    }
}
