using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Notifycation
    {
        public Notifycation()
        {
            NotifycationFollows = new HashSet<NotifycationFollow>();
            NotifycationReviews = new HashSet<NotifycationReview>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public sbyte IsRead { get; set; }
        public int Type { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<NotifycationFollow> NotifycationFollows { get; set; }
        public virtual ICollection<NotifycationReview> NotifycationReviews { get; set; }
    }
}
