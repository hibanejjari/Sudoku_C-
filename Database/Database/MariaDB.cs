using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    public class MariaDB : Connection
    {
        public override void OpenConnection()
        {
            // Your implementation
        }

        public override void CloseConnection()
        {
            // Your implementation
        }

        public override List<User> QueryUsers()
        {
            // Your implementation, make sure it returns List<User>
            return new List<User>(); // Placeholder
        }
    }

}
