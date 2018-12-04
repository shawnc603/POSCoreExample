using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSCoreBAL.POSHostModels;
using POSCoreBAL.POSModels;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


namespace POSCoreBAL.Data
{
    public class POSBusinessAccessLayer
    {
        private POSRepository repos = null;
        private string connectionString = String.Empty;
        public POSBusinessAccessLayer(string Connection)
        {
            repos = new POSRepository(Connection);
        }

        public DataTable GetData(int type)
        {
            DataTable dtUsers = repos.GetData(type);
            return dtUsers;
        }

        public List<POSDetails> GetPOSDetails(string PIN)
        {
            return repos.GetPOSDetails(PIN);
        }

        public  UserAccount GetLoginData(int data)
        {
            return repos.GetLoginData(data);
        }

        public  List<Ticket> GetTickets(UserAccount userAccount, int filter)
        {
            return repos.GetTickets(userAccount);
        }

        public  Ticket GetTicketsByName(UserAccount userAccount, string name)
        {
            return repos.GetTicketsByName(userAccount, name);
        }

        public TicketBill GetTicketsById(UserAccount userAccount, string filter, int ticketId)
        {
            TicketBill ticketBill = new TicketBill();

            ticketBill.Check = new Bill();
            ticketBill.Check = repos.GetBillSummary(ticketId);        

            ticketBill.Items = new List<OrderItem>();
            List<OrderItems> items = repos.GetOrderItems(ticketId);
            foreach (var item in items)
            {
                OrderItem oitem = new OrderItem()
                {
  
                    Price = item.ItemPrice,
                    Description = item.ItemDescription
                };

                ticketBill.Items.Add(oitem);
            }
            
            ticketBill.POSPayments = new List<PaymentInfo>();
            ticketBill.POSPayments = repos.GetPaymentInfo(ticketId);

            Ticket ticket =  repos.GetTicketsById(userAccount, ticketId);
            ticketBill.ID = ticket.ID;
            ticketBill.Name = ticket.Name;
            ticketBill.Number = ticket.Number;
            ticketBill.DepartmentID = ticket.DepartmentID;
            ticketBill.PaymentsTotal = ticket.PaymentsTotal;
            ticketBill.GuestCount = ticket.GuestCount;
            ticketBill.TableID = ticket.TableID;
            ticketBill.Owner = ticket.User;
            ticketBill.User = ticket.User;
            ticketBill.Flags = ticket.Flags;
            ticketBill.Alerts = ticket.Alerts;


            return ticketBill;
        }

        public Result ApplyPayment(QueuedPaymentBase paymentData)
        {
            int paymentID = 0;

            //insert payments
            if (paymentData != null)
            {
                Payments payment = new Payments();
                payment.PaymentTotal = paymentData.Amount;
                payment.TipTotal = paymentData.Tip;
                payment.TransactionCode = paymentData.ReferenceCode;
                payment.AuthCode = "123456";
                payment.CreatedTime = DateTime.Now;
                payment.GatewayPaymentId = 1;
                payment.TransactionCode = "1234";
                payment.PostenderType = "Credit card";
                payment.Subtotal = paymentData.Amount;
                payment.TaxTotal = 0;
                payment.TipTotal = paymentData.Tip;

                paymentID = repos.InsertPOSPayments(paymentData.Ticket.ID, payment);
            }

            ////insert credit card
            //CreditCard creditcard = new CreditCard();
            //creditcard.CardType = !String.IsNullOrEmpty(paymentData.POSTenderType) ? "MC" : paymentData.POSTenderType;

            //if (paymentData.CardData != null)
            //{
            //    creditcard.ExpMonth = !String.IsNullOrEmpty(paymentData.CardData.ExpMonth) ? "" : paymentData.CardData.ExpMonth;
            //    creditcard.ExpYear = !String.IsNullOrEmpty(paymentData.CardData.ExpYear) ? "" : paymentData.CardData.ExpYear;
            //    creditcard.PanHash = !String.IsNullOrEmpty(paymentData.CardData.PanHash) ? "" : paymentData.CardData.PanHash;
            //    creditcard.PANLast4 = !String.IsNullOrEmpty(paymentData.CardData.PANLast4) ? "" : paymentData.CardData.PANLast4;
            //}
         
            //if (paymentID > 1 && paymentData.CardData != null)
            //{ 
            //    InsertPOSCreditCards(paymentID, creditcard);
            //}
            return GetReturnObjectMessage(paymentID, string.Empty);
        }

