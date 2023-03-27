using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19
{
    class CovidCases
    {
        public string name;
        public string lastname;
        public string sex;
        public string birthday;

        public CovidCases(string name, string lastname, string sex, string birthday)
        {
            this.name = name;
            this.lastname = lastname;
            this.sex = sex;
            this.birthday = birthday;
        }
    }
}
