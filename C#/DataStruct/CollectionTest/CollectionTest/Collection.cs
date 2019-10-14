using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class Collection : CollectionBase
    {
        public void Add(Object item)
        {
            InnerList.Add(item);
        }

        public void Remove(Object item)
        {
            InnerList.Remove(item);
        }

        //new 修饰符：在用作修饰符时，new关键字可以显式隐藏从基类继承的成员
        public new void Clear()
        {
            InnerList.Clear();
        }

        public new int Count()
        {
            return InnerList.Count;
        }

        public void Insert(int index, Object item)
        {
            InnerList.Insert(index, item);
        }

        public bool Contains(Object item)
        {
            return InnerList.Contains(item);
        }
    }
}
