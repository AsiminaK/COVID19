using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19
{
    [Serializable]
    class USERS
    {
        public string name;
        public string password;

        public USERS(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
