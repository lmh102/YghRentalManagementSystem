using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class ReasonReport
    {
        public int Id { get; set; }
        public int ReasonId { get; set; }
        public int ReportId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Reason Reason { get; set; } = null!;
        public virtual Report Report { get; set; } = null!;
    }
}
