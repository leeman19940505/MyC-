using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern.Implementation1
{
    class Client
    {
        public static void TestCase1()
        {
            //Create the ConnectionPool;
            DatabaseConnectionPool pool = new DatabaseConnectionPool("Data Source=DENNIS;Initial Catalog=TESTDB;Integrated Security=True;");

            //Get a connection
            DatabaseConnection connection = pool.CheckOut();

            //Use the connection 

            //Return the conection
            pool.CheckIn(connection);
        }
    }
}
