using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern.Implementation1
{
    /// <summary>
    /// 实现DatabaseConnectionPool类
    /// 如果 Client 调用 ObjectPool 的 AcquireReusable() 方法来获取 Reusable 对象，
    /// 当在 ObjectPool 中存在可用的 Reusable 对象时，其将一个 Reusable 从池中移除，然后返回该对象。
    /// 如果池为空，则 ObjectPool 会创建一个新的 Reusable 对象。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObjectPool<T>
    {
        private TimeSpan _expirationTime;
        private Dictionary<T, DateTime> _unlocked;
        private Dictionary<T, DateTime> _locked;
        /// <summary>
        /// 使用了readonly的属性，只能在定义时，或者构造函数中初始化，其他的地方都不能再修改其值
        /// </summary>
        private readonly object _sync = new object();

        public ObjectPool()
        {
            _expirationTime = TimeSpan.FromSeconds(30);
            _locked = new Dictionary<T, DateTime>();
            _unlocked = new Dictionary<T, DateTime>();
        }

        /// <summary>
        /// 调用无参的构造方法
        /// </summary>
        /// <param name="expirationTime"></param>
        public ObjectPool(TimeSpan expirationTime) : this()
        {
            _expirationTime = expirationTime;
        }

        protected abstract T Create();

        public abstract bool Validate(T reusable);

        public abstract void Expire(T reusable);

        /// <summary>
        /// 在 C# 中不允许使用未初始化的变量 default(T)可以得到该类型的默认值
        /// </summary>
        /// <returns></returns>
        public T CheckOut()
        {
            lock(_sync)
            {
                T reusable = default(T);

                if(_unlocked.Count > 0)
                {
                    foreach(var item in _unlocked)
                    {
                        if ((DateTime.UtcNow - item.Value) > _expirationTime)
                        {
                            // object has expired
                            _unlocked.Remove(item.Key);
                            Expire(item.Key);
                        }
                        else
                        {
                            if (Validate(item.Key))
                            {
                                // find a reusable object
                                _unlocked.Remove(item.Key);
                                _locked.Add(item.Key, DateTime.UtcNow);
                                reusable = item.Key;
                                break;
                            }
                            else
                            {
                                // object failed validation
                                _unlocked.Remove(item.Key);
                                Expire(item.Key);
                            }
                        }
                    }
                }

                // no object available, create a new one
                if(reusable == null)
                {
                    reusable = Create();
                    _locked.Add(reusable, DateTime.UtcNow);
                }

                return reusable;
            }
        }

        public void CheckIn(T reusable)
        {
            lock(_sync)
            {
                _locked.Remove(reusable);
                _unlocked.Add(reusable, DateTime.UtcNow);
            }
        }

    }
}
