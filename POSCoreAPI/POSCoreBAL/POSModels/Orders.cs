using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQty{ get; set; }

    }
}
