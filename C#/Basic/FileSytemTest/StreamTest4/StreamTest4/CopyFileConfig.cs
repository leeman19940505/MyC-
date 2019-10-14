using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest4
{
    public class CopyFileConfig : IFileConfig
    {
        //文件名
        public string FileName { get; set; }
        //是否异步操作
        public bool IsAsync { get; set; }
        //原文件地址
        public string OriginFileUrl { get; set; }
        //拷贝目的路径
        public string DestinationFileUrl { get; set; }
        //文件流 异步读取后在回调方法内使用
        public FileStream OriginalFileStream { get; set; }
        //源文件字节数组 异步读取后在回调方法内使用
        public byte[] OriginalFileBytes { get; set; }
    }
}
