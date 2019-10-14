using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSytemTest
{
    class FileTest
    {
        public void FileWrite()
        {
            //File类 静态方法 
            //FileInfo类 实例方法
            FileStream fs = null;
            StreamWriter writer = null;
            string path = "F:\\test.txt";
            if (!File.Exists(path))
            {
                fs = File.Create(path);
                Console.WriteLine("新建一个文件: {0}", path);
            }
            else
            {
                fs = File.Open(path, FileMode.Open);
                Console.WriteLine("文件已存在，直接打来");
            }

            writer = new StreamWriter(fs);
            writer.WriteLine("测试文本1");
            Console.WriteLine("向文件写入文本数据");
            writer.Flush();
            writer.Close();
            fs.Close();
            Console.WriteLine("关闭数据流");
            Console.ReadKey();
        }
    }
}
