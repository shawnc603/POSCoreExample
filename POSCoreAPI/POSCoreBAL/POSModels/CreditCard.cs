using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public int PaymentId { get; set; }

        public string CardType { get; set; }

        public string PanHash  { get; set; }

        public string PANLast4 { get; set; }

        public string ExpYear { get; set; }

        public string ExpMonth { get; set; }
    }
}
