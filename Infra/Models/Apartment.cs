using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            Accommondations = new HashSet<Accommondation>();
            ApartmentMedia = new HashSet<ApartmentMedium>();
            ApartmentsAmenities = new HashSet<ApartmentsAmenity>();
            Reservations = new HashSet<Reservation>();
            Unavailableapartmentdates = new HashSet<Unavailableapartmentdate>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Quantity { get; set; }
        public int MaxOccupant { get; set; }
        public double? Price { get; set; }
        public float? Area { get; set; }
        public int? BedNumber { get; set; }
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<Accommondation> Accommondations { get; set; }
        public virtual ICollection<ApartmentMedium> ApartmentMedia { get; set; }
        public virtual ICollection<ApartmentsAmenity> ApartmentsAmenities { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Unavailableapartmentdate> Unavailableapartmentdates { get; set; }
    }
}