        public Result SettleTicket(QueuedPaymentTicket ticketData)
        {
            int answer = repos.IsCheckClosed(ticketData);
            return GetReturnObjectMessage(answer, string.Empty);
        }

        public Result PrintReceipt(PrintedReceipt printedReceiptData, string printfilepath)
        {
            List<OrderItems> orderitems = new List<OrderItems>();

            ReceiptData receipt = new ReceiptData();    
            foreach (var item in printedReceiptData.Order.Items)
            {
                OrderItems oitem = new OrderItems();
                oitem.ItemDescription = item.Description;
                oitem.ItemPrice = item.Price;
                orderitems.Add(oitem);
            }
            receipt.Items = orderitems;

            receipt.SubTotal = printedReceiptData.Bill.Subtotal.Value;
            receipt.TaxTotal = printedReceiptData.Bill.TaxTotal.Value;
            receipt.TipTotal = printedReceiptData.Bill.TipTotal.Value;
            receipt.PaymentTotal = printedReceiptData.Bill.PaymentsTotal.Value;


            return GetReturnObjectMessage(1, string.Empty);

        }

        public List<KeyValuePair<int, string>> GetPrinters()
        {
            List<KeyValuePair<int, string>> kvpList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Bar"),
                new KeyValuePair<int, string>(2, "Cashier"),
                new KeyValuePair<int, string>(3, "BOHs"),
            };

            return kvpList;
        }

        public Result InsertPOSUsers(Users users)
        {
            string UserId = repos.InsertPOSUsers(users);
            return GetReturnObjectMessage(1, "userid:"+ UserId);
        }

        public Result InsertPOSTickets(int UserId, List<Tickets> tickets)
        {
            string TicketId  = repos.InsertPOSTickets(UserId, tickets);
            return GetReturnObjectMessage(1, "ticketId:" + TicketId);
        }

        public Result InsertPOSOrders(int TicketId, int OrderId, List<Orders> orders)
        {
            string ListOrderItemIds = repos.InsertPOSOrders(TicketId, OrderId, orders);
            return GetReturnObjectMessage(1, "orderids:" + ListOrderItemIds);
        }

        public Result InsertPOSPayments(int TicketId, Payments payments)
        {
            int PaymentId = repos.InsertPOSPayments(TicketId, payments);
            return GetReturnObjectMessage(1, "paymentid:" +PaymentId);
        }

        public Result InsertPOSCreditCards(int PaymentId, CreditCard creditCard)
        {
            int CreditCardId = repos.InsertPOSCreditCards(PaymentId, creditCard);
            return GetReturnObjectMessage(1, "creditcardid:" + CreditCardId);
        }


        #region Helper 
        private Result GetReturnObjectMessage(int answer, string message)
        {
            Result res = new Result();
            if (answer > 0)
            {
                res.status = "200";
                res.type = "response";
                res.resultMessage = message != string.Empty ? message: "Success";
            }
            else
            {
                res.status = "500";
                res.type = "response";
                res.resultMessage = message != string.Empty ? message : "POS Error";
            }
            return res;
        }
        public void WriteToFile(string jsondata, string printfilepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(printfilepath, false))
            {
                file.WriteLine(jsondata);
                file.WriteLine(" ");
            }
        }
        public string ConvertToJSON(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            string json = JsonConvert.SerializeObject(rows);
            return json;
        }
        #endregion
    }
}
