﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Repositories.Repositories.Models
{
    public partial class AspNetUserClaim
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
