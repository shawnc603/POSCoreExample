using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class PaymentInfo
    {
        /// <summary>
        /// Amount of the Payment
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Tender name of Payment
        /// </summary>
        public string TenderName { get; set; }
    }
}
