using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest2
{
    class TextReaderTest
    {
        public TextReaderTest()
        {
            string text = "abc\nabc";

            //多态 子类的指针允许（赋值给）父类指针
            using (TextReader reader = new StringReader(text))
            {
                while(reader.Peek() != -1)
                {
                    Console.WriteLine("Peek == {0}", (char)reader.Peek()); //read()方法使指针指向下个字符 指针不移位（指向同一个字符） 会死循环
                    Console.WriteLine("Read == {0}", (char)reader.Read()); //但是peek还是指向原来那个字符
                }
                reader.Close();
            }

            using (TextReader reader = new StringReader(text))
            {
                char[] charBuffer = new char[3];
                int data = reader.ReadBlock(charBuffer, 0, 3);
                for(int i = 0; i < charBuffer.Length; i++)
                {
                    Console.WriteLine("通过readBlock读出的数据: {0}", charBuffer[i]);
                }
                reader.Close();
            }

            using (TextReader reader = new StringReader(text))
            {
                string lineData = reader.ReadLine();
                Console.WriteLine("第一行的数据为:{0}", lineData);
                reader.Close();
            }

            using (TextReader reader = new StringReader(text))
            {
                string allData = reader.ReadToEnd();
                Console.WriteLine("全部数据为：{0}", allData);
                reader.Close();
            }

            Console.ReadLine();
        }
    }
}
