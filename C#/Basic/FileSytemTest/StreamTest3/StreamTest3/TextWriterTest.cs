using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest3
{
    //构造函数 TextWriter()
    //TextWriter(IFormatProvider)
    //IFormatProvider IFormatProvider 提供了一个格式化的工具 string.format(“{0:P}”,data);么? IFormatProvider在这里被隐式的调用

    //TextWriter属性
    //Encoding 可以获得当前TextWriter的Encoding
    //FormatProvider 可以获得当前TextWriter的IFormatProvider
    //NewLine 每当调用WriteLine()方法时，行结束符字符串都会写入到文本流中,该属性就是读取该结束符字符串

    //方法
    //Close() :关闭TextWriter并且释放TextWriter的资源
    //Dispose(): 释放TextWriter所占有的所有资源(和StreamReader相似，一旦TextWriter被释放，它所占有的资源例如Stream会一并释放)
    //Flush() : 和Stream类中一样，将缓冲区所有数据立刻写入文件（基础设备）
    //Write()方法的重载（这个方法重载太多了，所以这里就不全写出了，大家可以参考最后一个例子的打印结果）
    //WriteLine()方法的重载：和Write()方法相比区别在于每个重载执行完毕之后会附加写入一个换行符
    class TextWriterTest
    {
    }
}
