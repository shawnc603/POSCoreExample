using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class PrintedReceipt
    {
        /// <summary>
        /// Printer to Print to
        /// </summary>
        public int PrinterID { get; set; }
        /// <summary>
        /// Receipt Header
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// Receipt Footer
        /// </summary>
        public string Footer { get; set; }
        /// <summary>
        /// Payments made
        /// </summary>
        public ReceiptPayment Payment { get; set; }
        /// <summary>
        /// Bill object
        /// </summary>
        public ReceiptBill Bill { get; set; }
        /// <summary>
        /// Order object
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Receipt Format
        /// </summary>
        public ReceiptFormats Format { get; set; }
        /// <summary>
        /// POS Ticket
        /// </summary>
        public Ticket Ticket { get; set; }
        /// <summary>
        /// Field Options for Printing
        /// </summary>
        public FieldOptions Options { get; set; }
    }
}


