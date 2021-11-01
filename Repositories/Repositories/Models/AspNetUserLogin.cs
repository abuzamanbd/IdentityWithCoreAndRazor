using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Repositories.Repositories.Models
{
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        [Key]
        public Guid UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
