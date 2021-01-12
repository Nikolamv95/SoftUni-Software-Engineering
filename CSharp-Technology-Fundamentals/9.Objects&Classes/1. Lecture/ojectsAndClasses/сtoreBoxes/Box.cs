using System;
using System.Collections.Generic;
using System.Text;

namespace storeBoxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity  { get; set; }
        public decimal PricePerBox { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
