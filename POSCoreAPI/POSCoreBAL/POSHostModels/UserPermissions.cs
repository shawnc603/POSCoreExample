using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum UserPermissions 
    {
        /// <summary>
        /// User can view all tables
        /// </summary>
        ViewAll = 0x01,

        DeletePayment = 0x02
    }
}
