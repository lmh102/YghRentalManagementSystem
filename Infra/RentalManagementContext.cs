using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using YghRentalManagementSystem.Infra.Models;

namespace YghRentalManagementSystem.Infra
{
    public partial class RentalManagementContext : DbContext
    {
        public RentalManagementContext()
        {
        }

        public RentalManagementContext(DbContextOptions<RentalManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccommodationMedium> AccommodationMedia { get; set; } = null!;
        public virtual DbSet<Accommondation> Accommondations { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Amenity> Amenities { get; set; } = null!;
        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<ApartmentMedium> ApartmentMedia { get; set; } = null!;
        public virtual DbSet<ApartmentsAmenity> ApartmentsAmenities { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<Estatetype> Estatetypes { get; set; } = null!;
        public virtual DbSet<FollowUserAccom> FollowUserAccoms { get; set; } = null!;
        public virtual DbSet<Medium> Media { get; set; } = null!;
        public virtual DbSet<Notifycation> Notifycations { get; set; } = null!;
        public virtual DbSet<NotifycationFollow> NotifycationFollows { get; set; } = null!;
        public virtual DbSet<NotifycationReservation> NotifycationReservations { get; set; } = null!;
        public virtual DbSet<NotifycationReview> NotifycationReviews { get; set; } = null!;
        public virtual DbSet<Reason> Reasons { get; set; } = null!;
        public virtual DbSet<ReasonReport> ReasonReports { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Unavailableapartmentdate> Unavailableapartmentdates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;database=ygh_rental_management_system;user id=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AccommodationMedium>(entity =>
            {
                entity.ToTable("accommodation_media");

                entity.HasIndex(e => e.MediaId, "FK_Accomodation_Media_Media_idx");

                entity.HasIndex(e => e.AccomondationId, "FK_accommodation_media_Accommdation_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AccomondationId).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Accomondation)
                    .WithMany(p => p.AccommodationMedia)
                    .HasForeignKey(d => d.AccomondationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accommodation_Media_Accommodation");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.AccommodationMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accomodation_Media_Media");
            });

            modelBuilder.Entity<Accommondation>(entity =>
            {
                entity.ToTable("accommondations");

                entity.HasIndex(e => e.ApartmentId, "Fk_Acc_Apartment_idx");

                entity.HasIndex(e => e.EstateTypesId, "ForeignKey_Accommodations_EstateTypes_idx");

                entity.HasIndex(e => e.OwnerId, "ForeignKey_Accommondations_User_idx");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Expiration).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.OwnerId).HasMaxLength(50);

                entity.Property(e => e.Policies)
                    .HasMaxLength(3000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Quanlity).HasPrecision(2, 1);

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Accommondations)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Acc_Apartment");

                entity.HasOne(d => d.EstateTypes)
                    .WithMany(p => p.Accommondations)
                    .HasForeignKey(d => d.EstateTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForeignKey_Accommodations_EstateTypes");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Accommondations)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForeignKey_Accommondations_User");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.UserId, "UserId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UserName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId, "accounts_userer_roleId_idx");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Emai).HasMaxLength(200);

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForeignKey_accounts_userer");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForignKey_accounts_users");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Detail).HasMaxLength(300);

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Nation).HasMaxLength(200);
            });

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.ToTable("amenities");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amenity1)
                    .HasMaxLength(100)
                    .HasColumnName("Amenity");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("apartments");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<ApartmentMedium>(entity =>
            {
                entity.ToTable("apartment_media");

                entity.HasIndex(e => e.ApartmentId, "FK_Apartment_Media_Apartment_idx");

                entity.HasIndex(e => e.MediaId, "FK_Apartment_Media_Media_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentMedia)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartment_Media_Apartment");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.ApartmentMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartment_Media_Media");
            });

            modelBuilder.Entity<ApartmentsAmenity>(entity =>
            {
                entity.ToTable("apartments_amenities");

                entity.HasIndex(e => e.AmenityId, "FK_Amenity_idx");

                entity.HasIndex(e => e.ApartmentId, "FK_Apartment_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Amenity)
                    .WithMany(p => p.ApartmentsAmenities)
                    .HasForeignKey(d => d.AmenityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amenity");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentsAmenities)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartment");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chat");

                entity.HasIndex(e => new { e.SendedId, e.ReceivedId }, "FK_Chat_Sender_idx");

                entity.HasIndex(e => e.ReceivedId, "FK_Chat_User_Receiver_idx");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.ReceivedId).HasMaxLength(50);

                entity.Property(e => e.SendedId).HasMaxLength(50);

                entity.HasOne(d => d.Received)
                    .WithMany(p => p.ChatReceiveds)
                    .HasForeignKey(d => d.ReceivedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User_Receiver");

                entity.HasOne(d => d.Sended)
                    .WithMany(p => p.ChatSendeds)
                    .HasForeignKey(d => d.SendedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User");
            });

            modelBuilder.Entity<Estatetype>(entity =>
            {
                entity.ToTable("estatetypes");

                entity.HasIndex(e => e.EstateType1, "EstateType_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.EstateType1)
                    .HasMaxLength(100)
                    .HasColumnName("EstateType")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ModifyAt).HasMaxLength(45);
            });

            modelBuilder.Entity<FollowUserAccom>(entity =>
            {
                entity.ToTable("follow_user_accom");

                entity.HasIndex(e => e.AccomodationId, "FK_Follow_Accom_idx");

                entity.HasIndex(e => e.UserId, "FK_Follow_User_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AccomodationId).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.FollowUserAccoms)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follow_Accom");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowUserAccoms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follow_User");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.ToTable("media");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Url).HasMaxLength(300);
            });

            modelBuilder.Entity<Notifycation>(entity =>
            {
                entity.ToTable("notifycation");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<NotifycationFollow>(entity =>
            {
                entity.ToTable("notifycation_follow");

                entity.HasIndex(e => e.NotifycationId, "FK_Notifycation_Follow_Notifycation_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Notifycation)
                    .WithMany(p => p.NotifycationFollows)
                    .HasForeignKey(d => d.NotifycationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifycation_Follow_Follow");

                entity.HasOne(d => d.NotifycationNavigation)
                    .WithMany(p => p.NotifycationFollows)
                    .HasForeignKey(d => d.NotifycationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifycation_Follow_Notifycation");
            });

            modelBuilder.Entity<NotifycationReservation>(entity =>
            {
                entity.ToTable("notifycation_reservation");

                entity.HasIndex(e => e.NotifycationId, "FK_notifycation_reservation_Notifycation_idx");

                entity.HasIndex(e => e.ReservationId, "FK_notifycation_reservation_Reservation_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Notifycation)
                    .WithMany(p => p.InverseNotifycation)
                    .HasForeignKey(d => d.NotifycationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notifycation_reservation_Notifycation");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.NotifycationReservations)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notifycation_reservation_Reservation");
            });

            modelBuilder.Entity<NotifycationReview>(entity =>
            {
                entity.ToTable("notifycation_review");

                entity.HasIndex(e => e.NotifycatonId, "FK_Notifycation_Review_Notifycation_idx");

                entity.HasIndex(e => e.ReviewId, "FK_Notifycation_Review_Review_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Notifycaton)
                    .WithMany(p => p.NotifycationReviews)
                    .HasForeignKey(d => d.NotifycatonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifycation_Review_Notifycation");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.NotifycationReviews)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifycation_Review_Review");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.ToTable("reasons");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReasonReport>(entity =>
            {
                entity.ToTable("reason_report");

                entity.HasIndex(e => e.ReasonId, "FK_Reason_Report_Reason_idx");

                entity.HasIndex(e => e.ReportId, "FK_Reason_Report_Report_idx");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.HasOne(d => d.Reason)
                    .WithMany(p => p.ReasonReports)
                    .HasForeignKey(d => d.ReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reason_Report_Reason");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReasonReports)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reason_Report_Report");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.HasIndex(e => e.AccomodationId, "FK_Report_Accommondation_idx");

                entity.HasIndex(e => e.UserId, "FK_Report_user_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AccomodationId).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Accommondation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_user");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.HasIndex(e => e.ApartmentId, "FK_Reservation_Apartment_idx");

                entity.HasIndex(e => e.UserId, "FK_User_idx");

                entity.HasIndex(e => e.Id, "idReservation_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Apartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_User");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AccommodationId).HasMaxLength(50);

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasPrecision(2, 1);

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Unavailableapartmentdate>(entity =>
            {
                entity.ToTable("unavailableapartmentdate");

                entity.HasIndex(e => e.ApartmentId, "FK_Âprartment_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Unavailableapartmentdates)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aprartment");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.RoleId, "ForeignKey_Users_Role_idx");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.AvatarId).HasMaxLength(200);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForeignKey_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
