using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTest
{
    class LambdaTest3
    {
        /// <summary>
        /// 表达式树 表示Lambda表达式逻辑的一种数据结构
        /// </summary>
        public LambdaTest3()
        {
            //LambdaTree();
            TestLambdaTree();
            //DynamicTree();
        }

        private void TestLambdaTree()
        {
            //将Lambda表达式构造成表达式树
            Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;
            //通过调用Compile方法来生成Lambda表达式的委托
            Func<int, int, int> delinstance = expressionTree.Compile();
            //调用委托
            int result = delinstance(2, 3);
            Console.WriteLine(result);
            Console.Read();
        }

        private void DynamicTree()
        {
            //动态构造"a+b"的表达式树结构
            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");

            //表达式树的主体部分
            BinaryExpression be = Expression.Add(a, b);

            //构造表达式树
            Expression<Func<int, int, int>> expressionTree = Expression.Lambda<Func<int, int, int>>(be, a, b);

            //分析树结构 获取表达式树的主体部分
            BinaryExpression body = (BinaryExpression)expressionTree.Body;

            //左节点 每个节点本身就是一个表达式对象
            ParameterExpression left = (ParameterExpression)body.Left;

            //右节点
            ParameterExpression right = (ParameterExpression)body.Right;

            //输出表达式树结构
            Console.WriteLine("表达式树结构为：" + expressionTree);

            //输出
            Console.WriteLine("表达式树主体为：");
            Console.WriteLine(expressionTree.Body);
            Console.WriteLine("左节点: {0}{4} 节点类型：{1}{4}{4} 右节点：{2}{4} 节点类型{3}{4}", left.Name, left.Type, right.Name, right.Type, Environment.NewLine);
            Console.Read();
        }

        private void LambdaTree()
        {
            //将Lambda表达式构造成表达式树
            Expression<Func<int, int, int>> expressionTree = (a, b) => a + b;

            //获得表达式树参数
            Console.WriteLine("参数1：{0}， 参数2{1}", expressionTree.Parameters[0], expressionTree.Parameters[1]);
            //获取表达式树的主体部分
            BinaryExpression body = (BinaryExpression)expressionTree.Body;

            //左节点
            ParameterExpression left = (ParameterExpression)body.Left;

            //右节点
            ParameterExpression right = (ParameterExpression)body.Right;

            Console.WriteLine("表达式树主体为：");
            Console.WriteLine(expressionTree.Body);
            Console.WriteLine("左节点: {0}{4} 节点类型：{1}{4}{4} 右节点：{2}{4} 节点类型{3}{4}", left.Name, left.Type, right.Name, right.Type, Environment.NewLine);
            Console.Read();
        }
    }
}
