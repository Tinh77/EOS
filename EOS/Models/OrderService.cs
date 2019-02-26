using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class OrderService
    {
        public OrderService()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime BillDate { get; set; }
        public int Status { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
