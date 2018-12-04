using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum LoginMethod
    {
        /// <summary>
        /// Entered a PIN manually
        /// </summary>
        ManualEntry,
        /// <summary>
        /// Swipe a employee card
        /// </summary>
        CardSwipe
    }
}
