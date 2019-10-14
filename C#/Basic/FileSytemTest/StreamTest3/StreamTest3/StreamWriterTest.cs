using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest3
{
    //StreamWriter 实现一个 TextWriter，使其以一种特定的编码向流中写入字符。
    //extWriter分别是对连续字符系列处理的编写器，而StreamWriter通过特定的编码和流的方式对数据进行处理的编写器

    //构造函数 
    //public StreamWriter(string path); 参数path表示文件所在的位置
    //public StreamWriter(Stream stream, Encoding encoding); 参数Stream 表示可以接受stream的任何子类或派生类，Encoding表示让StreamWriter 在写操作时使用该encoding进行编码操作 
    //public StreamWriter(string path, bool append);  第二个append参数非常重要，当append参数为true时，StreamWriter会通过path去找当前文件是否存在，如果存在则进行append或overwrite的操作，否则创建新的文件
    //public StreamWriter(Stream stream, Encoding encoding, int bufferSize); bufferSize参数设置当前StreamWriter的缓冲区的大小

    //属性
    //AutoFlush: 这个值来指示每次使用streamWriter.Write() 方法后直接将缓冲区的数据写入文件（基础流）
    //BaseStream: 和StreamReader相似可以取出当前的Stream对象加以处理
    class StreamWriterTest
    {
        /// <summary>
        /// 编码
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// IFomatProvider
        /// </summary>
        private IFormatProvider _provider;

        /// <summary>
        /// 文件路径
        /// </summary>
        private string _textFilePath;

        public StreamWriterTest(Encoding encoding, string textFilePath)
            : this(encoding, textFilePath, null)
        {

        }

        public StreamWriterTest(Encoding encoding, string textFilePath, IFormatProvider provider)
        {
            this._encoding = encoding;
            this._textFilePath = textFilePath;
            this._provider = provider;
        }

        /// <summary>
        /// 可以通过FileStream或者 文件路径直接对该文件进行写操作
        /// </summary>
        public void WriteSomethingToFile()
        {
            using(FileStream stream = File.OpenWrite(_textFilePath))
            {
                //获取StreamWriter
                using (StreamWriter writer = new StreamWriter(stream, this._encoding))
                {
                    this.WriteSomethingToFile(writer);
                }

                using(StreamWriter writer = new StreamWriter(_textFilePath, true, this._encoding, 20))
                {
                    this.WriteSomethingToFile(writer);
                }
            }
        }

        /// <summary>
        /// 具体写入文件的逻辑
        /// </summary>
        /// <param name="writer"></param>
        public void WriteSomethingToFile(StreamWriter writer)
        {
            string[] writeMethodOverloadType =
            {
              "1.Write(bool);",
              "2.Write(char);",
              "3.Write(Char[])",
              "4.Write(Decimal)",
              "5.Write(Double)",
              "6.Write(Int32)",
              "7.Write(Int64)",
              "8.Write(Object)",
              "9.Write(Char[])",
              "10.Write(Single)",
              "11.Write(Char[])",
              "12.Write(String)",
              "13Write(UInt32)",
              "14.Write(string format,obj)",
              "15.Write(Char[])"
            };

            //定义writer的AutoFlush属性 如果定义了该属性 就不必使用writer.Flush方法
            writer.AutoFlush = true;
            writer.WriteLine("这个StreamWriter使用了{0}编码", writer.Encoding.HeaderName);
            //这里重新定位流的位置会导致一系列的问题
            //writer.BaseStream.Seek(1, SeekOrigin.Current);
            writer.WriteLine("这里简单演示下StreamWriter.Writer方法的各种重载版本");

            writeMethodOverloadType.ToList().ForEach(
                (name) => { writer.WriteLine(name); }
                );

            writer.WriteLine("StreamWriter.WriteLine()方法就是在加上行结束符，其余和上述方法是用一致");
            //writer.Flush();
            writer.Close();
        }

        public void WriteSomethingToFileByUsingTextWriter()
        {
            using(TextWriter writer = new StringWriter(_provider))
            {
                writer.WriteLine("这里简单介绍下TextWriter 怎么使用用户设置的IFomatProvider，假设用户设置了NumberFormatInfoz.PercentDecimalSeparator属性");
                writer.WriteLine("看下区别吧 {0:p10}", 0.12);
                Console.WriteLine(writer.ToString());
                writer.Flush();
                writer.Close();
            }
        }

    }
}
