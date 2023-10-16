using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Userrole
    {
        public Userrole()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
