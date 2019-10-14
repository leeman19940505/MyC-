using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTest
{
    //未绑定泛型 已构造泛型 (泛型类型参数是否提供实际类型)
    //已构造泛型分为 开发类型 封闭类型（）
    //泛型是延迟声明的 即定义的时候没有指定具体的参数类型 把参数类型的声明推迟到调用的时候才指定参数类型
    public class DictionaryStringKey<T> : Dictionary<string, T>
    {

    }

    //泛型 使类型可以被参数化 提供了代码重用的另一种机制（继承）
    //提供更好的性能和类型安全特性 （值类型和引用类型转换时的性能损失）
    class Program
    {
        static void Main(string[] args)
        {
            //用int作为实际参数来初始化泛型类型
            List<int> intList = new List<int>();
            //从int列表添加元素3
            intList.Add(3);

            //用string作为实际参数来初始化泛型类型
            List<string> stringList = new List<string>();
            //从string列表添加元素
            stringList.Add("learninghard");

            //使用泛型
            Compare<int>.compareGeneric(3, 4);
            Compare<string>.compareGeneric("abc", "a");

            //测试泛型类型的运行时间 
            testGeneric();
            //测试非泛型类型的运行时间 非泛型ArrayList的Add(object value)需要将int转为object
            testNonGeneric();

            //泛型类型
            //开放类型 有两个类型参数
            Type t = typeof(Dictionary<,>);
            Console.WriteLine(t.ContainsGenericParameters);
            //开放类型 只有一个类型参数
            t = typeof(DictionaryStringKey<>);
            Console.WriteLine(t.ContainsGenericParameters);
            //封闭类型
            t = typeof(DictionaryStringKey<int>);
            Console.WriteLine(t.ContainsGenericParameters);
            //封闭类型
            t = typeof(Dictionary<int, int>);
            Console.WriteLine(t.ContainsGenericParameters);

            //静态字段和静态函数 每个封闭的泛型类都有属于自己的静态字段
            //在使用实际类型参数代替泛型参数时 编译器会根据不同的类型实参 重新生成类型
            TypeWithStaticField<int>.field = "一";
            TypeWithStaticField<string>.field = "二";
            TypeWithStaticField<Guid>.field = "三";

            NoGernericTypeWidthStaticField.field = "非泛型一";
            NoGernericTypeWidthStaticField.field = "非泛型二";
            NoGernericTypeWidthStaticField.field = "非泛型三";

            NoGernericTypeWidthStaticField.OutField();

            TypeWithStaticField<int>.OutField();
            TypeWithStaticField<string>.OutField();
            TypeWithStaticField<Guid>.OutField();

            //每个封闭泛型类型都会调用其构造函数
            GenericClass<int>.Print();
            GenericClass<string>.Print();

            //非泛型类型，其构造函数只会调用一次
            NonGenericClass.Print();
            NonGenericClass.Print();

            //类型参数的推断
            int n1 = 1;
            int n2 = 2;
            genericMethod<int>(ref n1, ref n2);
            genericMethod(ref n1, ref n2);

            Console.ReadKey();
        }

        //类型参数推断
        //关于ref
        private static void genericMethod<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        public static void testGeneric()
        {
            //Stopwatch对象用来测量运行时间
            Stopwatch stopwatch = new Stopwatch();
            //泛型数组
            List<int> genericlist = new List<int>();
            //开始计时
            stopwatch.Start();
            for(int i = 1; i < 10000000; i++)
            {
                genericlist.Add(i);
            }

            //结束计时
            stopwatch.Stop();

            //输出所用的时间
            TimeSpan ts = stopwatch.Elapsed;
            //使时间以00：00格式输出
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("泛型类型运行时间： " + elapsedTime);
        }

        public static void testNonGeneric()
        {
            //Stopwatch对象用来测量运行时间
            Stopwatch stopwatch = new Stopwatch();
            ArrayList arrayList = new ArrayList();
            stopwatch.Start();
            for (int i = 1; i < 10000000; i++)
            {
                arrayList.Add(i);
            }

            //结束计时
            stopwatch.Stop();

            //输出所用的时间
            TimeSpan ts = stopwatch.Elapsed;
            //使时间以00：00格式输出
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("非泛型类型运行时间： " + elapsedTime);
        }

        //比较整数大小
        //public static int compareInt(int int1, int int2)
        //{
        //    if (int1.CompareTo(int2) > 0)
        //    {
        //        return int1;
        //    }
        //    else;
        //    {
        //        return int2;
        //    }
        //}

        //比较字符串大小
        //public static string compareString(string str1, string str2)
        //{
        //    if(str1.CompareTo(str2) > 0)
        //    {
        //        return str1;
        //    }
        //    else
        //    {
        //        return str2;
        //    }
        //}

        //约束
        //引用类型约束 传入的类型实参必须是System.IO.Stream 或其派生类
        public class samplereference<T> where T : Stream
        {
            public void Test(T stream)
            {
                stream.Close();
            }
        }

        //值类型约束 传递的类型实参必须是值类型（包括枚举）
        public class samplevaluetype<T> where T : struct
        {
            public static T Test()
            {
                return new T();
            }
        }

        //转换类型约束
        //组合约束 多个不同种类的约束合并

    }
}
