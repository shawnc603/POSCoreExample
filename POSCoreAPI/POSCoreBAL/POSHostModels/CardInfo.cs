using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class CardInfo
    {
        /// <summary>
        /// Masked card number
        /// </summary>
        public string PanHash { get; set; }
        /// <summary>
        /// Last four number of the card
        /// </summary>]
        public string PANLast4 { get; set; }
        /// <summary>
        /// Expired year
        /// </summary>
        public string ExpYear { get; set; }
        /// <summary>
        /// Expired month
        /// </summary>
        public string ExpMonth { get; set; }
    }
}
