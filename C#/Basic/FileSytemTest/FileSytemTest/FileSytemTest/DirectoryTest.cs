using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileSytemTest
{
    class DirectoryTest
    {
        public void DictionaryWrite()
        {
            //Directory类 静态方法
            //DirectoryInfo类 实例方法
            string dirPath = "F:\\DirectorySample";
            string filePath = string.Format("{0}\\{1}", dirPath, "test.txt");
            if(!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("创建一个目录:{0}", dirPath);
            }
            else
            {
                Console.WriteLine("目录{0}已存在", dirPath);
            }

            FileInfo file = new FileInfo(filePath);
            if(!file.Exists)
            {
                file.Create();
                Console.WriteLine("创建一个文件： {0}", filePath);
            }
            else
            {
                Console.WriteLine("文件：{0}已存在", filePath);
            }
        }
    }
}
