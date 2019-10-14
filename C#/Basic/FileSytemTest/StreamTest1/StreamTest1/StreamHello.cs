using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest1
{
    class StreamTest1
    {
        public StreamTest1()
        {
            byte[] buffer = null;

            string testString = "Stream! Hello world";
            char[] readCharArray = null;
            byte[] readBuffer = null;
            string readString = string.Empty;

            using(MemoryStream stream = new MemoryStream())
            {
                Console.WriteLine("初始字符串为：{0}", testString);

                //如果流可写
                if(stream.CanWrite)
                {
                    //将testString写入流中
                    buffer = Encoding.Default.GetBytes(testString);
                    //在stream中写入数据 数组第一个位置开始写 长度为3
                    stream.Write(buffer, 0, 3);
                    //3
                    Console.WriteLine("现在的Stream.Position在第{0}位置", stream.Position);

                    //从结束位置往后移3位 到第6位
                    long newPositionInStream = stream.CanSeek ? stream.Seek(3, SeekOrigin.Current) : 0;
                    Console.WriteLine("重新定位后的Stream.Position在第{0}位置", newPositionInStream);
                    if(newPositionInStream < buffer.Length)
                    {
                        //从新位置一直写到buffer末尾， 此时stream已经写入3个数据："Str"
                        stream.Write(buffer, (int)newPositionInStream, buffer.Length - (int)newPositionInStream);
                    }

                    //写完后将stream的Position属性设置为0， 开始读取流中的数据
                    stream.Position = 0;

                    //设置一个用来接收数据的数组
                    readBuffer = new byte[stream.Length];

                    //设置stream总读取数量 此时流已经将数据读到了readBuffer中
                    int count = stream.CanRead ? stream.Read(readBuffer, 0, readBuffer.Length) : 0;

                    //由于使用加密Encoding的方式 必须解密将readBuffer转化为Char数组 重新拼接为string

                    //通过流读取出的readBuffer的数据求出对应的Char数量
                    int charCount = Encoding.Default.GetCharCount(readBuffer, 0, count);
                    readCharArray = new char[charCount];

                    //使用解密者（GetDecoder）将readCharArray填充（通过GetChars方法 将readBuffer逐个转化将byte转化为char 并且按一致顺序填充到CharArray中）
                    Encoding.Default.GetDecoder().GetChars(readBuffer, 0, count, readCharArray, 0);

                    for(int i = 0; i < readCharArray.Length; i++)
                    {
                        readString += readCharArray[i];
                    }
                    Console.WriteLine("读取的字符串为：{0}", readString);
                }

                stream.Close();

            }

            Console.ReadLine();
        }
    }
}
