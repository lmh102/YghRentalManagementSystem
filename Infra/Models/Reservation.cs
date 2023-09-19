using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            NotifycationReservations = new HashSet<NotifycationReservation>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public sbyte IsDeleted { get; set; }
        public string OwnerId { get; set; }
        public int NumberRoom { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
        public virtual User Owner { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<NotifycationReservation> NotifycationReservations { get; set; }
    }
}
