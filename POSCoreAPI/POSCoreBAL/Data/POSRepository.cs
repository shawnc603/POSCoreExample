using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSCoreBAL.POSHostModels;
using POSCoreBAL.POSModels;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Collections;

namespace POSCoreBAL.Data
{
    public class POSRepository
    {
        private string _connectionString = String.Empty;
        public POSRepository(string Connection)
        {
            _connectionString = Connection;
        }

        public DataTable GetData(int type)
        {
            string sql = @"
                    select* from users u
                    left join tickets t on u.userid = t.userid
                    left join[order] o on t.ticketid = o.ticketid
                    left join payments p on t.ticketid = p.ticketid
                    left join creditcard c on p.paymentid = c.paymentid
                    where u.userid = " +type;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(dt);
                        }
                        conn.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "GetData Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return dt;
        }

        public List<POSDetails> GetPOSDetails(string PIN)
        {
            List<POSDetails> ListPOSDetails = new List<POSDetails>();
            try
            {

                string sql = @"
                    select* from users u
                    left join tickets t on u.userid = t.userid
                    left join[order] o on t.ticketid = o.ticketid
                    left join payments p on t.ticketid = p.ticketid
                    left join creditcard c on p.paymentid = c.paymentid
                    where u.pin = " + PIN;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                POSDetails pOSDetails = new POSDetails()
                                {
                                    UserID = DataHelper.EvalField<int>(reader["UserId"]),
                                    PIN = DataHelper.EvalField<string>(reader["PIN"]),
                                    Name = DataHelper.EvalField<string>(reader["Name"]),
                                    TicketId = DataHelper.EvalField<int>(reader["TicketId"]),
                                    TableName = DataHelper.EvalField<string>(reader["TableName"]),
                                    TableNumber = DataHelper.EvalField<int>(reader["TableNumber"]),
                                    DepartmentId = DataHelper.EvalField<int>(reader["DepartmentId"]),
                                    GuestCount = DataHelper.EvalField<int>(reader["GuestCount"]),
                                    Balance = DataHelper.EvalField<int>(reader["Balance"]),
                                    OrderId = DataHelper.EvalField<int>(reader["OrderId"]),
                                    ItemDescription = DataHelper.EvalField<string>(reader["ItemDescription"]),
                                    ItemPrice = DataHelper.EvalField<decimal>(reader["ItemPrice"]),
                                    GatewayPaymentId = DataHelper.EvalField<int>(reader["GatewayPaymentId"]),
                                    AuthCode = DataHelper.EvalField<string>(reader["AuthCode"]),
                                    TransactionCode = DataHelper.EvalField<string>(reader["TransactionCode"]),
                                    POSTenderType = DataHelper.EvalField<string>(reader["POSTenderType"]),
                                    SubTotal = DataHelper.EvalField<decimal>(reader["SubTotal"]),
                                    TaxTotal = DataHelper.EvalField<decimal>(reader["TaxTotal"]),
                                    TipTotal = DataHelper.EvalField<decimal>(reader["TipTotal"]),
                                    PaymentTotal = DataHelper.EvalField<decimal>(reader["PaymentTotal"]),
                                    CreditCardId = DataHelper.EvalField<int>(reader["CreditCardId"]),
                                    PaymentId = DataHelper.EvalField<int>(reader["PaymentId"]),
                                    CardType = DataHelper.EvalField<string>(reader["CardType"]),
                                    PanHash = DataHelper.EvalField<string>(reader["PanHash"]),
                                    PanLast4 = DataHelper.EvalField<string>(reader["PanLast4"]),
                                    ExpYear = DataHelper.EvalField<string>(reader["ExpYear"]),
                                    ExpMonth = DataHelper.EvalField<string>(reader["ExpMonth"]),
                                };

                                ListPOSDetails.Add(pOSDetails);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "GetTickets Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return ListPOSDetails;
        }

        public int IsCheckClosed(QueuedPaymentTicket  ticketData)
        {
            int IsClosed = 0;
            try
            {

                string sql = "select GatewaypaymentId from payments where ticketId = " + ticketData.ID;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int GatewaypaymentId = DataHelper.EvalField<int>(reader["GatewaypaymentId"]);
                                if (GatewaypaymentId == 1)
                                {
                                    IsClosed = 1;
                                }
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "IsCheckClosed Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return IsClosed;
        }



        public UserAccount GetLoginData(int data)
        {
            UserAccount userAccount = null;
            try
            {

                string sql = "select * from users where PIN=" + data;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userAccount = new UserAccount()
                                {
                                    ID = DataHelper.EvalField<int>(reader["UserId"]),
                                    Name = DataHelper.EvalField<string>(reader["Name"]),
                                    Permissions = UserPermissions.ViewAll,
                                    PIN = DataHelper.EvalField<string>(reader["PIN"])
                                };
                            }                            
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "GetLoginData Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return userAccount;
        }

        public List<Ticket> GetTickets(UserAccount userAccount)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {

                string sql = @"select * from users u
                                inner join tickets t on u.userid = t.userid
                                where u.PIN = " + userAccount.PIN;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ticket ticket = new Ticket()
                                {
                                    ID = DataHelper.EvalField<int>(reader["TicketId"]),
                                    Name = DataHelper.EvalField<string>(reader["TableName"]),
                                    Number = DataHelper.EvalField<string>(reader["TableNumber"]),
                                    TableID = DataHelper.EvalField<int>(reader["DepartmentID"]),
                                    DepartmentID = DataHelper.EvalField<int>(reader["DepartmentID"]),
                                    GuestCount = DataHelper.EvalField<ushort>(reader["GuestCount"]),
                                    Balance = DataHelper.EvalField<int>(reader["Balance"]),
                                    CreatedTime = DateTime.Now,
                                    Flags = ObjectFlags.IsAppliedPreTax,
                                    Alerts = TicketAlertDetails.None,
                                    PaymentsTotal = DataHelper.EvalField<int>(reader["Balance"]),
                                    Owner = userAccount,
                                    User = userAccount

                                };

                                tickets.Add(ticket);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "GetTickets Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return tickets;
        }

        public List<OrderItems> GetOrderItems(int ticketId)
        {
            List<OrderItems> Items = new List<OrderItems>();
            try
            {

                string sql = @"select OrderID, ItemDescription, ItemPrice from [Order] where TicketId = " + ticketId;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderItems item = new OrderItems()
                                {
                                    ItemDescription = DataHelper.EvalField<string>(reader["ItemDescription"]),
                                    ItemPrice = DataHelper.EvalField<decimal>(reader["ItemPrice"]),
                                };

                                Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "GetOrderItems Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return Items;
        }

        public List<PaymentInfo> GetPaymentInfo(int ticketId)
        {
            List<PaymentInfo> paymentInfoList = new List<PaymentInfo>();
            try
            {

                string sql = @"select POSTenderType, PaymentTotal from payments where TicketId = " + ticketId;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                PaymentInfo item = new PaymentInfo()
                                {
                                    TenderName = DataHelper.EvalField<string>(reader["POSTenderType"]),
                                    Amount = DataHelper.EvalField<decimal>(reader["PaymentTotal"])
                                };
                                paymentInfoList.Add(item);
                            }

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "GetPaymentInfo Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return paymentInfoList;
        }

        public Bill GetBillSummary(int ticketId)
        {
            Bill bill = new Bill();
            try
            {

                string sql = @"select SubTotal, TaxTotal, PaymentTotal from payments where TicketId = " + ticketId;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                bill.Subtotal = DataHelper.EvalField<decimal>(reader["SubTotal"]);
                                bill.TaxTotal = DataHelper.EvalField<decimal>(reader["TaxTotal"]);
                                bill.PaymentsTotal = DataHelper.EvalField<decimal>(reader["PaymentTotal"]);
                               
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "GetBillSummary Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return bill;
        }

        public  Ticket GetTicketsByName(UserAccount userAccount, string name)
        {
            List<Ticket> tickets = GetTickets(userAccount);
            Ticket ticket = tickets.Find(x => x.Name == name);
            return ticket;
        }

        public Ticket GetTicketsById(UserAccount userAccount, int ID)
        {
            List<Ticket> tickets =  GetTickets(userAccount);
            Ticket ticket = tickets.Find(x => x.ID == ID);
            return ticket;
        }


        public string InsertPOSUsers(Users users)
        {
            double UserID = 0;
            try
            {
                string sql = @"if exists(select 1 from users u 
                                    where PIN = " + users.PIN + @") 
                                begin
                                    update users set name =@name where pin=@pin; SELECT userid from users where pin=@pin;
                                end  
                                else
                                begin
                                    insert into users(name,pin) values (@name,@pin); SELECT SCOPE_IDENTITY();
                                end";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", users.Name);
                        cmd.Parameters.AddWithValue("@pin", users.PIN);
                        //rowsAffected = cmd.ExecuteNonQuery();
                        UserID = Convert.ToDouble(cmd.ExecuteScalar());

                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                string msg = "InsertPOSUsers Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return UserID.ToString();

        }

        public string InsertPOSTickets(int UserId, List<Tickets> tickets)
        {
            double ticketId = 0;
            try
            {

                foreach (Tickets ticket in tickets)
                {

                    string sql = @"if exists(select 1 from tickets t where userid = @UserId and tablename =@TableName)
                                begin
                                    update tickets set TableName=@TableName,TableNumber=@TableNumber,DepartmentId=@DepartmentId,GuestCount=@GuestCount,Balance=@Balance,TicketAlerts=@TicketAlerts,Flags=@Flags,Options=@Options
                                    where userid = @UserId; SELECT ticketid from tickets where userid =@UserId
                                end  
                                else
                                begin
                                    insert into tickets(UserId, TableName, TableNumber, DepartmentId, GuestCount, Balance, TicketAlerts, Flags, Options, CreatedTime) values " +
                                     @"(@UserId,@TableName,@TableNumber,@DepartmentId,@GuestCount,@Balance,@TicketAlerts,@Flags,@Options,@CreatedTime); SELECT SCOPE_IDENTITY();
                                end";

                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", UserId);
                            cmd.Parameters.AddWithValue("@TableName", ticket.TableName);
                            cmd.Parameters.AddWithValue("@TableNumber", ticket.TableNumber);
                            cmd.Parameters.AddWithValue("@DepartmentId", ticket.DepartmentId);
                            cmd.Parameters.AddWithValue("@GuestCount", ticket.GuestCount);
                            cmd.Parameters.AddWithValue("@Balance", ticket.Balance);
                            cmd.Parameters.AddWithValue("@TicketAlerts", ticket.TicketAlerts);
                            cmd.Parameters.AddWithValue("@Flags", ticket.Flags);
                            cmd.Parameters.AddWithValue("@Options", ticket.Options);
                            cmd.Parameters.AddWithValue("@CreatedTime", DateTime.Now);
                            ticketId = Convert.ToDouble(cmd.ExecuteScalar());
                        }
                        conn.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                string msg = "InsertPOSTickets Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return ticketId.ToString();

        }

        public string InsertPOSOrders(int TicketId, int OrderId, IEnumerable<Orders> orders)
        {
            double OrderItemId = 0;
            string OrderItemIds = string.Empty;
            StringBuilder listOrderItemIds = new StringBuilder();
            try
            {
                foreach (Orders order in orders)
                {
                    string sql = @"if exists(select 1 from [Order] where ticketId = @TicketId and orderId =" +OrderId + @") 
                                begin
                                    update [Order] set ItemDescription= @ItemDescription,ItemPrice = @ItemPrice where ticketId = @TicketId and orderId =" + OrderId + @";
                                end  
                                else
                                begin
                                    insert into [Order](TicketId,ItemDescription,ItemPrice) values (@TicketId,@ItemDescription,@ItemPrice);
                                    SELECT SCOPE_IDENTITY();
                                end";

                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@TicketId", TicketId);
                            cmd.Parameters.AddWithValue("@ItemDescription", order.ItemDescription);
                            cmd.Parameters.AddWithValue("@ItemPrice", order.ItemPrice);
                            OrderItemId = Convert.ToDouble(cmd.ExecuteScalar());
                        }
                        conn.Close();
                    }
                    listOrderItemIds.Append(OrderItemId+",");
                }
                int index = listOrderItemIds.ToString().Length - 1;
                OrderItemIds = listOrderItemIds.ToString().Remove(index);
            }
            catch (SqlException ex)
            {
                string msg = "InsertPOSOrders Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return OrderItemIds;
        }

        public int InsertPOSPayments(int TicketId, Payments payments)
        {
            object paymentId = 0;
            try
            {
                string sql = @"if exists(select 1 from payments where ticketId = " + TicketId + @") 
                                begin
                                    update payments set GatewayPaymentID=@GatewayPaymentID, AuthCode=@AuthCode, TransactionCode=@TransactionCode, POSTenderType=@POSTenderType, 
                                    Subtotal=@Subtotal, TaxTotal=@TaxTotal, TipTotal=@TipTotal, PaymentTotal=@PaymentTotal where ticketId = " + TicketId + @";
                                    SELECT paymentId as Id from payments where ticketId =" + TicketId + @"
                                end  
                                else
                                begin
                                    insert into payments(TicketId, GatewayPaymentID, AuthCode, TransactionCode, POSTenderType, Subtotal, TaxTotal, 
                                    TipTotal, PaymentTotal, CreatedTime) values (@TicketId, @GatewayPaymentID, @AuthCode, @TransactionCode, @POSTenderType, @Subtotal, @TaxTotal,
                                    @TipTotal, @PaymentTotal, @CreatedTime);
                                    SELECT scope_identity() as Id;
                                end";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TicketId", TicketId);
                        cmd.Parameters.AddWithValue("@GatewayPaymentID", payments.GatewayPaymentId);
                        cmd.Parameters.AddWithValue("@AuthCode", payments.AuthCode);
                        cmd.Parameters.AddWithValue("@TransactionCode", payments.TransactionCode);
                        cmd.Parameters.AddWithValue("@POSTenderType", payments.PostenderType);
                        cmd.Parameters.AddWithValue("@Subtotal", payments.Subtotal);
                        cmd.Parameters.AddWithValue("@TaxTotal", payments.TaxTotal);
                        cmd.Parameters.AddWithValue("@TipTotal", payments.TipTotal);
                        cmd.Parameters.AddWithValue("@PaymentTotal", payments.PaymentTotal);
                        cmd.Parameters.AddWithValue("@CreatedTime", DateTime.Now);
                        paymentId = cmd.ExecuteScalar();


                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                string msg = "InsertPOSPayments Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            if (paymentId != null)
            {
                return Convert.ToInt32(paymentId);
            }
            else
            {
                return -1;
            }
            
        }

        public int  InsertPOSCreditCards(int PaymentId, CreditCard creditCard)
        {
            int rowsAffected = 0;

            try
            {

                string sql = @"if exists(select 1 from CreditCard where PaymentId = " + PaymentId + @") 
                                begin
                                    update CreditCard set CardType=@CardType, PanHash=@PanHash, PANLast4=@PANLast4, ExpYear=@ExpYear, ExpMonth=@ExpMonth where PaymentId = " + PaymentId + @"
                                end  
                                else
                                begin
                                    insert into CreditCard(PaymentId, CardType, PanHash, PANLast4, ExpYear, ExpMonth) values (@PaymentId, @CardType, @PanHash, @PANLast4, @ExpYear, @ExpMonth)
                                end";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
                        cmd.Parameters.AddWithValue("@CardType", creditCard.CardType);
                        cmd.Parameters.AddWithValue("@PanHash", creditCard.PanHash);
                        cmd.Parameters.AddWithValue("@PANLast4", creditCard.PANLast4);
                        cmd.Parameters.AddWithValue("@ExpYear", creditCard.ExpYear);
                        cmd.Parameters.AddWithValue("@ExpMonth", creditCard.ExpMonth);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }               
            }
            catch (SqlException ex)
            {
                string msg = "InsertPOSCreditCards Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }

            return rowsAffected;

        }
    }

    public class DataHelper
    {
        [System.Diagnostics.DebuggerStepThrough]
        public static T EvalField<T>(object fieldValue, T defaultValue = default(T))
        {
            if (fieldValue == null || Convert.IsDBNull(fieldValue))
            {
                return defaultValue;
            }
            else
            {
                return (T)Convert.ChangeType(fieldValue, typeof(T));
            }
        }
    }
}
