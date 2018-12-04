using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class Bill
    {

        public  decimal Subtotal { get; set; }


        public  decimal PaymentsTotal { get; set; }


        public  decimal DiscountTotal { get; set; }


        public  decimal ServiceChargeTotal { get; set; }


        public  decimal GratuityTotal { get; set; }


        public  decimal TipTotal { get; set; }


        public  decimal TaxTotal { get; set; }


        public  decimal Total { get; set; }
     
    }
}
