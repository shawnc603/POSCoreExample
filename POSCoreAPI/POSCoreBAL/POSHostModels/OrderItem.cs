using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace POSCoreBAL.POSHostModels
{
    public class OrderItem
    {
        /// <summary>
        /// ID for Item
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gross price without tax and discount
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the item without the description of modifiers
        /// </summary>
        public string Description { get; set; }

        public decimal Discount { get; set; }

        public int ParentID { get; set; }

        public int UniqueID { get; set; }

        public int Ordinal { get; set; }

        private List<OrderItem> _modifiers = new List<OrderItem>();
        /// <summary>
        /// List of modifications applied to this item
        /// </summary>
        public List<OrderItem> Modifiers
        {
            get { return _modifiers; }
            set
            {
                if (_modifiers == null)
                    _modifiers = new List<OrderItem>();

                _modifiers.Clear();
                _modifiers.AddRange(value);
            }
        }

        /// <summary>
        /// Calculates the total price this item plus its modifications
        /// </summary>
        /// <returns>Price + Sum(Modifications.Price)</returns>
        public decimal CalcModifiedPrice()
        {
            decimal modifiedPrice = 0.0M;
            modifiedPrice = Price + Modifiers.Sum(mod => mod.Price);
            return modifiedPrice;
        }

        /// <summary>
        /// Gets an extended item description
        /// </summary>
        /// <param name="item">OrderItem to get an extended description for</param>
        /// <returns>Extended Description</returns>
        public string ExtendedDescription()
        {
            StringBuilder desc = new StringBuilder();
            desc.Append(Description);
            Modifiers.ForEach(delegate (OrderItem mod) { desc.AppendFormat(" {0}", mod.Description); });
            return desc.ToString();
        }
    }
}
