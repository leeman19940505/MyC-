using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethodsTest
{
    class Program
    {
        //定义投票委托
        delegate void VoteDelegate(string name);
        static void Main(string[] args)
        {
            //使用Vote方法来实例化委托对象
            //VoteDelegate votedelegate = new VoteDelegate(new Friend().Vote);
            //隐式实例化委托方式 将方法直接赋
            //VoteDelegate voteDelegate = new Friend().Vote;

            //使用匿名方法来实例化委托对象
            //使用匿名方法 不再需要单独定义一个Vote方法
            //匿名方法缺点 不能再其他地方被调用 不具有复用性

            //匿名方法自动形成闭包 当一个函数对另一个函数的调用时，或当内部函数使用了外部函数的变量时，都会形成闭包
            VoteDelegate votedelegate = delegate (string nickname)
            {
                Console.WriteLine("昵称为： {0}", nickname);
            };

            //通过调用委托来回调Vote()方法 这是隐私调用方式
            votedelegate("SomeBody");
            Console.Read();
        }

        public class Friend
        {
            //朋友的投票方法
            public void Vote(string nickname)
            {
                Console.WriteLine("昵称为： {0}", nickname);
            }
        }
    }
}
