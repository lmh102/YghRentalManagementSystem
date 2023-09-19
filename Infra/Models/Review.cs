using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Review
    {
        public Review()
        {
            NotifycationReviews = new HashSet<NotifycationReview>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccommodationId { get; set; } = null!;
        public decimal Rate { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<NotifycationReview> NotifycationReviews { get; set; }
    }
}
