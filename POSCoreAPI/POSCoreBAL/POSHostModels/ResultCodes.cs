using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum ResultCodes : ushort
    {
        /// Error From Application ///

        /// <summary>
        /// Success
        /// </summary>
        Success = 0,
        /// <summary>
        /// An Unknown Error occurred
        /// </summary>
        
        ErrorFromApp = 1,
        /// <summary>
        /// Driver cannot/is-not connected to POS
        /// </summary>
        
        DriverDisconnected = 2,
        /// <summary>
        /// Connection to remote WebService failed
        /// </summary>
        
        DriverWSConnectionFailed = 3,
        /// <summary>
        /// Connection to remote database failed
        /// </summary>
        
        DriverDatabaseConnectionFailed = 4,
        /// <summary>
        /// Third party API failed
        /// </summary>
        
        Driver3PAPIFailed = 5,
        /// <summary>
        /// Error related to Sql database access
        /// </summary>
        
        DriverSqlError = 6,
        /// <summary>
        /// Configuration Error
        /// </summary>
        
        ConfigurationError = 7,
        /// <summary>
        /// Unsupported method
        /// </summary>
        
        NotSupported = 8,
        /// <summary>
        /// Data required was null
        /// </summary>
        
        RequiredParameterIsNull = 9,
        /// <summary>
        /// Invalid argument
        /// </summary>
        
        InvalidArgument = 10,
        /// <summary>
        /// Object not found
        /// </summary>
        
        ObjectNotFound = 11,
        /// <summary>
        /// Payload is required
        /// </summary>
        
        PayloadRequired = 12,
        /// <summary>
        /// UUID already in use in the queue
        /// </summary>
        
        UUIDAlreadyInUse = 20,
        /// <summary>
        /// UUID not found in the queue
        /// </summary>
        
        UUIDNotFound = 21,

        /// Error From POS ///

        /// <summary>
        /// Error returned from the POS
        /// </summary>
        
        ErrorFromPOS = 1000,
        /// <summary>
        /// Class is not registered
        /// </summary>
        
        ClassNotRegistered = 1001,
        /// <summary>
        /// Class is not licensed
        /// </summary>
        
        ClassNotLicensed = 1002,
        /// <summary>
        /// Employee not found
        /// </summary>
        
        EmployeeNotFound = 1101,
        /// <summary>
        /// Unauthorized
        /// </summary>
        
        Unauthorized = 1102,
        /// <summary>
        /// User already logged in elsewhere 
        /// </summary>
        
        LoginLocked = 1103,
        /// <summary>
        /// User is not clocked in
        /// </summary>
        
        NotClockedIn = 1104,
        /// <summary>
        /// Unknown Tender Type specified
        /// </summary>
        
        UnknownTenderType = 1105,
        /// <summary>
        /// Balance due on Ticket is 0
        /// </summary>
        
        TicketAlreadyPaid = 1106,
        /// <summary>
        /// Balance due on Ticket is not 0
        /// </summary>
        
        TicketBalanceNotZero = 1107,
        /// <summary>
        /// Ticket not found
        /// </summary>
        
        TicketNotFound = 1108,
        /// <summary>
        /// Item not found
        /// </summary>
        
        ItemNotFound = 1109,
        /// <summary>
        /// Printer not found
        /// </summary>
        
        PrinterNotFound = 1110,
        /// <summary>
        /// Printer margin not found
        /// </summary>
        
        PrinterMarginNotFound = 1111,

        /// Error From TDC

        /// <summary>
        /// Error returned from the TDC
        /// </summary>
        
        ErrorFromTDC = 2000,
        /// <summary>
        /// Wrong configuration values were supplied
        /// </summary>
        
        NoConfigFromTDC = 2001,
        /// <summary>
        /// Wrong configuration values were supplied
        /// </summary>
        
        UUIDNotFoundFromTDC = 2002,
        /// <summary>
        /// Last Error Code. Use values above this :)
        /// </summary>
        
        MaxErrorCode = 65535
        // DO NOT add values larger than the MaxErrorCode. The bits over MaxErrorCode are spoken for
    }
}
