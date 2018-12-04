using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class QueuedPaymentTicket
    {
        /// <summary>
        /// The ID of the ticket at POS DB
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the ticket
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of the ticket (POS receipt used to be a different number than ID)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The ID of the table. Only a few POS use the value, default to 0
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// The ID of department or section. Only a few POS use the value, default to 0
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// The person who creates the ticket
        /// </summary>
        public UserAccount Owner { get; set; }
    }
}
