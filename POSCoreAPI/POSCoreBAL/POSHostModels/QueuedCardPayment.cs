using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{

    public class QueuedCardPayment: QueuedPaymentBase 
    {
        /// <summary>
        /// The card details for card payment
        /// </summary>
        public CardInfo CardData { get; set; }
    }
}
