using System;
using System.Collections.Generic;

namespace EOS.Models
{
    public partial class Role
    {
        public Role()
        {
            Account = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
