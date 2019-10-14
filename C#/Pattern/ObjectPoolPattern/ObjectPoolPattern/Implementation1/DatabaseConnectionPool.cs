using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern.Implementation1
{
    public class DatabaseConnectionPool : ObjectPool<DatabaseConnection>
    {
        private string _connectionString;

        /// <summary>
        /// base其实最大的使用地方在面相对象开发的多态性上，
        /// base可以完成创建派生类实例时调用其基类构造函数或者调用基类上已被其他方法重写的方法。
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseConnectionPool(string connectionString) : base(TimeSpan.FromMinutes(1))
        {
            this._connectionString = connectionString;
        }

        public override void Expire(DatabaseConnection connection)
        {
            connection.Dispose();
        }

        public override bool Validate(DatabaseConnection connection)
        {
            return connection.isOpen;
        }

        protected override DatabaseConnection Create()
        {
            return new DatabaseConnection(_connectionString);
        }
    }
}
