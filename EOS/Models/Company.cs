using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Company
    {
        public Company()
        {
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Service> Service { get; set; }
    }
}
