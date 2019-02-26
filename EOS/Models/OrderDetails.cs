using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int UnitPrice { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumberOfEmployee { get; set; }
        public int Status { get; set; }
        public int ServiceId { get; set; }
        public int OrderServiceId { get; set; }

        public virtual OrderService OrderService { get; set; }
        public virtual Service Service { get; set; }
    }
}
