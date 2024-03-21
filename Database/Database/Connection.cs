using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    public abstract class Connection
    {
        public abstract void OpenConnection();
        public abstract void CloseConnection();
        public abstract List<User> QueryUsers(); 
    }

}
