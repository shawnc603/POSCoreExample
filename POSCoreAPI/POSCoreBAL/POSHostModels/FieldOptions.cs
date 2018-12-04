using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum FieldOptions : uint
    {
        /// <summary>
        /// Default Field options
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// Show Extended Descriptions
        /// </summary>
        ShowExtendedDescription = 0x0001
    }
}
