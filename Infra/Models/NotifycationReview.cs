using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class NotifycationReview
    {
        public int Id { get; set; }
        public int NotifycatonId { get; set; }
        public int ReviewId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Notifycation Notifycaton { get; set; } = null!;
        public virtual Review Review { get; set; } = null!;
    }
}
