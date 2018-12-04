using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSModels
{
    public class Tickets
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string TableName { get; set; }
        public int? TableNumber { get; set; }
        public int? DepartmentId { get; set; }
        public int? GuestCount { get; set; }
        public decimal? Balance { get; set; }
        public string TicketAlerts { get; set; }
        public string Flags { get; set; }
        public string Options { get; set; }
        public DateTime? CreatedTime { get; set; }

        public List<Orders> Order { get; set; }

        public List<Payments> Payment { get; set; }

    }
}
