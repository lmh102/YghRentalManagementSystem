using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class NotifycationFollow
    {
        public int Id { get; set; }
        public int NotifycationId { get; set; }
        public int FollowId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual FollowUserAccom Notifycation { get; set; } = null!;
        public virtual Notifycation NotifycationNavigation { get; set; } = null!;
    }
}
