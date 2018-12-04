using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class SettleTicketsModel
    {
        public UserAccount userAccount { get; set; }
        public Ticket ticket { get; set; }
    }
}
