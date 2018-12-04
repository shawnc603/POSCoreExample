using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class LoginData
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Login Data based on input method
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// How data was obtained
        /// </summary>
        public LoginMethod Method { get; set; }
    }
}
