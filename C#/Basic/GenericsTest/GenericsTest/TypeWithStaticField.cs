using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTest
{
    //每个封闭的泛型类型中都有仅属于它自己的静态数据
    //泛型类型，具有一个类型参数 
    public static class TypeWithStaticField<T>
    {
        //静态字段
        public static string field;

        //静态构造方法
        public static void OutField()
        {
            Console.WriteLine(field + ":" + typeof(T).Name);
        }
    }

    public static class NoGernericTypeWidthStaticField
    {
        public static string field;
        public static void OutField()
        {
            Console.WriteLine(field);
        }
    }

    public static class GenericClass<T>
    {
        //静态构造函数
        static GenericClass()
        {
            Console.WriteLine("泛型类型：" + typeof(T));
        }

        //静态方法
        public static void Print()
        {

        }
    }

    public static class NonGenericClass
    {
        static NonGenericClass()
        {
            Console.WriteLine("非泛型");
        }

        public static void Print()
        {

        }
    }

}
