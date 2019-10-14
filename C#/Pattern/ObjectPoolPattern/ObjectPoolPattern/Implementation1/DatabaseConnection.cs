using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern.Implementation1
{
    public class DatabaseConnection : IDisposable
    {
        // do some heavy works
        public DatabaseConnection(string connectionString)
        {

        }

        public bool isOpen { get; set; }

        // release something
        public void Dispose()
        {

        }
    }
}
