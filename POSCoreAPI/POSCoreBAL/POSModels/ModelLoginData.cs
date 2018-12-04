using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSCoreBAL.POSModels
{
    public class ModelLoginData
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Login Data based on input method
        /// </summary>
        public string Data { get; set; }

    }
}
