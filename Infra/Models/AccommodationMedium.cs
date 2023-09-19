using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class AccommodationMedium
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public string AccomondationId { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Accommondation Accomondation { get; set; } = null!;
        public virtual Detaillmedium Media { get; set; } = null!;
    }
}
