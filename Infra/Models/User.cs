using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class User
    {
        public User()
        {
            Accommondations = new HashSet<Accommondation>();
            ChatReceiveds = new HashSet<Chat>();
            ChatSendeds = new HashSet<Chat>();
            FollowUserAccoms = new HashSet<FollowUserAccom>();
            Reports = new HashSet<Report>();
            Reservations = new HashSet<Reservation>();
        }

        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AvatarId { get; set; }
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public int Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Accommondation> Accommondations { get; set; }
        public virtual ICollection<Chat> ChatReceiveds { get; set; }
        public virtual ICollection<Chat> ChatSendeds { get; set; }
        public virtual ICollection<FollowUserAccom> FollowUserAccoms { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
