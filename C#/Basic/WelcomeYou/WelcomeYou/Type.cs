using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    //值类型(->ValueType->System.Object)和引用类型(->Sytem.Object)
    //内存分布的不同
    //值类型分配到线程的堆栈上 引用类型分配到托管堆上；值类型的管理由操作系统负责 引用类型的管理由垃圾回收器（GC）负责
    //值类型的变量和实际数据都存储在堆栈中 引用类型则只将变量存储在堆栈中，实际数据存储在与地址（变量存储实际数据的地址）对应的托管堆中
    class Type
    {
        //值类型 枚举类型
        enum valueEnum : int
        {

        }

        //值类型 结构体类型
        struct valueStruct
        {

        }

        //值类型
        public void ValueType()
        {
            //简单类型

            //有符号整数
            int valueInt = 0;
            long valueLong = 0;
            short valueShort = 0;
            sbyte valueSbyte = 0;

            //无符号整数
            uint valueUint = 0;
            ulong valueUlong = 0;
            ushort valueUshot = 0;
            byte valueByte = 0;

            //字符类型 
            char valueChar = 'a';

            //浮点型
            float valueFloat = 0;
            double valueDouble = 0;
            decimal valueDecimal = 0;

            //布尔类型
            bool valueBool = true;
        }

        //引用类型
        public void ReferenceType()
        {
            //类类型
            //字符串类型
            string valueString = "a";

            //类类型 Console类和自己定义的类类型

            //数组类型
            int[] valueArray = new int[] { 1, 2, 3, 4, 5, 6 };

            //接口类型
            //委托类型
        }

        //值类型装箱 引用类型中嵌套值类型时 值类型不会被分配到线程栈上 值类型的实例会被分配到托管堆中
        //引用类型中嵌套定义值类型
        NestedValueTypeInRef reftype = new NestedValueTypeInRef();

        //值类型中嵌套定义引用类型 堆栈上保存该引用类型的引用 实际的数据依然保存在托管堆中
        NestedRefTypeInValue valuetype = new NestedRefTypeInValue(new TestClass());

        //四种转换方式
        //隐式类型转换 

        //显式类型转换（强制类型转换）

        //is as运算符进行安全的类型转换

        //.NET类库中的Convert类来完成类型转换

        public void trans()
        {
            //值类型与引用类型之间的转换 装箱（值类型转换为引用类型）和拆箱（引用类型转换为值类型）
            int i = 3;
            //装箱 系统在托管堆中生成一份堆栈中值类型对象的副本
            //内存分配
            //实际数据的复制
            //地址返回
            object o = i;
            //拆箱 托管堆中将引用类型所指向的已装箱数据复制回值类型对象     
            int y = (int)o;
        }

        //参数传递 形参 方法定义中的参数； 实参 调用方法时传递给对应参数的值
        //值类型参数按值传递
        //传递的时该值类型实例的一个副本 形参接收到额时实参的一个副本 方法中对参数的改变不会影响实参的值
        
        //int addNum = 1;
        //Add(addNum); //addNum就是实参

        //值类型参数按值传递
        private static void Add(int addnum)
        {
            addnum = addnum + 1;
            Console.WriteLine(addnum);
        }

        //引用类型参数按值传递
        //传递的实际内容时对地址的复制 由于地址指向的是实参的值 当方法对地址进行操作时 实际上操作了地址所指向的值 所以调用方法后原来实参的值会被修改
        //特殊情况 string作为引用类型 在按值传递时 传递的实参不会因为方法中形参的改变而被修改

        //值类型参数按引用传递

        //引用类型参数按引用传递
    }

     //引用类型中嵌套定义值类型
    public class NestedValueTypeInRef
    {
        //valuetype作为引用类型的一部分被分配到托管堆中
        private int valuetype = 3;

        public void method()
        {
            //c被分配到线程栈上
            char c = 'c';
        }
    }

    //值类型中嵌套定义引用类型
    public class TestClass
    {
        public int x;
        public int y;
    }

    public struct NestedRefTypeInValue
    {
        //结构体中字段不能被初始化
        private TestClass classinValuetype;

        //结构体中不能定义无参的构造函数 
        public NestedRefTypeInValue(TestClass t)
        {
            classinValuetype = t;
            classinValuetype.x = 3;
            classinValuetype.y = 5;
        }
    }

   

}
