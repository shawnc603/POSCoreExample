using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSCoreBAL.POSModels
{
    public class ModelFetchTickets
    {
        /// <summary>
        /// The ID of the user at POS DB
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The PIN of the user for logging in POS system
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Ticket ID
        /// </summary>
        public int TicketID { get; set; }

        /// <summary>
        /// The check number
        /// </summary>
        public string CheckNumber { get; set; }

        /// <summary>
        /// The name of the table
        /// </summary>
        public string TableName { get; set; }
    }
}

