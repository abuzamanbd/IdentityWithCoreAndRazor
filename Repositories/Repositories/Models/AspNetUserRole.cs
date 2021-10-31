using System;
using System.Collections.Generic;

#nullable disable

namespace Repositories.Repositories.Models
{
    public partial class AspNetUserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
