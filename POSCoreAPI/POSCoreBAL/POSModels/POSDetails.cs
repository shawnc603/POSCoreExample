using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class POSDetails
    {

        public int UserID { get; set; }
        public string PIN { get; set; }
        public string Name { get; set; }
        public int TicketId { get; set; }
        public string TableName { get; set; }
        public int TableNumber { get; set; }
        public int DepartmentId { get; set; }
        public int GuestCount { get; set; }
        public decimal Balance { get; set; }
        public int OrderId { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int GatewayPaymentId { get; set; }
        public string AuthCode { get; set; }
        public string TransactionCode { get; set; }
        public string POSTenderType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal TipTotal { get; set; }
        public decimal PaymentTotal { get; set; }
        public int CreditCardId { get; set; }
        public int PaymentId { get; set; }
        public string CardType { get; set; }
        public string PanHash { get; set; }
        public string PanLast4 { get; set; }
        public string ExpYear { get; set; }
        public string ExpMonth { get; set; }

    }
}
