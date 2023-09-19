using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class FollowUserAccom
    {
        public FollowUserAccom()
        {
            NotifycationFollows = new HashSet<NotifycationFollow>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccomodationId { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDelete { get; set; }

        public virtual Accommondation Accomodation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<NotifycationFollow> NotifycationFollows { get; set; }
    }
}
