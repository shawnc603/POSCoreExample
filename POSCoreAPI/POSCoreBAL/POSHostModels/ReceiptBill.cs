using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace POSCoreBAL.POSHostModels
{
    public class ReceiptBill
    {
        public  NameValuePair Subtotal { get; set; }

        public  NameValuePair PaymentsTotal { get; set; }

        public  NameValuePair DiscountTotal { get; set; }

        public  NameValuePair ServiceChargeTotal { get; set; }

        public  NameValuePair SurchargeTotal { get; set; }

        public  NameValuePair GratuityTotal { get; set; }

        public  NameValuePair TipTotal { get; set; }

        public  NameValuePair TaxTotal { get; set; }

        public  NameValuePair Total { get; set; }
    }
}
