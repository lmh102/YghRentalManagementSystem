using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Reason
    {
        public Reason()
        {
            ReasonReports = new HashSet<ReasonReport>();
        }

        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<ReasonReport> ReasonReports { get; set; }
    }
}
