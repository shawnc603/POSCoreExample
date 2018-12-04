using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class TicketBill : Ticket
    {
        public TicketBill()
        {
            Check = new Bill();
            Items = new List<OrderItem>();
            POSPayments = new List<PaymentInfo>();
        }

        /// <summary>
        /// Bill object for POS Ticket
        /// </summary>
        public Bill Check { get; set; }

        /// <summary>
        /// Items of POS Ticket
        /// </summary>
        public List<OrderItem> Items { get; set; }

        /// <summary>
        /// Payments made at the POS
        /// </summary>
        public List<PaymentInfo> POSPayments { get; set; }
    }
}
