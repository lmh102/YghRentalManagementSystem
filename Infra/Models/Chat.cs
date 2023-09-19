using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Chat
    {
        public int Id { get; set; }
        public string SendedId { get; set; } = null!;
        public string ReceivedId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual User Received { get; set; } = null!;
        public virtual User Sended { get; set; } = null!;
    }
}
