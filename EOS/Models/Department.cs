using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
