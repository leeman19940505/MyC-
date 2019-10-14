using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern.Implementation2
{
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> _objectFactory;
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
    }
}
