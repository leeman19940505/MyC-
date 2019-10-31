using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void OldCollection()
        {
            object[] values = { "a", "b", "c", "d", "e" };
            IterationSample collection = new IterationSample(values, 3);
            foreach(object x in collection)
            {
                Console.WriteLine(x);
            }
        }
    }
}
