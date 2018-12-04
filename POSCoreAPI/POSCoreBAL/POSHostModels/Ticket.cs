using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class Ticket
    {
        /// <summary>
        /// The ID of the ticket at POS DB
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the ticket
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of the ticket (POS receipt used to be a different number than ID)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The ID of the table. Only few POS use the value, default to 0
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// The ID of department or section. Only few POS use the value, default to 0
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// The number of guest on the ticket
        /// </summary>
        public ushort GuestCount { get; set; }

        /// <summary>
        /// The balance of the ticket
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Total of previous payments made
        /// </summary>
        public decimal PaymentsTotal { get; set; }

        /// <summary>
        /// The date time of the ticket being created in ISO8601 string format
        /// </summary>
        protected string CreateTimeRaw { get; set; }

        /// <summary>
        /// The date time of the ticket being created
        /// </summary>
        public DateTime CreatedTime
        {
            get
            {
                DateTime result = DateTime.Now;
                DateTime.TryParse(CreateTimeRaw, out result);
                return result;
            }
            set { CreateTimeRaw = value.ToString("o"); }
        }

        /// <summary>
        /// The person who creates the ticket
        /// </summary>
        public UserAccount Owner { get; set; }

        /// <summary>
        /// The person who would close the ticket
        /// </summary>

        public UserAccount User { get; set; }

        /// <summary>
        /// Flags for the ticket
        /// </summary>
        public ObjectFlags Flags { get; set; }

        /// <summary>
        /// TicketAlertDetails numeric value used over the wire
        /// </summary>
        public TicketAlertDetails Alerts { get; set; }
    }
}
