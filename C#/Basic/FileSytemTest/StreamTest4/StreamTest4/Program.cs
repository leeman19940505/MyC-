using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest4
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //test1();
            test2();
        }

        public static void test1()
        {
            FileStreamTest test = new FileStreamTest();
            //创建文件配置类
            CreateFileConfig createFileConfig = new CreateFileConfig { CreateUrl = @"d:\MyFile.txt", IsAsync = true };
            //复制文件配置类
            CopyFileConfig copyFileConfig = new CopyFileConfig
            {
                OriginFileUrl = @"d:\8.jpg",
                DestinationFileUrl = @"d:\9.jpg",
                IsAsync = true
            };
            test.Create(createFileConfig);
            test.Copy(copyFileConfig);
        }

        public static void test2()
        {
            UpFileSingleTest test = new UpFileSingleTest();
            FileInfo info = new FileInfo(@"G:\\Skyrim\20080204173728108.torrent");
            //取得文件总长度
            var fileLegth = info.Length;
            //假设将文件切成5段
            var divide = 5;
            //取到每个文件段的长度
            var perFileLengh = (int)fileLegth / divide;
            //表示最后剩下的文件段长度比perFileLengh小
            var restCount = (int)fileLegth % divide;
            //循环上传数据
            for (int i = 0; i < divide + 1; i++)
            {
                //每次定义不同的数据段,假设数据长度是500，那么每段的开始位置都是i*perFileLength
                var startPosition = i * perFileLengh;
                //取得每次数据段的数据量
                var totalCount = fileLegth - perFileLengh * i > perFileLengh ? perFileLengh : (int)(fileLegth - perFileLengh * i);
                //上传该段数据
                test.UpLoadFileFromLocal(@"G:\\Skyrim\\20080204173728108.torrent", @"G:\\Skyrim\\20080204173728109.torrent", startPosition, i == divide ? divide : totalCount);
            }
        }
    }
}
