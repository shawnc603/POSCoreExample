using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class QueuedPaymentBase
    {
        /// <summary>
        /// An ID to query payment status from TDC later
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// The tender type for this payment 
        /// </summary>
        public string POSTenderType { get; set; }

        /// <summary>
        /// User applys the payemnt
        /// </summary>
        /// <remarks>This is the user to close the ticket in POS, which also get the tips of the ticket.</remarks>
        public UserAccount User { get; set; }

        public QueuedPaymentTicket Ticket { get; set; }

        /// <summary>
        /// The payment amount that applys to
        /// </summary>
        public Decimal Amount { get; set; }
        /// <summary>
        /// The tip amount that applys to
        /// </summary>
        public Decimal Tip { get; set; }

        /// <summary>
        /// The reference code for paypal payments
        /// </summary>
        public string ReferenceCode { get; set; }

        /// <summary>
        /// Information needed for printing receipts.  Only a few POS use the object
        /// </summary>
        public PrintingInfo PrintingInfo { get; set; }
    }
}
