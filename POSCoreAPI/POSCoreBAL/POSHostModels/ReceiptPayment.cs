using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class ReceiptPayment
    {
        public ReceiptPayment() { }

        public string type { get; set; }

        /// <summary>
        /// The tender type for this payment 
        /// </summary>
        public virtual string POSTenderType { get; set; }

        /// <summary>
        /// data for payment processing
        /// </summary>
        public CardInfo CardData { get; set; }

        /// <summary>
        /// authorization code retured from payment process service
        /// </summary>        
        public string AuthCode { get; set; }

        /// <summary>
        /// The resposne code from pyament process service
        /// </summary>
        public virtual string TransactionCode { get; set; }
    }
}   
