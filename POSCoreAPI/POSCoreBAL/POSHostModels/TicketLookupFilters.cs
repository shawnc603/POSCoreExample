using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum TicketLookUpFilters : ulong
    {
        /// <summary>
        /// Get All Tickets
        /// </summary>
        All,
        /// <summary>
        /// Get All Tickets for User
        /// </summary>
        Users,
        /// <summary>
        /// Get by Ticket Name
        /// </summary>
        ByTicketName,
        /// <summary>
        /// Get by Ticket ID
        /// </summary>
        ByTicketID,
        /// <summary>
        /// Get By User ID
        /// </summary>
        ByUserID,
        /// <summary>
        /// Get By Table Name
        /// </summary>
        ByTableName,
        /// <summary>
        /// Get By Table ID
        /// </summary>
        ByTableID
    }
}
