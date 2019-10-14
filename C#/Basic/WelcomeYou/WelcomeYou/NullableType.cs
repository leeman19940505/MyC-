using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    //可空类型
    class NullableType
    {
        private static void Display(int? nullable)
        {
            //HasValue属性指示可空对象是否有值
            Console.WriteLine("可空类型是否有值：{0}", nullable.HasValue);
            if(nullable.HasValue)
            {
                Console.WriteLine("值为: {0}", nullable.HasValue);
            }

            //GetValueOrDefault(代表如果可空对象有值，就用它的值返回，如果可空对象不包含值 则默认返回0)
            Console.WriteLine("GetValueorDefault():{0}", nullable.GetValueOrDefault());

            //GetValueOrDefault
        }
    }
}
