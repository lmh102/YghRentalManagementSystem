using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Medium
    {
        public Medium()
        {
            AccommodationMedia = new HashSet<AccommodationMedium>();
            ApartmentMedia = new HashSet<ApartmentMedium>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDelete { get; set; }
        public int MediaType { get; set; }

        public virtual ICollection<AccommodationMedium> AccommodationMedia { get; set; }
        public virtual ICollection<ApartmentMedium> ApartmentMedia { get; set; }
    }
}
