using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int Employee2Id { get; set; }
        public int RoleId { get; set; }

        public virtual Employee Employee2 { get; set; }
        public virtual Role Role { get; set; }
    }
}
