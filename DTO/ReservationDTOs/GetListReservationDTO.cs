using YghRentalManagementSystem.DTO.AccommodationDTOs;
using YghRentalManagementSystem.DTO.ApartmentDTOs;
using YghRentalManagementSystem.DTO.UserDTOs;
using YghRentalManagementSystem.Infra.Enums;

namespace YghRentalManagementSystem.DTO.ReservationDTO
{
    public class GetListReservationDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public GetListRequestUserDTO Tenant { get; set; }
        public GetListRequestAccommodationDTO Accommodation { get; set; }

    }
}
