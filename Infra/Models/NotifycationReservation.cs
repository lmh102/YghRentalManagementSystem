using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class NotifycationReservation
    {
        public NotifycationReservation()
        {
            InverseNotifycation = new HashSet<NotifycationReservation>();
        }

        public int Id { get; set; }
        public int NotifycationId { get; set; }
        public int ReservationId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual NotifycationReservation Notifycation { get; set; } = null!;
        public virtual Reservation Reservation { get; set; } = null!;
        public virtual ICollection<NotifycationReservation> InverseNotifycation { get; set; }
    }
}
