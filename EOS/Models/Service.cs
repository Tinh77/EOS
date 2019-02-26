using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Descrition { get; set; }
        public int Status { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceTypeId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
