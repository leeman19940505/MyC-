using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest1
{
    public class MyStreamExample : Stream
    {
        //该流是否能够读取
        public override bool CanRead => throw new NotImplementedException();

        //该流是否支持跟踪查找
        public override bool CanSeek => throw new NotImplementedException();

        //该流是否可写
        public override bool CanWrite => throw new NotImplementedException();

        //流的长度
        public override long Length => throw new NotImplementedException();

        //标识流中的一个位置 （用using语句将流对象包裹起来 用完后关闭回收）
        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //使用流写文件时，数据流会先进入到缓冲区中，而不会立刻写入文件，当执行这个方法后，缓冲区的数据流会立即注入基础流
        public override void Flush()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">缓冲字节数组 每次读取一个字节放入数组中</param>
        /// <param name="offset">位移偏量 从流的那个位置开始读取</param>
        /// <param name="count">读取字节个数 读取多少字节数</param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 重新设定流中的一个位
        /// </summary>
        /// <param name="offset">-为位置origin之前；0为origin；+为origin之后</param>
        /// <param name="origin">Begin:指定流的开头 Current:指定流内的当前位置 End:指定流的结尾</param>
        /// <returns>流中的新位置</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        //virtual void Close()
        //关闭流并释放资源，在实际操作中，如果不用using的话，使用完流之后将其关闭
    }
}
