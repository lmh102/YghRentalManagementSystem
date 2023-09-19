using YghRentalManagementSystem.DTO.ApartmentDTOs;

namespace YghRentalManagementSystem.DTO.AccommodationDTOs
{
    public class GetListRequestAccommodationDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public GetListRequestApartmentDTO Apartment { get; set; }
    }
}
