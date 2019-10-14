using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest5
{
    class Program
    {
        //MemoryStream是内存流 为系统内存提供读写操作
        //由于MemoryStream是通过无符号字节数组组成的，可以说MemoryStream的性能可以算比较出色，所以它担当起了一些其他流进行数据交换时的中间工作，同时可降低应用程序中对临时缓冲区和临时文件的需要

        //FileStream主要对文件的一系列操作，属于比较高层的操作，但是MemoryStream却很不一样，它更趋向于底层内存的操作
        //能够达到更快的速度和性能，也是他们的根本区别，很多时候，操作文件都需要MemoryStream来实际进行读写，最后放入到相应的FileStream中,
        static void Main(string[] args)
        {
            OutOfMemoryTest();
        }

        private static void OutOfMemoryTest()
        {
            //测试byte数组 假设数组
            byte[] testBytes = new byte[256 * 1024 * 1024];
            MemoryStream ms = new MemoryStream();
            using(ms)
            {
                for(int i = 0; i < 1000; i++)
                {
                    try
                    {
                        ms.Write(testBytes, 0, testBytes.Length);
                    }
                    catch
                    {
                        Console.WriteLine("该内存流已经使用了{0}M容量的内存，该内存流最大容量为{1}M，溢出内存为{2}M",
                            GC.GetTotalMemory(false) / (1024 * 1024), //MemoryStream已经消耗内存量
                            ms.Capacity / (1024 * 1024), //MemoryStream最大的可用容量
                            ms.Length / (1024 * 1024)); //MemoryStream当前流的长度（容量）
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
