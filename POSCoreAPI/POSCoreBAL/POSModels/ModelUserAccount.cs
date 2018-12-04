using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSCoreBAL.POSModels
{
    public class ModelUserAccount
    {
        /// <summary>
        /// The ID of the user at POS DB
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The PIN of the user for logging in POS system
        /// </summary>
        public string PIN { get; set; }
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }
    }
}

