using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Account = new HashSet<Account>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int DepartmentId { get; set; }
        public int Status { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
