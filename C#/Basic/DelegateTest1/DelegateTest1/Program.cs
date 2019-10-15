using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTest1
{
    //声明一个委托类型 它的实例引用一个方法 (委托要指定一个回调方法签名)
    //该方法获取一个Int32参数 返回void
    internal delegate void Feedback(Int32 value);

    //internal class Feedback : System.MulticastDelegate
    //{
    //    //构造器
    //    public Feedback(Object @object, IntPtr method);

    //    //这个方法的原型和源代码指定的一样
    //    public virtual void Invoke(Int32 value);

    //    //以下方法实现对回调方法的异步调用
    //    public virtual IAsyncResult BeginInvoke(Int32 value, AsyncCallback callback, Object @object);
    //    public virtual void EndInvoke(IAsyncResult result);
    //}

    /// <summary>
    /// 使用vs开发人员命令提示符运行 csc name.cs生成 -> name执行
    /// 将方法绑定到委托时 允许引用类型的协变性和逆变性 只有应用类型才支持
    /// 协变：方法能返回从委托的返回类型派生的一个类型
    /// 逆变：方法获取的参数可以是委托的参数类型的基类
    /// </summary>
    public sealed class Program
    {
        static void Main(string[] args)
        {
            StaticDelegateDemo();
            InstanceDelegateDemo();

            ChainDelegateDemo1(new Program());
            ChainDelegateDemo2(new Program());
        }

        private static void ChainDelegateDemo1(Program p)
        {
            Console.WriteLine("---- Chain Delegate Demo 1 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);

            Feedback fbChain = null;
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb3);
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain = (Feedback)Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            Counter(1, 2, fbChain);
        }

        private static void ChainDelegateDemo2(Program p)
        {
            Console.WriteLine("----- Chain Delegate Demo 2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);

            Feedback fbChain = null;
            fbChain += fb1;
            fbChain += fb2;
            fbChain += fb3;
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain -= new Feedback(FeedbackToMsgBox);
            Counter(1, 2, fbChain);
        }

        /// <summary>
        /// 实例方法
        /// </summary>
        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("----- Instance Delegate Demo");
            Program p = new Program();
            Counter(1, 3, new Feedback(p.FeedbackToFile));
            Console.WriteLine();
        }

        private void FeedbackToFile(Int32 value)
        {
            using (StreamWriter sw = new StreamWriter("Status", true))
            {
                sw.WriteLine("Item=" + value);
            }
        }

        /// <summary>
        /// 委托回调静态方法
        /// </summary>
        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----- Static Delegate Demo -----");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(Program.FeedbackToConsole));
            Counter(1, 3, new Feedback(Program.FeedbackToMsgBox));
            Console.WriteLine();
        }

        private static void FeedbackToMsgBox(int value)
        {
            MessageBox.Show("Item=" + value);
        }

        private static void FeedbackToConsole(int value)
        {
            Console.WriteLine("Item=" + value);
        }

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for(Int32 val = from; val <= to; val++)
            {
                //如果指定了任何回调 就调用
                if(fb != null)
                {
                    fb(val);
                }
            }
        }

        

    }
}
