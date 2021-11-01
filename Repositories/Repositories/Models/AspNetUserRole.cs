using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Repositories.Repositories.Models
{
    public partial class AspNetUserRole
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
