using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Estatetype
    {
        public Estatetype()
        {
            Accommondations = new HashSet<Accommondation>();
        }

        public int Id { get; set; }
        public string EstateType1 { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public string ModifyAt { get; set; } = null!;
        public sbyte IsDeleted { get; set; }

        public virtual ICollection<Accommondation> Accommondations { get; set; }
    }
}
