using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class ApartmentMedium
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int MediaId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
        public virtual Medium Media { get; set; } = null!;
    }
}
