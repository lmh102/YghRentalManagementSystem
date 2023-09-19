using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class ApartmentsAmenity
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int AmenityId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Amenity Amenity { get; set; } = null!;
        public virtual Apartment Apartment { get; set; } = null!;
    }
}
