using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Amenity
    {
        public Amenity()
        {
            ApartmentsAmenities = new HashSet<ApartmentsAmenity>();
        }

        public int Id { get; set; }
        public string Amenity1 { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<ApartmentsAmenity> ApartmentsAmenities { get; set; }
    }
}
