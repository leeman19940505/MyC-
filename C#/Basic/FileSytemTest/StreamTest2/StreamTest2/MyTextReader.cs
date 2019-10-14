using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest2
{
    public class MyTextReader : TextReader
    {
        public override void Close()
        {
            base.Close();
        }

        //寻找当前char的下个char 当返回值为-1时 表示下个char已经是最后一个位置的char
        public override int Peek()
        {
            return base.Peek();
        }

        //read()方法是读取下一个char, 但是和peek方法不同，read()方法使指针指向下个字符，但是peek还是指向原来那个字符
        public override int Read()
        {
            return base.Read();
        }

        public override int Read(char[] buffer, int index, int count)
        {
            return base.Read(buffer, index, count);
        }

        //和Read方法基本一致，区别是从效率上来说ReadBlock更高点，而且ReadBlock并非属于线程安全，使用时要注意
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            return base.ReadBlock(buffer, index, count);
        }

        //这个方法将读取每一行的数据并返回当前行的字符的字符串
        public override string ReadLine()
        {
            return base.ReadLine();
        }

        //包含从当前位置到 TextReader 的结尾的所有字符的字符串 
        public override string ReadToEnd()
        {
            return base.ReadToEnd();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
