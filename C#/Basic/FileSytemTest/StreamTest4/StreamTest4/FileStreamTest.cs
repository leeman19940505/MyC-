using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest4
{
    //构造函数
    //1：FileStream(SafeFileHandler, FileAccess)
    //SateFileHandler：是一个文件安全句柄 （C#非委托资源 能够调用非托管资源的方法 不属于C#回收机制 必须使用GC手动或其它方式（Finalize或Dispose方法）进行非托管资源的回收）
    //2：FileStream(String, fileMode) String 参数表示文件所在的地址,FIleMode是个枚举，表示确定如何打开或创建文件。
    //3: FileStream(IntPtr, FileAccess, Boolean ownsHandle) FileAccess 参数也是一个枚举, 表示对于该文件的操作权限
    //ownsHandler 类似SafeFileHandler 
    //对于指定的文件句柄，操作系统不允许所请求的 access  (FileAccess的权限应该在ownsHandle的范围之内)
    //FileStream 假定它对句柄有独占控制权。当 FileStream 也持有句柄时，读取、写入或查找可能会导致数据破坏。为了数据的安全，请使用句柄前调用 Flush，并避免在使用完句柄后调用 Close 以外的任何方法。
    //4: FileStream(String, FileMode, FileAccess, FileShare) FileShare：同样是个枚举类型：确定文件如何由进程共享。 
    //5: FileStream(String, FileMode, FileAccess, FileShare, Int32, Boolean async ) Int32:这是一个缓冲区的大小，大家可以按照自己的需要定制， Boolean async:是否异步读写，告诉FileStream示例，是否采用异步读写
    //6: FileStream(String, FileMode, FileAccess, FileShare, Int32, FileOptions) ileOptions：这是类似于FileStream对于文件操作的高级选项

    //属性
    //CanRead ：指示FileStream是否可以读操作
    //CanSeek：指示FileStream是否可以跟踪查找流操作
    //IsAsync：FileStream是否同步工作还是异步工作
    //Name：FileStream的名字 只读属性
    //ReadTimeout ：设置读取超时时间
    //SafeFileHandle : 文件安全句柄 只读属性
    //position：当前FileStream所在的流位置

    //方法
    //FileSecurity GetAccessControl() 这个不是很常用，FileSecurity 是文件安全类，直接表达当前文件的访问控制列表（ACL）的符合当前文件权限的项目
    //void Lock(long position, long length)  这个Lock方法和线程中的Look关键字很不一样，它能够锁住文件中的某一部分，非常的强悍！用了这个方法我们能够精确锁定住我们需要锁住的文件的部分内容
    //void SetAccessControl(FileSecurity fileSecurity)  和GetAccessControl很相似
    //void Unlock (long position,long length) 正好和lock方法相反，对于文件部分的解锁
    
    class FileStreamTest 
    {
        private object _lockObject = new object();
        const int READ_OR_WRITE_TIMEOUT = 1000;

        private bool CheckConfigIsError(IFileConfig config)
        {
            //return config != null && config.FileName.Length > 0;
            return config == null;
        }

        /// <summary>
        /// 添加文件方法
        /// </summary>
        /// <param name="config">创建文件配置类</param>
        public void Create(IFileConfig config)
        {
            lock(_lockObject)
            {
                //得到创建文件配置类对象
                var createFileConfig = config as CreateFileConfig;
                //检查创建文件配置类是否为空
                if(this.CheckConfigIsError(config))
                {
                    return;
                }
                //创建完文件后写入一段话
                char[] insertContent = "HelloWorld".ToCharArray();
                //转化为byte[]
                byte[] byteArrayContent = Encoding.Default.GetBytes(insertContent, 0, insertContent.Length); ;
                //根据传入的配置文件中来决定是否同步或一部实例化stream对象
                FileStream stream = createFileConfig.IsAsync ? new FileStream(createFileConfig.CreateUrl, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, true)
                    : new FileStream(createFileConfig.CreateUrl, FileMode.Create);
                using(stream)
                {
                    //如果该流是同步流且可写
                    if(!stream.IsAsync && stream.CanWrite)
                    {
                        stream.WriteTimeout = READ_OR_WRITE_TIMEOUT;
                        stream.Write(byteArrayContent, 0, byteArrayContent.Length);
                    }
                    else if(stream.CanWrite) //异步流且可写
                    {
                        stream.BeginWrite(byteArrayContent, 0, byteArrayContent.Length, this.End_CreateFileCallBack, stream);
                        stream.Close();
                    }
                }
            }
        }

        private void End_CreateFileCallBack(IAsyncResult result)
        {
            //从IAsyncResult对象中得到原来的FileStream
            var stream = result.AsyncState as FileStream;
            //结束异步写

            Console.WriteLine("异步创建文件地址：{0}", stream.Name);
            stream.EndWrite(result);
            Console.ReadLine();
        }

        /// <summary>
        /// 文件复制
        /// </summary>
        /// <param name="config">拷贝文件复制</param>
        public void Copy(IFileConfig config)
        {
            lock (_lockObject)
            {
                //得到CopyFileConfig对象
                var copyFileConfig = config as CopyFileConfig;
                //检查CopyFileConfig类对象是否为空 或OrginalFileUrl是否为空
                if (CheckConfigIsError(copyFileConfig) || !File.Exists(copyFileConfig.OriginFileUrl))
                {
                    return;
                }
                //创建同步或异步流
                FileStream stream = copyFileConfig.IsAsync ?
                    new FileStream(copyFileConfig.OriginFileUrl, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true)
                    : new FileStream(copyFileConfig.OriginFileUrl, FileMode.Open);

                //定义一个byte数组接受从源文件读出的byte数据
                byte[] originalFileBytes = new byte[stream.Length];
                using(stream)
                {
                    //异步读取
                    if (stream.IsAsync)
                    {
                        //将流和读出的byte[]数据放入配置类 在callBack中可以使用
                        copyFileConfig.OriginalFileStream = stream;
                        copyFileConfig.OriginalFileBytes = originalFileBytes;

                        if (stream.CanRead)
                        {
                            //异步开始读取 读完后进入End_ReadFileCallBack方法 该方法接受copyFileConfig参数
                            stream.BeginRead(originalFileBytes, 0, originalFileBytes.Length, End_ReadFileCallBack, copyFileConfig);
                        }
                    }
                    else //同步读取
                    {
                        if(stream.CanRead)
                        {
                            //一般读取源文件
                            stream.Read(originalFileBytes, 0, originalFileBytes.Length);
                        }
                        //定义一个写流 在新位置创建文件
                        FileStream copyStream = new FileStream(copyFileConfig.DestinationFileUrl, FileMode.CreateNew);
                        using(copyStream)
                        {
                            //copyStream.WriteTimeout = READ_OR_WRITE_TIMEOUT;
                            //将源文件的内容写进新文件
                            copyStream.Write(originalFileBytes, 0, originalFileBytes.Length);
                            copyStream.Close();
                        }
                    }
                    stream.Close();
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 异步读写文件方法
        /// </summary>
        /// <param name="result"></param>
        private void End_ReadFileCallBack(IAsyncResult result)
        {
            //得到先前的配置文件
            var config = result.AsyncState as CopyFileConfig;
            //结束异步读
            config.OriginalFileStream.EndRead(result);
            //异步读后立即写入新文件地址
            if (File.Exists(config.DestinationFileUrl))
            {
                File.Delete(config.DestinationFileUrl);
            }
            //这样创建的不是异步的，不能执行stream.EndWrite(result); 会抛异常的，
            //FileStream copyStream = new FileStream(config.DestinationFileUrl, FileMode.CreateNew);
            FileStream copyStream = new FileStream(config.DestinationFileUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read, 4096, true);
            using (copyStream)
            {
                Console.WriteLine("异步复制原文件地址：{0}", config.OriginalFileStream.Name);
                Console.WriteLine("复制后的新文件地址：{0}", config.DestinationFileUrl);
                //调用异步写方法CallBack方法为End_CreateFileCallBack 参数是copyStream
                copyStream.BeginWrite(config.OriginalFileBytes, 0, config.OriginalFileBytes.Length, this.End_CreateFileCallBack, copyStream);
                copyStream.Close();
            }
        }
    }
}
