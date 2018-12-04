using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public class Order
    {
        private List<OrderItem> _items = new List<OrderItem>();

        /// <summary>
        /// List of Items attached to this Order
        /// </summary>
        public List<OrderItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items == null)
                    _items = new List<OrderItem>();

                _items.Clear();
                _items.AddRange(value);
            }
        }

        /// <summary>
        /// Tip applied to this order
        /// </summary>
        public decimal Tip { get; set; }
    }
}
