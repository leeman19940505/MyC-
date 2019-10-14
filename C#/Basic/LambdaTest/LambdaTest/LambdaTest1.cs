using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTest
{
    class LambdaTest1
    {
        public LambdaTest1()
        {
            //Lambda表达式
            //封装一个具有一个参数并返回 TResult 参数指定的类型值的方法。
            //1.0 参数为string 返回值为int
            Func<string, int> delegatetest1 = new Func<string, int>(Callbackmethod);

            //2.0 使用匿名方法来创建委托实例 此时不需要额外定义回调方法Callbackmethod
            Func<string, int> delegatetest2 = delegate (string text)
            {
                return text.Length;
            };

            //3.0 使用Lambda表达式来创建委托实例
            Func<string, int> delegatetest3 = (string text) => text.Length;

            //省略参数类型string
            Func<string, int> delegatetest4 = (text) => text.Length;

            //省略圆括号
            Func<string, int> delegatetest = text => text.Length;

            //调用委托
            Console.WriteLine("使用Lambda表达式返回字符串的长度为：" + delegatetest("learning hard"));
            Console.Read();
        }

        //回调方法
        private static int Callbackmethod(string text)
        {
            return text.Length;
        }
    }
}
