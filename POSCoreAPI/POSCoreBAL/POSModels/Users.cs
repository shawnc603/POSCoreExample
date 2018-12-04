using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class Users
    {
        public int ID { get; set; }

        public string PIN { get; set; }

        public string Name { get; set; }

        public List<Tickets> Tickets { get; set; }
    }
}
