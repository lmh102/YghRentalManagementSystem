﻿using System;
using System.Collections.Generic;

namespace YghRentalManagementSystem.Infra.Models
{
    public partial class Accommondation
    {
        public Accommondation()
        {
            AccommodationMedia = new HashSet<AccommodationMedium>();
            Apartments = new HashSet<Apartment>();
            FollowUserAccoms = new HashSet<FollowUserAccom>();
            Reports = new HashSet<Report>();
        }

        public string Id { get; set; }
        public string OwnerId { get; set; }
        public int EstateTypesId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Quanlity { get; set; }
        public int? AddressId { get; set; }
        public string? Policies { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public sbyte IsDeleted { get; set; }

        public virtual Estatetype EstateTypes { get; set; } = null!;
        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<AccommodationMedium> AccommodationMedia { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<FollowUserAccom> FollowUserAccoms { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
