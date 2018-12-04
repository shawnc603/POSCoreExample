using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class ReceiptData
    {
        public List<OrderItems> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal TipTotal { get; set; }
        public decimal PaymentTotal { get; set; }
        public string status { get; set; }
    }

    public class OrderItems
    {
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
