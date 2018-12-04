using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public int GatewayPaymentId { get; set; }
        public string AuthCode { get; set; }
        public string TransactionCode { get; set; }
        public string PostenderType { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? TipTotal { get; set; }
        public decimal? PaymentTotal { get; set; }
        public DateTime? CreatedTime { get; set; }

        public List<CreditCard> Creditcard { get; set; }

    }
}
