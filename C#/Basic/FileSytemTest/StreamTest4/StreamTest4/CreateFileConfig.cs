using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest4
{
    /// <summary>
    /// 创建文件配置类
    /// </summary>
    public class CreateFileConfig : IFileConfig
    {
        //文件名
        public string FileName { get; set; }
        //是否异步操作
        public bool IsAsync { get; set; }
        //创建文件所在url
        public string CreateUrl { get; set; }
    }
}
