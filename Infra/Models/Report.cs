using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Report
    {
        public Report()
        {
            ReasonReports = new HashSet<ReasonReport>();
        }

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string AccomodationId { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Accommondation Accomodation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ReasonReport> ReasonReports { get; set; }
    }
}
