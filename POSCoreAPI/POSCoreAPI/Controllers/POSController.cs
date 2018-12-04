using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using POSCoreBAL.Data;
using POSCoreBAL.POSHostModels;
using Microsoft.Extensions.Configuration;
using POSCoreBAL.POSModels;

namespace POSCoreAPI
{
    [Route("api/[controller]")]
    public class POSController : ControllerBase
    {
        IConfiguration _iconfiguration;
        POSBusinessAccessLayer BAL;
        public POSController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            BAL = new POSBusinessAccessLayer(iconfiguration.GetValue<string>("Data:ConnectionString"));
        }

        [HttpPost("GetLoginData")]
        public IActionResult GetLoginData([FromBody]JObject obj)
        {
            POSCoreBAL.POSModels.ModelLoginData mLoginData = obj.ToObject<ModelLoginData>();
            LoginData login = new LoginData();
            login.ID = mLoginData.ID;
            login.Data = mLoginData.Data;
            UserAccount useraccount = BAL.GetLoginData(Convert.ToInt32(login.Data));
            return Ok(useraccount);
        }

        [HttpPost("GetTickets")]
        public IActionResult GetTickets([FromBody]JObject obj)
        {
            ModelFetchTickets mFetchTickets = obj.ToObject<ModelFetchTickets>();
            UserAccount userAccount = new UserAccount();
            userAccount.ID = mFetchTickets.ID;
            userAccount.Name = mFetchTickets.Name;
            userAccount.PIN = mFetchTickets.PIN;
            List<Ticket>  tickets = BAL.GetTickets(userAccount, 0);
            return Ok(tickets);
        }

        [HttpPost("GetTicketById")]
        public IActionResult GetTicketById([FromBody]JObject obj)
        {
            ModelFetchTickets mFetchTickets = obj.ToObject<ModelFetchTickets>();
            UserAccount userAccount = new UserAccount();
            userAccount.ID = mFetchTickets.ID;
            userAccount.Name = mFetchTickets.Name;
            userAccount.PIN = mFetchTickets.PIN;
            string ticketId = Convert.ToString(mFetchTickets.TicketID);
            TicketBill ticket = BAL.GetTicketsById(userAccount, "0", Convert.ToInt32(ticketId));
            return Ok(ticket);
        }

        [HttpPost("PostApplyPayment")]
        public IActionResult PostApplyPayment([FromBody]JObject obj)
        {
            QueuedPaymentBase paymentData = obj.ToObject<QueuedPaymentBase>();
            Result res = BAL.ApplyPayment(paymentData);
            return Ok(res);
        }

        [HttpPost("PostSettleTicket")]
        public IActionResult PostSettleTicket([FromBody]JObject obj)
        {
            ModelSettleTicket mSettleTicket = obj.ToObject<ModelSettleTicket>();
            QueuedPaymentTicket ticket = new QueuedPaymentTicket();
            UserAccount useraccount = new UserAccount();
            ticket = mSettleTicket.Ticket;
            useraccount = mSettleTicket.UserAccount;
            ticket.Owner = useraccount;
            Result res = BAL.SettleTicket(ticket);
            return Ok(res);
        }

        [HttpPost("PostPrintReceipt")]
        public IActionResult PostPrintReceipt([FromBody]JObject obj)
        {
            PrintedReceipt printedReceipt = obj.ToObject<PrintedReceipt>();
            Result res = BAL.PrintReceipt(printedReceipt, string.Empty);
            return Ok(res);
        }

        [HttpGet("GetPOSStatus")]
        public IActionResult GetPOSStatus()
        {
            POSStatus result = new POSStatus { Kind = "TEST POS SYSTEM", Status= POSState.Online.ToString(), Version = "1.0" };
            return Ok(result);
        }

        [HttpGet("GetPrinters")]
        public IActionResult GetPrinters()
        {
            List<KeyValuePair<int, string>> kvpList = BAL.GetPrinters();
            return Ok(kvpList);
        }

        [HttpGet("GetData/type={type}")]
        public IActionResult GetData(int type)
        {
            DataTable json = BAL.GetData(type);
            return Ok(json);
        }

        [HttpGet("GetPOSDetails/PIN={PIN}")]
        public IActionResult GetPOSDetails(string PIN)
        {
            List<POSDetails> pOSDetails = BAL.GetPOSDetails(PIN);
            return Ok(pOSDetails);
        }

        [HttpPost("CreatePOSUsers")]
        public IActionResult CreatePOSUsers([FromBody]Users UserModel)
        {
            if (UserModel != null)
            { 
                return Ok(BAL.InsertPOSUsers(UserModel));
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPost("CreatePOSTickets/userid={userid}")]
        public IActionResult CreatePOSTickets([FromBody]List<Tickets> TicketsModel, int userid)
        {
            if (TicketsModel != null && userid > 0)
            {
                return Ok(BAL.InsertPOSTickets(userid, TicketsModel));
            }
            else
            {
                return StatusCode(500);
            }

        }

        [HttpPost("CreatePOSOrders/ticketId={ticketId}&orderId={orderId}")]
        public IActionResult CreatePOSOrders([FromBody]List<Orders> OrdersModel, int ticketid, int orderid)
        {
            if (OrdersModel != null && ticketid > 0)
            {
                return Ok(BAL.InsertPOSOrders(ticketid, orderid, OrdersModel));
            }
            else
            {
                return StatusCode(500);
            }
            
            
        }

        [HttpPost("CreatePOSPayments/ticketId={ticketId}")]
        public IActionResult CreatePOSPayments([FromBody]Payments PaymentModel, int ticketId)
        {
            if (PaymentModel != null && ticketId > 0)
            {
                return Ok(BAL.InsertPOSPayments(ticketId, PaymentModel));
            }
            else
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost("CreatePOSCreditCards/paymentId={paymentId}")]
        public IActionResult CreatePOSCreditCards([FromBody]CreditCard CreditCardModel, int paymentId)
        {
            if (CreditCardModel != null && paymentId > 0)
            {
                return Ok(BAL.InsertPOSCreditCards(paymentId, CreditCardModel));
            }
            else
            {
                return StatusCode(500);
            }
            
        }
    }
}
