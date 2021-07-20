using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repo
{   // POCO
    public class Developer
    {
        public string Name { get; set; }
        public int IDNumber { get; set; }
        public bool PluralsightAccess { get; set; }

        public Developer() { }
        public Developer(string name, int idNumber, bool pluralsightAccess)
        {
            Name = name;
            IDNumber = idNumber;
            PluralsightAccess = pluralsightAccess;
        }

        
    }
}
