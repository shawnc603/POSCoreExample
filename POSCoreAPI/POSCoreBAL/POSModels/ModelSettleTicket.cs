using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSCoreBAL.POSHostModels;

namespace POSCoreBAL.POSModels
{
    public class ModelSettleTicket
    {
        public UserAccount UserAccount { get; set; }
        public QueuedPaymentTicket Ticket { get; set; }
    }
}

