using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class PrintingInfo
    {
        /// <summary>
        /// Printer name
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Printer ID
        /// </summary>

        public string ID { get; set; }


        public SplitType SplitType { get; set; }

        /// <summary>
        /// True if it is the final payment for the bill
        /// </summary>
        public bool IsFinal { get; set; }
    }
}
