using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    public class PostgreSQL : Connection
    {
        public override void OpenConnection()
        {

            Console.WriteLine("Opening PostgreSQL connection...");
        }

        public override void CloseConnection()
        {

            Console.WriteLine("Closing PostgreSQL connection...");
        }

        public override List<User> QueryUsers()
        {
            Console.WriteLine("Querying users from PostgreSQL...");
            return new List<User>();
        }
    }
}