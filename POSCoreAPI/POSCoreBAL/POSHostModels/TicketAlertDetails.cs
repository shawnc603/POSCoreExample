using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum TicketAlertDetails 
    {
        /// <summary>
        /// No reason
        /// </summary>
        None = 0,
        /// <summary>
        /// Unable to determine how to apply discounts
        /// </summary>
        IndeterminateDiscounts = 1,
        /// <summary>
        /// Ticket makes use of transfers
        /// </summary>
        TicketHasTransfers = 2,
        /// <summary>
        /// Ticket has payments applied to it
        /// </summary>
        ExistingPayments = 4,
        /// <summary>
        /// Ticket has insufficient beverage 
        /// </summary>  
        InsufficientBeverage = 8,
    }
}
