using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Emai { get; set; }
        public string Password { get; set; } = null!;
        public int Status { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
